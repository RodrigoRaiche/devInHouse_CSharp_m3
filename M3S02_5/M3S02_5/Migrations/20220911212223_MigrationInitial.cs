using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace M3S02_5.Migrations
{
    public partial class MigrationInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    ApiKey = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "ApiKey", "Ativo", "Nome" },
                values: new object[] { new Guid("3ff37ac0-75bb-4dc9-9cc8-b5259d01088a"), "9306B9F1F2B6DB2B2762913D96F0DF4E", true, "Cliente X" });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "ApiKey", "Ativo", "Nome" },
                values: new object[] { new Guid("adc6e73f-0f0a-4acf-97ed-b40af27b108b"), "47933C60BF8A9A41255A86D184B109D3", false, "Cliente Z" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
