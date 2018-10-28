using System;
using System.Collections.Generic;
using System.Text;

namespace Piovezana.Domain.Arguments.Usuario
{
   public class  AdicionarUsuarioRequest
    {
        public String PrimeiroNome { get; set; }
        public String UltimoNome { get; set; }
        public String Email { get; set; }
        public String Senha { get; set; }


    }
}
