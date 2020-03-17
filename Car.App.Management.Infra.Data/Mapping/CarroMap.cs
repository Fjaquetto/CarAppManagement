using Car.App.Management.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Car.App.Management.Infra.Data.Mapping
{
    public class CarroMap : IEntityTypeConfiguration<Carro>
    {
        public void Configure(EntityTypeBuilder<Carro> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Modelo)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(c => c.Cor)
                .HasColumnType("varchar(50)")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(c => c.Ano)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(c => c.Placa)
                .HasColumnType("varchar(13)")
                .HasMaxLength(13)
                .IsRequired();

            builder.Property(c => c.Descricao)
                .HasColumnType("varchar(200)")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(c => c.ValorComprado)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(c => c.ValorVenda)
                .HasColumnType("decimal(18,2)");

            builder.Property(c => c.DataCompra)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(c => c.DataVenda)
                .HasColumnType("datetime");

            builder.Property(c => c.IpvaPago)
                .HasColumnType("bit")
                .IsRequired();

            builder.Property(c => c.Vendido)
                .HasColumnType("bit")
                .IsRequired();

            builder.ToTable("Carros");
                
        }
    }
}
