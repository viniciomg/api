using Piovezana.Domain.Arguments.Produto;
using Piovezana.Domain.Entities;
using Piovezana.Domain.Interfaces.Repositories;
using Piovezana.Domain.Interfaces.Services;
using Piovezana.Domain.Resource;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piovezana.Domain.Services
{
    public class ServiceProduto : Notifiable, IserviceProduto
    {
        private readonly IRepositoryProduto _repositoryProduto;

        public ServiceProduto(IRepositoryProduto repositoryProduto)
        {
            _repositoryProduto = repositoryProduto;
        }

        

        public AdicionarProdutoResponse AdicionarProduto(AdicionarProdutoRequest request)
        {
           

            var produto = new Produto(request.Nome, request.preco, request.imagem);
            AddNotifications(produto);

            if (this.IsInvalid()) return null;

            _repositoryProduto.Adicionar(produto);

            return new AdicionarProdutoResponse(produto.Id);
        }

        

        public IEnumerable<ProdutoResponse> Listar(string nome)
        {

            IEnumerable<Produto> ProdutoColletion = _repositoryProduto.Listar(nome);
            var response = ProdutoColletion.ToList().Select(entidade => (ProdutoResponse)entidade);
            return response;

        }

     
    }
}
