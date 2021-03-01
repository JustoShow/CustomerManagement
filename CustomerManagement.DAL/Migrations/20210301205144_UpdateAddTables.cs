using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomerManagement.DAL.Migrations
{
    public partial class UpdateAddTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Emails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Emails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Emails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MailAddress",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MailCity",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MailState",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MailZipCode",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "Customers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Phone",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(nullable: true),
                    EmailID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phone", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Phone_Emails_EmailID",
                        column: x => x.EmailID,
                        principalTable: "Emails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Phone_EmailID",
                table: "Phone",
                column: "EmailID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Phone");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Emails");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Emails");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Emails");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "MailAddress",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "MailCity",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "MailState",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "MailZipCode",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Customers");
        }
    }
}
