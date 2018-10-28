using Piovezana.Domain.Resource;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Piovezana.Domain.ObjectValue
{
    public class Nome : Notifiable
    {
        protected Nome()
        {
        }
        public Nome(string primeiroNomme, string ultimoNome)
        {
            PrimeiroNome = primeiroNomme;
            UltimoNome = ultimoNome;
            UltimoNome = ultimoNome;
            new AddNotifications<Nome>(this)
                .IfNullOrInvalidLength(x => x.PrimeiroNome, 1, 50, MSG.X0_OBRIGATORIA_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("PrimeiroNome", 1, 50))
            .IfNullOrInvalidLength(x => x.UltimoNome, 1, 50, MSG.X0_OBRIGATORIO_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Últimonome", 1, 50));
        }

        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }

    }
}
