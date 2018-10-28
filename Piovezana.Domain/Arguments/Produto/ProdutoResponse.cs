namespace Piovezana.Domain.Arguments.Produto
{
    public class ProdutoResponse
    {

        public string Nome { get; set; }
        public float Preco { get; set; }
        public string Imagem { get; set; }

        public static explicit operator ProdutoResponse(Entities.Produto entidade)
        {

            return new ProdutoResponse()
            {
                Nome = entidade.Nome,
                Preco = entidade.Preco,
                Imagem = entidade.Imagem
            };
        }
    }
}
