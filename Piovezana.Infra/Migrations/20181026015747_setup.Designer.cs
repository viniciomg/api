﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Piovezana.Infra.Persistencia.EF;

namespace Piovezana.Infra.Migrations
{
    [DbContext(typeof(PiovezanaContexto))]
    [Migration("20181026015747_setup")]
    partial class setup
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Piovezana.Domain.Entities.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Imagem");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<float>("Preco");

                    b.HasKey("Id");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("Piovezana.Domain.Entities.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(36);

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Piovezana.Domain.Entities.Usuario", b =>
                {
                    b.OwnsOne("Piovezana.Domain.ObjectValue.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("UsuarioId");

                            b1.Property<string>("Endereco")
                                .IsRequired()
                                .HasColumnName("Email")
                                .HasMaxLength(200);

                            b1.ToTable("Usuario");

                            b1.HasOne("Piovezana.Domain.Entities.Usuario")
                                .WithOne("Email")
                                .HasForeignKey("Piovezana.Domain.ObjectValue.Email", "UsuarioId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Piovezana.Domain.ObjectValue.Nome", "Nome", b1 =>
                        {
                            b1.Property<Guid>("UsuarioId");

                            b1.Property<string>("PrimeiroNome")
                                .IsRequired()
                                .HasColumnName("PrimeiroNome")
                                .HasMaxLength(50);

                            b1.Property<string>("UltimoNome")
                                .IsRequired()
                                .HasColumnName("UltimoNome")
                                .HasMaxLength(50);

                            b1.ToTable("Usuario");

                            b1.HasOne("Piovezana.Domain.Entities.Usuario")
                                .WithOne("Nome")
                                .HasForeignKey("Piovezana.Domain.ObjectValue.Nome", "UsuarioId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
