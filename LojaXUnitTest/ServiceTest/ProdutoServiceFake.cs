using LojaApi.Entity;
using LojaApi.Interface;
using LojaApi.Servico;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaXUnitTest
{
    public class ProdutoServiceFake : ProdutoService
    {
        
        private readonly List<Produto> _produto;
        public ProdutoServiceFake()
        {
            _produto = new List<Produto>()
            {
                new Produto(){Id="60704dfe2a61121b28ac536z",Nome="MousePad",Preco=18,Quantidade=1},
                new Produto(){Id="60704dfe2a61121b28ac536x",Nome="CaboUSB",Preco=50,Quantidade=1}
            };
        }
        public IEnumerable<Produto> GetAllItems()
        {
            return _produto;
        }
        public Produto Add(Produto novoItem)
        {

            _produto.Add(novoItem);
            return novoItem;
        }




    }






}

