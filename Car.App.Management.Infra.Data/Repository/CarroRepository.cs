using Car.App.Management.Domain.Interfaces;
using Car.App.Management.Domain.Models;
using Car.App.Management.Infra.Data.Context;

namespace Car.App.Management.Infra.Data.Repository
{
    public class CarroRepository : Repository<Carro>, ICarroRepository
    {
        public CarroRepository(CarAppContext context)
            : base(context)
        {

        }
    }
}
