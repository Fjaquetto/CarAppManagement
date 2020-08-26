using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Car.App.Management.Application.Interfaces;
using Car.App.Management.Application.ViewModels;
using Car.App.Management.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Car.App.Management.Services.Api.Controllers
{
    [Route("api/vendedores")]
    [Authorize]
    [ApiController]
    public class VendedoresController : ApiController
    {
        private readonly IVendedorAppService _vendedorAppService;

        public VendedoresController(IVendedorAppService vendedorAppService,
                                IUser user) : base(user)
        {
            _vendedorAppService = vendedorAppService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(VendedorViewModel vendedorViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    success = false,
                    errors = ModelState
                });
            }

            await _vendedorAppService.Adicionar(vendedorViewModel);

            return Ok(vendedorViewModel);
        }

        [HttpGet]
        public async Task<List<VendedorViewModel>> Get()
        {
            return await _vendedorAppService.ObterTodos();
        }

        [HttpGet("{id:int}")]
        public async Task<VendedorViewModel> Get(int id)
        {
            return await _vendedorAppService.ObterPorId(id);
        }

        [HttpDelete("{id:int}")]
        public async Task<bool> Delete(int id)
        {
            return await _vendedorAppService.Remover(id);
        }
    }
}
