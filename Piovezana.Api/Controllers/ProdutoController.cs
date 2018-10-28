using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Piovezana.Domain.Arguments.Produto;
using Piovezana.Domain.Entities;
using Piovezana.Domain.Interfaces.Services;
using Piovezana.Infra.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uol.PagSeguro.Domain;

namespace Piovezana.Api.Controllers
{
    public class ProdutoController :Base.ControllerBase
    {
        private readonly IserviceProduto _serviceProduto;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProdutoController(IunitOfWork iunitOfWork, IserviceProduto serviceProduto, IHttpContextAccessor httpContextAccessor):base(iunitOfWork)
        {
            _serviceProduto = serviceProduto;
            _httpContextAccessor = httpContextAccessor;
        }


      

        [AllowAnonymous]
        [HttpGet]
        [Route("api/v1/Produto/Listar/{nome}")]
        public async Task<IActionResult> Listar(string nome)
        {
            try
            {

                var response = _serviceProduto.Listar(nome);
                return await ResponseAsync(response, _serviceProduto);

            }
            catch (Exception ex)
            {

                return await ResponseExceptionAsync(ex);
            }
        }

       
        [AllowAnonymous]
        [HttpPost]
        [Route("api/v1/Produto/Adicionar")]
        public async Task<IActionResult> Adicionar([FromBody]AdicionarProdutoRequest request)
        {
            try
            {
                var response = _serviceProduto.AdicionarProduto(request);
                return await ResponseAsync(response, _serviceProduto);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

    }
}
