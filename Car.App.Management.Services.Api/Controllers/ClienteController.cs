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
    [ApiController]
    [Authorize]
    [Route("api/clientes")]
    public class ClienteController : ApiController
    {
        private readonly IClienteAppService _clienteAppService;

        public ClienteController(IClienteAppService clienteAppService,
                                IUser user) : base(user)
        {
            _clienteAppService = clienteAppService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    success = false,
                    errors = ModelState
                });
            }

            await _clienteAppService.Adicionar(clienteViewModel);

            return Ok(clienteViewModel);
        }

        [HttpGet]
        public async Task<List<ClienteViewModel>> Get()
        {
            return await _clienteAppService.ObterTodos();
        }

        [HttpGet("{id:int}")]
        public async Task<ClienteViewModel> Get(int id)
        {
            return await _clienteAppService.ObterPorId(id);
        }

        [HttpDelete("{id:int}")]
        public async Task<bool> Delete(int id)
        {
            return await _clienteAppService.Remover(id);
        }
    }
}