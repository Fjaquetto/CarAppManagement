using System;
using System.Collections.Generic;
using System.Text;

namespace Car.App.Management.Domain.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }
        public Endereco Endereco { get; set; }

        /* EF Relations */
        public ICollection<Carro> Carros { get; set; }
    }
}
