using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Piovezana.Domain.Entities;
using Piovezana.Domain.ObjectValue;
using System;
using System.Collections.Generic;
using System.Text;

namespace Piovezana.Infra.Persistencia.EF.Map
{
    public class MapUsuario : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            //tabela
            builder.ToTable("Usuario");

            //Criar Chave Primaria
            builder.HasKey(x => x.Id);

            // propriedades
            builder.Property(x => x.Senha).HasMaxLength(36).IsRequired();

            //Mapenado objetos de Valor

            builder.OwnsOne<Nome>(x => x.Nome, cb =>
              {
                  cb.Property(x => x.PrimeiroNome).HasMaxLength(50).HasColumnName("PrimeiroNome").IsRequired();
                  cb.Property(x => x.UltimoNome).HasMaxLength(50).HasColumnName("UltimoNome").IsRequired();

              });
            builder.OwnsOne<Email>(x => x.Email, cb =>
            {
                cb.Property(x => x.Endereco).HasMaxLength(200).HasColumnName("Email").IsRequired();
            });

        }
    }
}
