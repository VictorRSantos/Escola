using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Escola.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class campoExcluidoEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Excluido",
                table: "Usuario",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Excluido",
                table: "Turma",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Excluido",
                table: "Nota",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Excluido",
                table: "Matricula",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Excluido",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Excluido",
                table: "Turma");

            migrationBuilder.DropColumn(
                name: "Excluido",
                table: "Nota");

            migrationBuilder.DropColumn(
                name: "Excluido",
                table: "Matricula");
        }
    }
}
