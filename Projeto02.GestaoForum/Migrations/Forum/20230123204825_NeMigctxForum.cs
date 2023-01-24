using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto02.GestaoForum.Migrations.Forum
{
    public partial class NeMigctxForum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FORUM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Responsavel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FORUM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "USUARIO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "COMENTARIOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDFORUM = table.Column<int>(type: "int", nullable: false),
                    IDUSUARIO = table.Column<int>(type: "int", nullable: false),
                    COMENTARIO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMENTARIOS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_COMENTARIOS_FORUM_IDFORUM",
                        column: x => x.IDFORUM,
                        principalTable: "FORUM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_COMENTARIOS_USUARIO_IDUSUARIO",
                        column: x => x.IDUSUARIO,
                        principalTable: "USUARIO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_COMENTARIOS_IDFORUM",
                table: "COMENTARIOS",
                column: "IDFORUM");

            migrationBuilder.CreateIndex(
                name: "IX_COMENTARIOS_IDUSUARIO",
                table: "COMENTARIOS",
                column: "IDUSUARIO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "COMENTARIOS");

            migrationBuilder.DropTable(
                name: "FORUM");

            migrationBuilder.DropTable(
                name: "USUARIO");
        }
    }
}
