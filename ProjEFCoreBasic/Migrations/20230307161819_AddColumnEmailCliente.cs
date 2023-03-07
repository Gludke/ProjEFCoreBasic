using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjEFCoreBasic.Migrations
{
    public partial class AddColumnEmailCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Cliente",
                type: "VARCHAR(80)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Cliente");
        }
    }
}
