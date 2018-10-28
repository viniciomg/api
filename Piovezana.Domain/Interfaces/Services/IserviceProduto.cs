using Piovezana.Domain.Arguments.Produto;
using Piovezana.Domain.Entities;
using Piovezana.Domain.Interfaces.Services.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Piovezana.Domain.Interfaces.Services
{
  public  interface IserviceProduto :IserviceBase
    {
        AdicionarProdutoResponse AdicionarProduto(AdicionarProdutoRequest request);
        IEnumerable<ProdutoResponse> Listar(string nome);
        

      

    
    }
}
