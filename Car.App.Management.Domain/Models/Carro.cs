using System;
using System.Collections.Generic;
using System.Text;

namespace Car.App.Management.Domain.Models
{
    public class Carro
    {
        public int Id { get; set; }
        public int? ClienteId { get; set; }
        public int? VendedorId { get; set; }

        public string Modelo { get; set; }
        public string Cor { get; set; }
        public string Ano { get; set; }
        public string Placa { get; set; }
        public string Renavam { get; set; }
        public string Descricao { get; set; }
        public decimal ValorComprado { get; set; }
        public decimal? ValorVenda { get; set; }
        public decimal? DebitoPendente { get; set; }
        public DateTime DataCompra { get; set; }
        public DateTime? DataVenda { get; set; }
        public bool IpvaPago { get; set; }
        public bool Vendido { get; set; }

        /* EF Relations */
        public Cliente Cliente { get; set; }
        public Vendedor Vendedor { get; set; }
    }
}
