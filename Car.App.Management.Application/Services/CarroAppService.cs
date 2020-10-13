using AutoMapper;
using Car.App.Management.Application.Interfaces;
using Car.App.Management.Application.ViewModels;
using Car.App.Management.Domain.Interfaces;
using Car.App.Management.Domain.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Car.App.Management.Application.Services
{
    public class CarroAppService : ICarroAppService
    {
        private readonly IMapper _mapper;
        private readonly ICarroRepository _carroRepository;

        public CarroAppService(ICarroRepository carroRepository, IMapper mapper)
        {
            _carroRepository = carroRepository;
            _mapper = mapper;
        }

        public async Task<List<CarroViewModel>> ObterTodos()
        {
            return _mapper.Map<List<CarroViewModel>>(await _carroRepository.ObterTodos());
        }
        public async Task<bool> Adicionar(CarroViewModel carroViewModel)
        {
            if (carroViewModel.DataVenda != null)           
                carroViewModel.Vendido = true;          
            else           
                carroViewModel.Vendido = false;
            
            await _carroRepository.Adicionar(_mapper.Map<Carro>(carroViewModel));
            return true;
        }

        public async Task<bool> Atualizar(CarroViewModel carroViewModel)
        {
            await _carroRepository.Atualizar(_mapper.Map<Carro>(carroViewModel));
            return true;
        }

        public async Task<bool> Remover(int id)
        {
            await _carroRepository.Remover(id);
            return true;
        }

        public async Task<CarroViewModel> ObterPorId(int id)
        {
            return _mapper.Map<CarroViewModel>(await _carroRepository.ObterPorId(id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
