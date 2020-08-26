using Car.App.Management.Domain.Interfaces;
using Car.App.Management.Domain.Models;
using Car.App.Management.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Car.App.Management.Infra.Data.Repository
{
    public class VendedorRepository : Repository<Vendedor>, IVendedorRepository
    {
        public VendedorRepository(CarAppContext context)
            : base(context)
        {
        }
    }
}
