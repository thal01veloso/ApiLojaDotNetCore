using LojaApi.Entity;
using LojaApi.Interface;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaApi.Servico
{
    public class ProdutoService
    {
        private readonly IMongoCollection<Produto> _produtos;
        public ProdutoService(IProdutosDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _produtos = database.GetCollection<Produto>(settings.ProdutoCollectionName);
        }
        public List<Produto> Get() =>
            _produtos.Find(produto => true).ToList();
        public Produto Create(Produto produto)
        {
            _produtos.InsertOne(produto);
            return produto;
        }
        public Produto GetById(string id)
        {
            var result = _produtos.Find<Produto>(produto =>

                produto.Id == id
              ).FirstOrDefault();
            return result;
        }

        public void DeleteProduto(string id)
        {
            _produtos.DeleteOne(produto => produto.Id == id);

        }
        public void Update(string id, Produto produtos)
        {
            _produtos.ReplaceOne(p => p.Id == id, produtos);
        
        }

    }
}
