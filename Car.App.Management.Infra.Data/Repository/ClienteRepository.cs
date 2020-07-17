using Car.App.Management.Domain.Interfaces;
using Car.App.Management.Domain.Models;
using Car.App.Management.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.App.Management.Infra.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(CarAppContext context)
            : base(context)
        {

        }

        public async Task<int> AdicionarClienteEndereco(Cliente cliente)
        {
            DbSet.Add(cliente);
            await SaveChanges();

            return DbSet.AsNoTracking().OrderByDescending(x => x.Id).FirstOrDefaultAsync().Result.Id;
        }

        public async Task<List<Cliente>> ObterTodosClientes()
        {
            return await DbSet.AsNoTracking().Include(x => x.Endereco).ToListAsync();
        }
    }
}
