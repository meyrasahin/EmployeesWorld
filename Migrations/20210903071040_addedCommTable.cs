using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeesWorld.Migrations
{
    public partial class addedCommTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Communication_Employees_EmployeeId",
                table: "Communication");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Communication",
                table: "Communication");

            migrationBuilder.RenameTable(
                name: "Communication",
                newName: "Communications");

            migrationBuilder.RenameIndex(
                name: "IX_Communication_EmployeeId",
                table: "Communications",
                newName: "IX_Communications_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Communications",
                table: "Communications",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Communications_Employees_EmployeeId",
                table: "Communications",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Communications_Employees_EmployeeId",
                table: "Communications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Communications",
                table: "Communications");

            migrationBuilder.RenameTable(
                name: "Communications",
                newName: "Communication");

            migrationBuilder.RenameIndex(
                name: "IX_Communications_EmployeeId",
                table: "Communication",
                newName: "IX_Communication_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Communication",
                table: "Communication",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Communication_Employees_EmployeeId",
                table: "Communication",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
