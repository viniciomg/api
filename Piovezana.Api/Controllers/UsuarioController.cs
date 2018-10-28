using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Piovezana.Api.Security;
using Piovezana.Domain.Arguments.Usuario;
using Piovezana.Domain.Interfaces.Services;
using Piovezana.Infra.Transactions;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Piovezana.Api.Controllers
{
    public class UsuarioController : Base.ControllerBase
    {
        private readonly IserviceUsuario _serviceUsuario;

        public UsuarioController(IunitOfWork unitOfWork, IserviceUsuario serviceUsuario) : base(unitOfWork)
        {
            _serviceUsuario = serviceUsuario;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("api/v1/Usuario/Adicionar")]

        public async Task<IActionResult> Adicionar([FromBody]AdicionarUsuarioRequest resquest)
        {
            try
            {
                var response = _serviceUsuario.AdicionarUsuario(resquest);
                return await ResponseAsync(response, _serviceUsuario);

            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);

            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/v1/Usuario/Autenticar")]
        public object Autenticar(
            [FromBody]AutenticarUsuarioRequest request,
            [FromServices]SigningConfigurations signingConfigurations,
            [FromServices]TokenConfigurations tokenConfigurations)
        {
            bool credenciaisValidas = false;
            AutenticarUsuarioResponse response = _serviceUsuario.AutenticarUsuario(request);

            credenciaisValidas = response != null;

            if (credenciaisValidas)
            {
                //claims onde guarda suas informações dentro do toke, par apoder usar novamente
                //instancia de um Clain
                ClaimsIdentity identity = new ClaimsIdentity(
                    //guardando o id do  usuario
                    new GenericIdentity(response.Id.ToString(), "Id"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        //new Claim(JwtRegisteredClaimNames.UniqueName, response.Usuario)

                        //cira um jason com  as informações do response 
                        new Claim("Usuario", JsonConvert.SerializeObject(response))
                    }
                );
                //controles de data 
                DateTime dataCriacao = DateTime.Now;
                DateTime dataExpiracao = dataCriacao +
                    TimeSpan.FromSeconds(tokenConfigurations.Seconds);

                //ciracao do token passando as inforamções
                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    //definindo configurações para criação do token
                    Issuer = tokenConfigurations.Issuer,
                    Audience = tokenConfigurations.Audience,
                    SigningCredentials = signingConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = dataCriacao,
                    Expires = dataExpiracao
                });
                var token = handler.WriteToken(securityToken);

                return new
                {
                    message ="ok",
                };
            }
            else
            {
                //caso invalida, vai notificar.
                return new
                {
                    authenticated = false,
                    _serviceUsuario.Notifications
                };
            }
        }
    }
}