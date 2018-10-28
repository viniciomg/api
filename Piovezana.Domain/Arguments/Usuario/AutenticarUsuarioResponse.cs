using System;
using System.Collections.Generic;
using System.Text;
using Piovezana.Domain.Entities;

namespace Piovezana.Domain.Arguments.Usuario
{
    public class AutenticarUsuarioResponse
    {
      

        public Guid Id { get; set; }
        public String PrimeiroNome { get; set; }

        public static explicit operator AutenticarUsuarioResponse(Entities.Usuario entidade)
        {
            return new AutenticarUsuarioResponse()
            {
                Id = entidade.Id,
                PrimeiroNome = entidade.Nome.PrimeiroNome

            };
        }
    }
}
