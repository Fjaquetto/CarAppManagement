using AutoMapper;
using Car.App.Management.Application.Interfaces;
using Car.App.Management.Application.ViewModels;
using Car.App.Management.Domain.Interfaces;
using Car.App.Management.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Car.App.Management.Application.Services
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly IMapper _mapper;
        private readonly IClienteRepository _clienteRepository;
        private readonly IEnderecoRepository _enderecoRepository;

        public ClienteAppService(IClienteRepository clienteRepository, IEnderecoRepository enderecoRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _enderecoRepository = enderecoRepository;
            _mapper = mapper;
        }

        public async Task<List<ClienteViewModel>> ObterTodos()
        {
            return _mapper.Map<List<ClienteViewModel>>(await _clienteRepository.ObterTodos());
        }
        public async Task<bool> Adicionar(ClienteViewModel clienteViewModel)
        {
            await _clienteRepository.Adicionar(_mapper.Map<Cliente>(clienteViewModel));
            //await _enderecoRepository.Adicionar(_mapper.Map<Endereco>(enderecoViewModel));
            return true;
        }

        public async Task<bool> Atualizar(ClienteViewModel clienteViewModel)
        {
            await _clienteRepository.Atualizar(_mapper.Map<Cliente>(clienteViewModel));
            //await _enderecoRepository.Atualizar(_mapper.Map<Endereco>(enderecoViewModel));
            return true;
        }

        public async Task<bool> Remover(int id)
        {
            await _clienteRepository.Remover(id);
            return true;
        }

        public async Task<ClienteViewModel> ObterPorId(int id)
        {
            return _mapper.Map<ClienteViewModel>(await _clienteRepository.ObterPorId(id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
