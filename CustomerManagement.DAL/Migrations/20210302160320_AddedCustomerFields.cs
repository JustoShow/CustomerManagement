using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomerManagement.DAL.Migrations
{
    public partial class AddedCustomerFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "customer",
                table: "Customers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                schema: "customer",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                schema: "customer",
                table: "Customers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "customer",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Notes",
                schema: "customer",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                schema: "customer",
                table: "Customers");
        }
    }
}
