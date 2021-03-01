using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomerManagement.DAL.Migrations
{
    public partial class UpdateSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phone_Emails_EmailID",
                table: "Phone");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Phone",
                table: "Phone");

            migrationBuilder.EnsureSchema(
                name: "customer");

            migrationBuilder.RenameTable(
                name: "Emails",
                newName: "Emails",
                newSchema: "customer");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customers",
                newSchema: "customer");

            migrationBuilder.RenameTable(
                name: "Phone",
                newName: "Phones",
                newSchema: "customer");

            migrationBuilder.RenameIndex(
                name: "IX_Phone_EmailID",
                schema: "customer",
                table: "Phones",
                newName: "IX_Phones_EmailID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Phones",
                schema: "customer",
                table: "Phones",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_Emails_EmailID",
                schema: "customer",
                table: "Phones",
                column: "EmailID",
                principalSchema: "customer",
                principalTable: "Emails",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phones_Emails_EmailID",
                schema: "customer",
                table: "Phones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Phones",
                schema: "customer",
                table: "Phones");

            migrationBuilder.RenameTable(
                name: "Emails",
                schema: "customer",
                newName: "Emails");

            migrationBuilder.RenameTable(
                name: "Customers",
                schema: "customer",
                newName: "Customers");

            migrationBuilder.RenameTable(
                name: "Phones",
                schema: "customer",
                newName: "Phone");

            migrationBuilder.RenameIndex(
                name: "IX_Phones_EmailID",
                table: "Phone",
                newName: "IX_Phone_EmailID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Phone",
                table: "Phone",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Phone_Emails_EmailID",
                table: "Phone",
                column: "EmailID",
                principalTable: "Emails",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
