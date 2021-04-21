using LojaApi.Entity;
using LojaApi.Interface;
using LojaApi.Servico;
using LojaApiApiTests2.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Xunit;


namespace LojaApi.Controller.Tests
{
    public class ProdutoControllerTests
    {
        [Route("[controller]")]
        [ApiController]
        [Collection("ActorProjectCollection")]
        public class ProdutoControllerTest : ControllerBase
        {
            private readonly ProdutoService _produtoService;
            

            public ProdutoControllerTest(ProdutoService produtoService)
            {
                _produtoService = produtoService;
            }



            [HttpGet]
            [Fact]
            public ActionResult<List<Produto>> Get()
            {
                var result =  _produtoService.Get();
                Assert.True(result == null, "Ok");
                return result;

            }

            [HttpPost]
            public ActionResult<Produto> Create([FromBody] Produto produto)
            {
                try
                {
                    _produtoService.Create(produto);
                    return Ok("ok");

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            [HttpGet("{id}")]
            public ActionResult<Produto> GetById(string id)
            {
                return _produtoService.GetById(id);
            }
            [HttpDelete("{id}")]
            public IActionResult DeleteProduto(string id)
            {
                var result = _produtoService.GetById(id);
                if (result == null)
                {
                    return NotFound();
                }
                _produtoService.DeleteProduto(result.Id);
                return Ok();
            }

            [HttpPut("{id}")]
            public IActionResult AlterarProduto(string id, Produto produto)
            {
                var result = _produtoService.GetById(id);
                if (result == null)
                {
                    return NotFound();
                }
                _produtoService.Update(result.Id, produto);
                return Ok();
            }

        }

    }
}