using Piovezana.Domain.Entities.Base;
using Piovezana.Domain.Resource;
using prmToolkit.NotificationPattern;

namespace Piovezana.Domain.Entities
{
    public class Produto :EntityBase,INotifiable
    {
        protected Produto()
        {

        }
        public Produto(string nome, float preco, string imagem)
        {
            Nome = nome;
            Preco = preco;
            Imagem = imagem;
            new AddNotifications<Produto>(this)
            .IfNullOrInvalidLength(x => x.Nome, 3, 50)
            .IfNullOrInvalidLength(x => x.Imagem, 1, 500)
            .IfNullOrWhiteSpace(x=>x.Imagem);
        }

      

        public string Nome { get;private set; }
        public float Preco { get; private set; }
        public string Imagem { get; private set; }


    }
}
