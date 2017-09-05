using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Fiap.Persistencia.Final.Core.Migrations
{
    public partial class Primeira : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBVersao",
                columns: table => new
                {
                    IdVersao = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataAtualizacao = table.Column<string>(nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBVersao", x => x.IdVersao);
                });

            migrationBuilder.CreateTable(
                name: "TBEventos",
                columns: table => new
                {
                    IdEvento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataEvento = table.Column<DateTime>(nullable: false),
                    IdVersao = table.Column<int>(nullable: false),
                    Localizacao = table.Column<string>(nullable: true),
                    NomeEvento = table.Column<string>(nullable: true),
                    Observacao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBEventos", x => x.IdEvento);
                    table.ForeignKey(
                        name: "FK_TBEventos_TBVersao_IdVersao",
                        column: x => x.IdVersao,
                        principalTable: "TBVersao",
                        principalColumn: "IdVersao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBEventos_IdVersao",
                table: "TBEventos",
                column: "IdVersao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBEventos");

            migrationBuilder.DropTable(
                name: "TBVersao");
        }
    }
}
