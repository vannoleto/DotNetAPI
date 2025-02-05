using Xunit;
using Moq;
using MinhaApi.Services.Interfaces;
using MinhaApi.Models;
using MinhaApi.Repositories.Interfaces;

namespace MinhaApi.Testes.Services
{
    public class MeuServicoTestes
    {
        private readonly Mock<IMeuRepositorio> _repositorioMock;
        private readonly IMeuServico _meuServico;

        public MeuServicoTestes()
        {
            _repositorioMock = new Mock<IMeuRepositorio>();
            _meuServico = new MeuServico(_repositorioMock.Object);
        }

        [Fact]
        public void Criar_DeveAdicionarModelo()
        {
            var modelo = new MeuModelo { Id = 1, Nome = "Teste" };

            _repositorioMock.Setup(r => r.Adicionar(modelo)).Returns(modelo);

            var resultado = _meuServico.Criar(modelo);

            Assert.NotNull(resultado);
            Assert.Equal(modelo.Nome, resultado.Nome);
            _repositorioMock.Verify(r => r.Adicionar(modelo), Times.Once);
        }

        [Fact]
        public void Obter_DeveRetornarModeloPorId()
        {
            var modelo = new MeuModelo { Id = 1, Nome = "Teste" };

            _repositorioMock.Setup(r => r.BuscarPorId(1)).Returns(modelo);

            var resultado = _meuServico.Obter(1);

            Assert.NotNull(resultado);
            Assert.Equal(modelo.Nome, resultado.Nome);
            _repositorioMock.Verify(r => r.BuscarPorId(1), Times.Once);
        }

        [Fact]
        public void Atualizar_DeveModificarModeloExistente()
        {
            var modelo = new MeuModelo { Id = 1, Nome = "Teste Atualizado" };

            _repositorioMock.Setup(r => r.Atualizar(modelo)).Returns(modelo);

            var resultado = _meuServico.Atualizar(modelo);

            Assert.NotNull(resultado);
            Assert.Equal(modelo.Nome, resultado.Nome);
            _repositorioMock.Verify(r => r.Atualizar(modelo), Times.Once);
        }

        [Fact]
        public void Excluir_DeveRemoverModeloPorId()
        {
            var modeloId = 1;

            _repositorioMock.Setup(r => r.Remover(modeloId)).Returns(true);

            var resultado = _meuServico.Excluir(modeloId);

            Assert.True(resultado);
            _repositorioMock.Verify(r => r.Remover(modeloId), Times.Once);
        }
    }
}