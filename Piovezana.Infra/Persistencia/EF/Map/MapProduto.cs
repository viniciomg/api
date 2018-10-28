using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Piovezana.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Piovezana.Infra.Persistencia.EF.Map
{
   public class MapProduto :IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Preco).IsRequired();
            builder.Property(x => x.Imagem);
        }

    }
}
