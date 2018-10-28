using System;

namespace Piovezana.Domain.Arguments.Usuario
{
    public   class AdicionarUsuarioResponse
    {
        public AdicionarUsuarioResponse(Guid id)
        {
            Id = id;
        }
        //response ao cadastrar o  usuario é o id dele.
        public Guid Id { get; set; }
    }
}
