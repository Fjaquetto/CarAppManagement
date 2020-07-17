using Car.App.Management.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.App.Management.Domain.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        public Task<int> AdicionarClienteEndereco(Cliente cliente);
        public Task<List<Cliente>> ObterTodosClientes();
    }
}
