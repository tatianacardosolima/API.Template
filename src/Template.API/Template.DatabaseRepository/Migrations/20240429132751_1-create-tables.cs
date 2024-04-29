using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Template.DatabaseRepository.Migrations
{
    /// <inheritdoc />
    public partial class _1createtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Corretor",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comissao = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    UniqueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    CpfCnpj = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Telefone = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    TipoPessoa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corretor", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Corretor",
                schema: "dbo");
        }
    }
}
