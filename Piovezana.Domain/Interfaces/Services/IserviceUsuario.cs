using Piovezana.Domain.Arguments.Usuario;
using Piovezana.Domain.Interfaces.Services.Base;

namespace Piovezana.Domain.Interfaces.Services
{
    public interface IserviceUsuario :IserviceBase

    {
        AdicionarUsuarioResponse AdicionarUsuario(AdicionarUsuarioRequest request);
        AutenticarUsuarioResponse AutenticarUsuario(AutenticarUsuarioRequest request);
    }
}
