﻿using Car.App.Management.Application.ViewModels;
using Car.App.Management.CC.Identity.Models;
using Car.App.Management.Domain.Interfaces;
using Car.App.Management.Services.Api.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Car.App.Management.Services.Api.Controllers
{
    [ApiController]
    [Route("api/account")]
    [Produces("application/json")]
    public class AccountController : ApiController
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppSettings _appSettings;

        public AccountController(
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            IOptions<AppSettings> appSettings,
            IUser user) : base(user)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(UserRegistration userRegistration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    success = false,
                    errors = "Modelo de entrada inválido."
                });
            }

            var user = new IdentityUser
            {
                UserName = userRegistration.Name,
                Email = userRegistration.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, userRegistration.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    return BadRequest(error.Code + " " + error.Description);
                }

                return BadRequest(userRegistration);
            }

            await _signInManager.SignInAsync(user, false);
            var token = await GenerateJwt(userRegistration.Email);

            return Ok(token);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UserLogin userLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    success = false,
                    errors = "Modelo de entrada inválido."
                });
            }

            var userName = await _userManager.FindByEmailAsync(userLogin.Email);

            if (userName is null)
            {
                return StatusCode(403);
            }

            var result = await _signInManager.PasswordSignInAsync(userName, userLogin.Password, false, true);

            if (result.Succeeded)
            {
                var token = await GenerateJwt(userLogin.Email);
                return Ok(token);
            }

            return StatusCode(403);
        }

        private async Task<LoginResponseViewModel> GenerateJwt(string email)
        {

            var user = await _userManager.FindByEmailAsync(email);
            var claims = await _userManager.GetClaimsAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Subject = identityClaims,
                Issuer = _appSettings.Issuer,
                Audience = _appSettings.ValidAt,
                Expires = DateTime.UtcNow.AddHours(_appSettings.Expiration),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            var encodedToken = tokenHandler.WriteToken(token);

            return new LoginResponseViewModel
            {
                AccessToken = encodedToken,
                ExpiresIn = 9999,
                UserToken = new UserTokenViewModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    Name = user.UserName,
                    Claims = claims.Select(c => new ClaimViewModel { Type = c.Type, Value = c.Value })
                }
            };
        }
    }
}
