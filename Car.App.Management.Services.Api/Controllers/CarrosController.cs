using Car.App.Management.Application.Interfaces;
using Car.App.Management.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Car.App.Management.Services.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/veiculos")]
    public class CarrosController : ApiController
    {
        private readonly ICarroAppService _carroAppService;

        public CarrosController(ICarroAppService carroAppService)
        {
            _carroAppService = carroAppService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CarroViewModel carroViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    success = false,
                    errors = "Modelo de entrada inválido."
                });
            }

            await _carroAppService.Adicionar(carroViewModel);

            return Ok(carroViewModel);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<List<CarroViewModel>> Get()
        {
            return await _carroAppService.ObterTodos();
        }
    }
}