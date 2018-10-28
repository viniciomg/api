using Piovezana.Domain.Resource;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Piovezana.Domain.ObjectValue
{
  public  class Email : Notifiable
    {
        public Email(string endereco)
        {
            Endereco = endereco;

            new AddNotifications<Email>(this)
         .IfNotEmail(x => x.Endereco, MSG.X0_INVALIDA.ToFormat("E-Mail"));


        }

        public string Endereco { get; private set; }
    }
}
