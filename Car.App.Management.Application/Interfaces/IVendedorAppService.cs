using Car.App.Management.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Car.App.Management.Application.Interfaces
{
    public interface IVendedorAppService : IDisposable
    {
        Task<bool> Adicionar(VendedorViewModel vendedorViewModel);
        Task<bool> Atualizar(VendedorViewModel vendedor);
        Task<bool> Remover(int id);
        Task<VendedorViewModel> ObterPorId(int id);
        Task<List<VendedorViewModel>> ObterTodos();
    }
}
