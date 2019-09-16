using Microsoft.EntityFrameworkCore.Migrations;

namespace Northwind.Entities.Migrations
{
    public partial class AddedEmployeeMiddleName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "Employees",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "Employees");
        }
    }
}
