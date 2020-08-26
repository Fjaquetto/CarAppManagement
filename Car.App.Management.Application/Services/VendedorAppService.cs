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
    public class VendedorAppService : IVendedorAppService
    {
        private readonly IMapper _mapper;
        private readonly IVendedorRepository _vendedorRepository;

        public VendedorAppService(IVendedorRepository vendedorRepository, IMapper mapper)
        {
            _vendedorRepository = vendedorRepository;
            _mapper = mapper;
        }

        public async Task<List<VendedorViewModel>> ObterTodos()
        {
            return _mapper.Map<List<VendedorViewModel>>(await _vendedorRepository.ObterTodos());
        }
        public async Task<bool> Adicionar(VendedorViewModel vendedorViewModel)
        {
            await _vendedorRepository.Adicionar(_mapper.Map<Vendedor>(vendedorViewModel));
            return true;
        }

        public async Task<bool> Atualizar(VendedorViewModel vendedorViewModel)
        {
            await _vendedorRepository.Atualizar(_mapper.Map<Vendedor>(vendedorViewModel));
            return true;
        }

        public async Task<bool> Remover(int id)
        {
            await _vendedorRepository.Remover(id);
            return true;
        }

        public async Task<VendedorViewModel> ObterPorId(int id)
        {
            return _mapper.Map<VendedorViewModel>(await _vendedorRepository.ObterPorId(id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
