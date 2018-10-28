using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Uol.PagSeguro.Constants;
using Uol.PagSeguro.Domain;
using Uol.PagSeguro.Domain.Direct;
using Uol.PagSeguro.Exception;
using Uol.PagSeguro.Resources;
using Uol.PagSeguro.Service;

namespace Piovezana.Api.Controllers
{
   
    public class PagSeguroController : Controller
    {
        [AllowAnonymous]
        [HttpPost]
        [Route("api/v1/teste/")]
        public string teste(string teste)
        {

            string conteudoChamada = teste;

            
           



            PagSeguroConfiguration.UrlXmlConfiguration = "/Users/vinic/source/repos/PiovezanaTCC/Piovezana.Api/bin/Debug/netcoreapp2.0/PagSeguroConfig.xml";
            bool isSandbox = false;
            EnvironmentConfiguration.ChangeEnvironment(isSandbox);

            // Instantiate a new checkout
            CreditCardCheckout checkout = new CreditCardCheckout();

            // Sets the payment mode
            checkout.PaymentMode = PaymentMode.DEFAULT;

            // Sets the receiver e-mail should will get paid
            checkout.ReceiverEmail = "vinicio.magalhaes@hotmail.com";

            // Sets the currency
            checkout.Currency = Currency.Brl;

            // Add items
            checkout.Items.Add(new Item("0001", "Notebook Prata", 2, 2000.00m));
            checkout.Items.Add(new Item("0002", "Notebook Rosa", 2, 150.99m));

            // Sets a reference code for this checkout, it is useful to identify this payment in future notifications.
            checkout.Reference = "REF1234";

            // Sets shipping information.
            checkout.Shipping = new Shipping();
            checkout.Shipping.ShippingType = ShippingType.Sedex;
            checkout.Shipping.Cost = 0.00m;
            checkout.Shipping.Address = new Address(
                "BRA",
                "SP",
                "Sao Paulo",
                "Jardim Paulistano",
                "01452002",
                "Av. Brig. Faria Lima",
                "1384",
                "5o andar"
            );

            // Sets shipping information.
            checkout.Billing = new Billing();
            checkout.Billing.Address = new Address(
                "BRA",
                "SP",
                "Sao Paulo",
                "Jardim Paulistano",
                "01452002",
                "Av. Brig. Faria Lima",
                "1384",
                "5o andar"
            );

            // Sets credit card holder information.
            checkout.Holder = new Holder(
                "Holder Name",
                new Phone("11", "56273440"),
                new HolderDocument(Documents.GetDocumentByType("CPF"), "12345678909"),
                "01/10/1980"
            );

            // Sets your customer information.
            // If you using SANDBOX you must use an email @sandbox.pagseguro.com.br
            checkout.Sender = new Sender(
                "Joao Comprador",
                "c56531626835586448388@sandbox.pagseguro.com.br",
                new Phone("11", "56273440")
            );
            checkout.Sender.Hash = "b2806d600653cbb2b195f317ca9a1a58738187a02c05bf7f2280e2076262e73b";
            SenderDocument senderCPF = new SenderDocument(Documents.GetDocumentByType("CPF"), "12345678909");
            checkout.Sender.Documents.Add(senderCPF);

            // Sets a credit card token.
            checkout.Token = "9a476b3a36124756a343712754638c7c";

            //Sets the installments information
            checkout.Installment = new Installment(2, 25.00m, 2);

            // Sets the notification url
            checkout.NotificationURL = "http://www.lojamodelo.com.br";

            try
            {
                AccountCredentials credentials = PagSeguroConfiguration.Credentials(isSandbox);
                Transaction result = TransactionService.CreateCheckout(credentials, checkout);
                Console.WriteLine(result);
                Console.ReadKey();
            }
            catch (PagSeguroServiceException exception)
            {
                Console.WriteLine(exception.Message + "\n");
                foreach (ServiceError element in exception.Errors)
                {
                    Console.WriteLine(element + "\n");
                }
                Console.ReadKey();


                
            }
            return null;

        }

    }

    
}







