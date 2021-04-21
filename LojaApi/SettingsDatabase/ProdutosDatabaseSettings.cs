using LojaApi.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaApi.SettingsDatabase
{
    public class ProdutosDatabaseSettings : IProdutosDatabaseSettings
    {
        public string ProdutoCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        
    }
}
