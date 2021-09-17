using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeesWorld.Migrations
{
    public partial class someChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AdminId",
                table: "Admins",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Admins",
                newName: "AdminId");
        }
    }
}
