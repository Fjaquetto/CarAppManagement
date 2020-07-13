using Car.App.Management.Application.ViewModels;
using Car.App.Management.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Car.App.Management.Application.Interfaces
{
    public interface ICarroAppService : IDisposable
    {
        Task<bool> Adicionar(CarroViewModel carroViewModel);
        Task<bool> Atualizar(CarroViewModel carro);
        Task<bool> Remover(int id);
        Task<CarroViewModel> ObterPorId(int id);
        Task<List<CarroViewModel>> ObterTodos();
    }
}
