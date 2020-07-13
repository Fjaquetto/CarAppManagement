using Car.App.Management.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Car.App.Management.Application.Interfaces
{
    public interface IClienteAppService : IDisposable
    {
        Task<bool> Adicionar(ClienteViewModel carroViewModel);
        Task<bool> Atualizar(ClienteViewModel carro);
        Task<bool> Remover(int id);
        Task<List<ClienteViewModel>> ObterTodos();
    }
}
