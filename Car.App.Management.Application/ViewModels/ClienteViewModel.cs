using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Car.App.Management.Application.ViewModels
{
    public class ClienteViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "É necessário especificar o nome do cliente.")]
        [MinLength(2)]
        [MaxLength(200)]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "É necessário especificar a Data de Nascimento do cliente.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido.")]
        [DisplayName("Data de Nascimento")]
        public DateTime Nascimento { get; set; }

        [Required(ErrorMessage = "É necessário especificar o telefone do cliente.")]
        [MinLength(14, ErrorMessage = "É necessário que o campo contenha 14 caracteres.")]
        [MaxLength(14, ErrorMessage = "É necessário que o campo contenha 14 caracteres.")]
        [DisplayName("Telefone")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "É necessário especificar o CPF do cliente.")]
        [MinLength(14)]
        [MaxLength(14)]
        [DisplayName("CPF")]
        public string CPF { get; set; }

        public EnderecoViewModel EnderecoViewModel { get; set; }

    }
}
