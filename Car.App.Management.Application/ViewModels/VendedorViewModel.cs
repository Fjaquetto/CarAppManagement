using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Car.App.Management.Application.ViewModels
{
    public class VendedorViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "É necessário especificar o valor de compra do carro.")]
        [DisplayName("Valor Vendido")]
        public decimal ValorVendido { get; set; }

        [Required(ErrorMessage = "É necessário especificar o valor de compra do carro.")]
        [DisplayName("Valor Vendido")]
        public decimal ComissaoMesAtual { get; set; }
    }
}
