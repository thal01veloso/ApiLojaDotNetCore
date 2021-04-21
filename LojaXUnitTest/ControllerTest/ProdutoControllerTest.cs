using LojaApi.Controller;
using LojaApi.Entity;
using LojaApi.Interface;
using LojaApi.Servico;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LojaXUnitTest.ControllerTest
{
    public class ProdutoControllerTest
    {
        ProdutoController _controller;
        ProdutoService _produtoService;

        public ProdutoControllerTest()
        {
            _produtoService = new ProdutoServiceFake();
            _controller = new ProdutoController(_produtoService);
        }
        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Get();
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.Get().Result as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<Produto>>(okResult.Value);
            Assert.Equal(2, items.Count);
        }
    }
}
