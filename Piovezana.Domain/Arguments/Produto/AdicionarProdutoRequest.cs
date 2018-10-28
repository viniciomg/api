using System;
using System.Collections.Generic;
using System.Text;

namespace Piovezana.Domain.Arguments.Produto
{
  public  class AdicionarProdutoRequest
    {
        public String Nome { get; set; }
        public float preco  { get; set; }
        public String imagem { get; set; }

    }
}
