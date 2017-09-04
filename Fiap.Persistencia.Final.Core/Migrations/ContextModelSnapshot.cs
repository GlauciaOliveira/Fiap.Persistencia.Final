using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Fiap.Persistencia.Final.Core.Data;

namespace Fiap.Persistencia.Final.Core.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Fiap.Persistencia.Final.Core.Models.Eventos", b =>
                {
                    b.Property<int>("IdEvento")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataEvento");

                    b.Property<string>("Localizacao");

                    b.Property<string>("NomeEvento");

                    b.Property<string>("Observacao");

                    b.Property<int?>("VersaoIdVersao");

                    b.HasKey("IdEvento");

                    b.HasIndex("VersaoIdVersao");

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
                    b.HasOne("Fiap.Persistencia.Final.Core.Models.Versao", "Versao")
                        .WithMany("Eventos")
                        .HasForeignKey("VersaoIdVersao");
                });
        }
    }
}
