using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartAdmin.WebUI.Migrations
{
    /// <inheritdoc />
    public partial class UpdFuncionario2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "FuncionarioId", "Departamento", "Email", "Nome" },
                values: new object[] { 1, 1, "carlos.itdeveloper@gmail.com", "Carlos Alberto" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Funcionarios",
                keyColumn: "FuncionarioId",
                keyValue: 1);
        }
    }
}
