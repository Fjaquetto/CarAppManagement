using Car.App.Management.Domain.Models;
using Car.App.Management.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Car.App.Management.Infra.Data.Context
{
    public class CarAppContext : DbContext
    {
        public CarAppContext(DbContextOptions<CarAppContext> options) : base(options) { }

        public DbSet<Carro> Carros { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CarroMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
