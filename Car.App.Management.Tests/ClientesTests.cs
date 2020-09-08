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
    public class ClientesTests
    {
        private readonly ClienteAppService _clienteAppService;
        private readonly Mock<IClienteRepository> _clienteRepositoryMock = new Mock<IClienteRepository>();
        private readonly Mock<IEnderecoRepository> _enderecoRepositoryMock = new Mock<IEnderecoRepository>();
        private readonly Mock<IMapper> _iMapperMock = new Mock<IMapper>();

        public ClientesTests()
        {
            _clienteAppService = new ClienteAppService(_clienteRepositoryMock.Object, _enderecoRepositoryMock.Object, _iMapperMock.Object);
        }

        [Fact]
        public async Task AdicionarClienteEEndereco()
        {
            var clienteViewModel = new ClienteViewModel
            {
                Nome = "Teste Teste Teste",
                Nascimento = new DateTime(2020, 02, 22),
                Telefone = "(11)99888-1111",
                CPF = "111.111.111-11",
                EnderecoViewModel = new EnderecoViewModel 
                {
                    Rua = "Rua Teste Teste Teste",
                    Numero = "111",
                    Complemento = null,
                    Bairro = "Bairro Teste",
                    Cep = "03922-200",
                    Cidade = "São Paulo",
                    Estado = "SP",
                    ClienteId = 0
                },
            };

            _clienteRepositoryMock.Setup(x => x.Adicionar(It.IsAny<Cliente>())).Returns(Task.CompletedTask);

            Assert.True(await _clienteAppService.Adicionar(clienteViewModel));
        }

        [Fact]
        public async Task AtualizarEnderecoCliente()
        {
            var clienteViewModel = new ClienteViewModel
            {
                Nome = "Teste Teste Teste",
                Nascimento = new DateTime(2020, 02, 22),
                Telefone = "(11)99888-1111",
                CPF = "111.111.111-11",
                EnderecoViewModel = new EnderecoViewModel
                {
                    Rua = "Rua Teste Teste Teste",
                    Numero = "111",
                    Complemento = null,
                    Bairro = "Bairro Teste",
                    Cep = "03922-200",
                    Cidade = "São Paulo",
                    Estado = "SP",
                    ClienteId = 0
                },
            };

            _clienteRepositoryMock.Setup(x => x.Atualizar(It.IsAny<Cliente>())).Returns(Task.CompletedTask);

            Assert.True(await _clienteAppService.Atualizar(clienteViewModel));
        }
    }
}
