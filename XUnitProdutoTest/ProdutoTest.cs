using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitProdutoTest
{
    public class ProdutoTest
    {
        public ProdutoTest()
        {
            var server = new TestServer(new HwebHostBuilder().UserStartup<Startup>)
        }
    }
}
