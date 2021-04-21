

using LojaApi.Entity;
using LojaApi.Interface;
using LojaApi.Servico;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace LojaApi.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoService _produtoService;
        

        public ProdutoController(ProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

       

        [HttpGet]
        public ActionResult<List<Produto>> Get()
        {
           return _produtoService.Get();
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
