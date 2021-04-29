using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.Migrations
{
    public partial class AddNewSeedValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Department", "Email", "Gender", "Name", "Phone", "statelist" },
                values: new object[] { 2, 1, "john@techspace.com.ng", 0, "John", "08067013148", 0 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Department", "Email", "Gender", "Name", "Phone", "statelist" },
                values: new object[] { 3, 2, "mary@techspace.com.ng", 1, "Mary", "08067013148", 3 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Department", "Email", "Gender", "Name", "Phone", "statelist" },
                values: new object[] { 4, 4, "abiodun@techspace.com.ng", 0, "Abiodun", "08067013148", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
