using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaApi.Interface
{
    public interface IProdutosDatabaseSettings
    {
        string ProdutoCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
