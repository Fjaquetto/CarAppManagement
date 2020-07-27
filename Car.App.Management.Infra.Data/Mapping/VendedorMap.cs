using Car.App.Management.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Car.App.Management.Infra.Data.Mapping
{
    public class VendedorMap : IEntityTypeConfiguration<Vendedor>
    {
        public void Configure(EntityTypeBuilder<Vendedor> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)")
                .HasMaxLength(200);

            builder.Property(c => c.ValorVendido)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(c => c.ComissaoMesAtual)
                .HasColumnType("decimal(18,2)");

            // 1 : N => Vendedor : Carro
            builder.HasMany(x => x.Carros)
                .WithOne(x => x.Vendedor)
                .HasForeignKey(x => x.VendedorId);

            // 1 : N => Vendedor : Cliente
            builder.HasMany(x => x.Clientes)
                .WithOne(x => x.Vendedor)
                .HasForeignKey(x => x.VendedorId);

            builder.ToTable("Vendedores");
        }
    }
}
