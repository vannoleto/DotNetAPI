using Xunit;
using MinhaApi.Repositories;
using MinhaApi.Models;
using Moq;
using System.Collections.Generic;

namespace MinhaApi.Testes.Repositories
{
    public class MeuRepositorioTestes
    {
        private readonly MeuRepositorio _repositorio;
        private readonly Mock<IMeuRepositorio> _mockRepositorio;

        public MeuRepositorioTestes()
        {
            _mockRepositorio = new Mock<IMeuRepositorio>();
            _repositorio = new MeuRepositorio(_mockRepositorio.Object);
        }

        [Fact]
        public void Adicionar_DeveAdicionarModelo()
        {
            var modelo = new MeuModelo { Id = 1, Nome = "Teste" };
            _mockRepositorio.Setup(r => r.Adicionar(modelo)).Returns(modelo);

            var resultado = _repositorio.Adicionar(modelo);

            Assert.NotNull(resultado);
            Assert.Equal(modelo.Nome, resultado.Nome);
        }

        [Fact]
        public void BuscarPorId_DeveRetornarModeloExistente()
        {
            var modelo = new MeuModelo { Id = 1, Nome = "Teste" };
            _mockRepositorio.Setup(r => r.BuscarPorId(1)).Returns(modelo);

            var resultado = _repositorio.BuscarPorId(1);

            Assert.NotNull(resultado);
            Assert.Equal(modelo.Nome, resultado.Nome);
        }

        [Fact]
        public void Atualizar_DeveAtualizarModelo()
        {
            var modelo = new MeuModelo { Id = 1, Nome = "Teste" };
            _mockRepositorio.Setup(r => r.Atualizar(modelo)).Returns(modelo);

            var resultado = _repositorio.Atualizar(modelo);

            Assert.NotNull(resultado);
            Assert.Equal(modelo.Nome, resultado.Nome);
        }

        [Fact]
        public void Remover_DeveRemoverModelo()
        {
            var modelo = new MeuModelo { Id = 1, Nome = "Teste" };
            _mockRepositorio.Setup(r => r.Remover(modelo.Id)).Returns(true);

            var resultado = _repositorio.Remover(modelo.Id);

            Assert.True(resultado);
        }
    }
}