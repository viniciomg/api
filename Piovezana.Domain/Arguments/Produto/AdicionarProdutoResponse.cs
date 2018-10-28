using System;
using System.Collections.Generic;
using System.Text;

namespace Piovezana.Domain.Arguments.Produto
{
   public class AdicionarProdutoResponse
    {
        public AdicionarProdutoResponse(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
       
    }
}
