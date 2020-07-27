using System;
using System.Collections.Generic;
using System.Text;

namespace Car.App.Management.Domain.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal ValorVendido { get; set; }
        public decimal ComissaoMesAtual { get; set; }

        /* EF Relations */
        public ICollection<Carro> Carros { get; set; }
        public ICollection<Cliente> Clientes { get; set; }
    }
}
