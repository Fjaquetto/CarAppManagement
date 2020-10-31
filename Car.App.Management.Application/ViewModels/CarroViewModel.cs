using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Car.App.Management.Application.ViewModels
{
    public class CarroViewModel
    {
        [Key]
        public int Id { get; set; }

        public int? ClienteId { get; set; }
        public int? VendedorId { get; set; }

        [Required(ErrorMessage = "É necessário especificar o modelo do carro.")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Modelo")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "É necessário especificar a cor do carro.")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Cor")]
        public string Cor { get; set; }

        [Required(ErrorMessage = "É necessário especificar o ano de fabricação do carro.")]
        [MinLength(9, ErrorMessage = "É necessário que o campo contenha 9 caracteres.")]
        [MaxLength(9, ErrorMessage = "É necessário que o campo contenha 9 caracteres.")]
        [DisplayName("Ano de Fabricação")]
        public string Ano { get; set; }

        [Required(ErrorMessage = "É necessário especificar a placa do carro.")]
        [MinLength(8, ErrorMessage = "É necessário que o campo contenha 8 caracteres.")]
        [MaxLength(8, ErrorMessage = "É necessário que o campo contenha 8 caracteres.")]
        [DisplayName("Placa")]
        public string Placa { get; set; }

        [MinLength(11, ErrorMessage = "É necessário que o campo contenha 11 caracteres.")]
        [MaxLength(11, ErrorMessage = "É necessário que o campo contenha 11 caracteres.")]
        [Required(ErrorMessage = "É necessário especificar a placa do carro.")]
        public string Renavam { get; set; }

        [Required(ErrorMessage = "É necessário especificar uma descrição para o carro.")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "É necessário especificar o valor de compra do carro.")]
        //[RegularExpression(@"^\d+\.\d{0,2}$")]
        [DisplayName("Valor de Compra")]
        public decimal ValorComprado { get; set; }

        //[RegularExpression(@"^\d+\.\d{0,2}$")]
        [DisplayName("Valor de Venda")]
        public decimal? ValorVenda { get; set; }

        [DisplayName("Débito Pendente")]
        public decimal? DebitoPendente { get; set; }

        [DisplayName("Despesas")]
        public decimal? Despesas { get; set; }

        [Required(ErrorMessage = "É necessário especificar a data de compra do carro.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido.")]
        [DisplayName("Data de Compra")]
        public DateTime DataCompra { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido.")]
        [DisplayName("Data de Venda")]
        public DateTime? DataVenda { get; set; }

        [Required(ErrorMessage = "É necessário informar se o IPVA já foi pago.")]
        [DisplayName("IPVA")]
        public bool IpvaPago { get; set; }

        [Required(ErrorMessage = "É necessário informar se o carro já foi vendido.")]
        [DisplayName("Vendido")]
        public bool Vendido { get; set; }
    }
}
