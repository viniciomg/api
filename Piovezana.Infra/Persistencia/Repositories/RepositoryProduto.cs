using Piovezana.Domain.Entities;
using Piovezana.Domain.Interfaces.Repositories;
using Piovezana.Infra.Persistencia.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piovezana.Infra.Persistencia.Repositories
{
    public class RepositoryProduto : IRepositoryProduto
    {
        private readonly PiovezanaContexto _contexto;

        public RepositoryProduto(PiovezanaContexto contexto)
        {
            _contexto = contexto;
        }

        public void Adicionar(Produto produto)
        {
            _contexto.Produtos.Add(produto);
        }

        public IEnumerable<Produto> Listar(string nome)
        {
            return _contexto.Produtos.Where(x => x.Nome == nome).ToList();
        }

        public IEnumerable<Produto> ListarTodos(Produto produto)
        {
            var response = produto;
            return _contexto.Produtos.ToList();
        }
    }
}
