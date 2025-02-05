using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MinhaApi.Controllers;
using MinhaApi.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinhaApi.Testes.Controllers
{
    [TestClass]
    public class MeuControllerTestes
    {
        private MeuController _controller;
        private Mock<IMeuServico> _servicoMock;

        [TestInitialize]
        public void Configurar()
        {
            _servicoMock = new Mock<IMeuServico>();
            _controller = new MeuController(_servicoMock.Object);
        }

        [TestMethod]
        public async Task ObterTodos_DeveRetornarLista()
        {
            // Arrange
            var listaEsperada = new List<MeuModelo>();
            _servicoMock.Setup(s => s.ObterTodos()).ReturnsAsync(listaEsperada);

            // Act
            var resultado = await _controller.ObterTodos();

            // Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(listaEsperada, resultado);
        }

        [TestMethod]
        public async Task Criar_DeveRetornarSucesso()
        {
            // Arrange
            var modelo = new MeuModelo();
            _servicoMock.Setup(s => s.Criar(modelo)).ReturnsAsync(true);

            // Act
            var resultado = await _controller.Criar(modelo);

            // Assert
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public async Task Atualizar_DeveRetornarSucesso()
        {
            // Arrange
            var modelo = new MeuModelo();
            _servicoMock.Setup(s => s.Atualizar(modelo)).ReturnsAsync(true);

            // Act
            var resultado = await _controller.Atualizar(modelo);

            // Assert
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public async Task Excluir_DeveRetornarSucesso()
        {
            // Arrange
            var id = 1;
            _servicoMock.Setup(s => s.Excluir(id)).ReturnsAsync(true);

            // Act
            var resultado = await _controller.Excluir(id);

            // Assert
            Assert.IsTrue(resultado);
        }
    }
}