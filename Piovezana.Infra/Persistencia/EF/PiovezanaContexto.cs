using Microsoft.EntityFrameworkCore;
using Piovezana.Domain.Entities;
using Piovezana.Domain.ObjectValue;
using Piovezana.Infra.Persistencia.EF.Map;
using Piovezana.Shared;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Piovezana.Infra.Persistencia.EF
{
    public class PiovezanaContexto :DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Settings.ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //ignorar Classes
            modelBuilder.Ignore<Notification>();
            modelBuilder.Ignore<Nome>();
            modelBuilder.Ignore<Email>();

            //Aplicar Configurações 

            modelBuilder.ApplyConfiguration(new MapUsuario());
            modelBuilder.ApplyConfiguration(new MapProduto());
       

            base.OnModelCreating(modelBuilder);

        }
    }
}
