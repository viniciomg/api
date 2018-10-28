using Piovezana.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Piovezana.Domain.Interfaces.Repositories
{
    public interface IRepositoryProduto
    {
        void Adicionar(Produto produto);
        IEnumerable<Produto> Listar(string nome);
        


    }
}
