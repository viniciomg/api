using Piovezana.Domain.Arguments.Usuario;
using Piovezana.Domain.Entities;
using Piovezana.Domain.Interfaces.Repositories;
using Piovezana.Domain.Interfaces.Services;
using Piovezana.Domain.ObjectValue;
using Piovezana.Domain.Resource;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;

namespace Piovezana.Domain.Services
{
    public class ServiceUsuario : Notifiable, IserviceUsuario
    {
        private readonly IRepositoryUsuario _repositoryUsuario;

        public ServiceUsuario(IRepositoryUsuario repositoryUsuario)
        {
            _repositoryUsuario = repositoryUsuario;
        }

        public AdicionarUsuarioResponse AdicionarUsuario(AdicionarUsuarioRequest request)
        {
            if (request == null)
            {
                AddNotification("AdicionaUsuarioRequest", MSG.OBJETO_X0_E_OBRIGATORIO.ToFormat("AdicionarUsuarioRequest"));
            }

            Nome nome = new Nome(request.PrimeiroNome, request.UltimoNome);
            Email email = new Email(request.Email);
            Usuario usuario = new Usuario(nome,email , request.Senha);

            AddNotifications(usuario);

            if (this.IsInvalid())
            {
                return null;
            }

            //persiste no banco de dados

            _repositoryUsuario.Salvar(usuario);

            return new AdicionarUsuarioResponse(usuario.Id);
        }


        public AutenticarUsuarioResponse AutenticarUsuario(AutenticarUsuarioRequest request)
        {
            if (request == null)
            {
                AddNotification("AutenticarUsuarioRequest", MSG.OBJETO_X0_E_OBRIGATORIO.ToFormat("AutenticarUsuarioResquest"));
                return null;
            }

            var email = new Email(request.Email);
            var usuario = new Usuario(email, request.Senha);

            AddNotifications(usuario);

            if (this.IsInvalid()) { return null; }
             


            usuario = _repositoryUsuario.Obter(usuario.Email.Endereco, usuario.Senha);

            if(usuario ==null)
            {
                AddNotification("Usuario", MSG.DADOS_NAO_ENCONTRADOS);
                return null;
            }
            //converter entidade por cash   em autenticarUsuarioResponse
            var response = (AutenticarUsuarioResponse)usuario;
            return response;
        }
    }
}

