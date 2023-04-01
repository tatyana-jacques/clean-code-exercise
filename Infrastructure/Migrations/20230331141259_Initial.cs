using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    permission = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.id);
                    table.ForeignKey(
                        name: "FK_Employee_Permission_permission",
                        column: x => x.permission,
                        principalTable: "Permission",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Employee" },
                    { 2, "Manager" },
                    { 3, "Administrator" }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "id", "email", "name", "password", "permission", "salary" },
                values: new object[,]
                {
                    { 1, "funcionario@glass.com.br", "Funcionário", "funcionario123", 1, 12546.00m },
                    { 2, "gerente@glass.com.br", "Gerente", "gerente123", 2, 23453.89m },
                    { 3, "administrador@glass.com.br", "Administrador", "adm123", 3, 36453.34m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_permission",
                table: "Employee",
                column: "permission");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Permission");
        }
    }
}
