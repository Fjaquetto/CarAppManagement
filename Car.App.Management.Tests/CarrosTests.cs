using AutoMapper;
using Car.App.Management.Application.Services;
using Car.App.Management.Application.ViewModels;
using Car.App.Management.Domain.Interfaces;
using Car.App.Management.Domain.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Car.App.Management.Tests
{
    public class CarrosTests
    {
        private readonly CarroAppService _carroAppService;
        private readonly Mock<ICarroRepository> _carroRepositoryMock = new Mock<ICarroRepository>();
        private readonly Mock<IMapper> _iMapperMock = new Mock<IMapper>();

        public CarrosTests()
        {
            _carroAppService = new CarroAppService(_carroRepositoryMock.Object, _iMapperMock.Object);
        }

        [Fact]
        public async Task AdicionarCarro()
        {
            var carroViewModel = new CarroViewModel
            {
                ClienteId = null,
                Modelo = "Corsa",
                Cor = "Preto",
                Ano = new DateTime(2010, 08, 26),
                Placa = "TTT-0122",
                Descricao = "Descrição aqui pf",
                ValorComprado = 10000,
                ValorVenda = 15000,
                DataCompra = new DateTime(2020, 05, 20),
                DataVenda = new DateTime(2020, 06, 20),
                IpvaPago = true,
                Vendido = true                
            };

            var carro = new Carro
            {
                ClienteId = null,
                Modelo = "Corsa",
                Cor = "Preto",
                Ano = new DateTime(2010, 08, 26),
                Placa = "TTT-0122",
                Descricao = "Descrição aqui pf",
                ValorComprado = 10000,
                ValorVenda = 15000,
                DataCompra = new DateTime(2020, 05, 20),
                DataVenda = new DateTime(2020, 06, 20),
                IpvaPago = true,
                Vendido = true
            };

            _carroRepositoryMock.Setup(x => x.Adicionar(carro));

            Assert.True(await _carroAppService.Adicionar(carroViewModel));
        }
    }
}
