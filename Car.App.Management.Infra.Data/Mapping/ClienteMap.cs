using Car.App.Management.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Car.App.Management.Infra.Data.Mapping
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.Nascimento)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(x => x.Telefone)
                .HasColumnType("varchar(14)")
                .IsRequired();

            builder.Property(x => x.CPF)
                .HasColumnType("varchar(14)")
                .IsRequired();

            // 1 : 1 => Cliente : Endereco
            builder.HasOne(x => x.Endereco)
                .WithOne(x => x.Cliente);

            // 1 : N => Cliente : Carro
            builder.HasMany(x => x.Carros)
                .WithOne(x => x.Cliente)
                .HasForeignKey(x => x.ClienteId);

            builder.ToTable("Clientes");

        }
    }
}
