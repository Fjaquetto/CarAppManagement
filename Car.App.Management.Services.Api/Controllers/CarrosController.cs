using Car.App.Management.Application.Interfaces;
using Car.App.Management.Application.ViewModels;
using Car.App.Management.Domain.Interfaces;
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

        public CarrosController(ICarroAppService carroAppService,
                                IUser user) : base(user)
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
                    errors = ModelState
                });
            }

            await _carroAppService.Adicionar(carroViewModel);

            return Ok(carroViewModel);
        }

        [HttpGet]
        public async Task<List<CarroViewModel>> Get()
        {
            return await _carroAppService.ObterTodos();
        }

        [HttpGet("{id:int}")]
        public async Task<CarroViewModel> Get(int id)
        {
            return await _carroAppService.ObterPorId(id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(CarroViewModel carroViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    success = false,
                    errors = ModelState
                });
            }

            await _carroAppService.Atualizar(carroViewModel);

            return Ok(carroViewModel);
        }

        [HttpDelete("{id:int}")]
        public async Task<bool> Delete(int id)
        {
            return await _carroAppService.Remover(id);
        }
    }
}