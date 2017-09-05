using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Fiap.Persistencia.Final.Core.Data;

namespace Fiap.Persistencia.Final.Core.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20170905211119_Primeira")]
    partial class Primeira
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Fiap.Persistencia.Final.Core.Models.Eventos", b =>
                {
                    b.Property<int>("IdEvento")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataEvento");

                    b.Property<int>("IdVersao");

                    b.Property<string>("Localizacao");

                    b.Property<string>("NomeEvento");

                    b.Property<string>("Observacao");

                    b.HasKey("IdEvento");

                    b.HasIndex("IdVersao");

                    b.ToTable("TBEventos");
                });

            modelBuilder.Entity("Fiap.Persistencia.Final.Core.Models.Versao", b =>
                {
                    b.Property<int>("IdVersao")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DataAtualizacao");

                    b.Property<DateTime>("DataCriacao");

                    b.Property<string>("Descricao");

                    b.HasKey("IdVersao");

                    b.ToTable("TBVersao");
                });

            modelBuilder.Entity("Fiap.Persistencia.Final.Core.Models.Eventos", b =>
                {
                    b.HasOne("Fiap.Persistencia.Final.Core.Models.Versao")
                        .WithMany("Eventos")
                        .HasForeignKey("IdVersao")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
