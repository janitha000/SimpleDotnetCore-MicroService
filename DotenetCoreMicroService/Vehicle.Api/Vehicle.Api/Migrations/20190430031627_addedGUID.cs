using Microsoft.EntityFrameworkCore.Migrations;

namespace Vehicle.Api.Migrations
{
    public partial class addedGUID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Items",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GUID",
                table: "Items",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GUID",
                table: "Drivers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GUID",
                table: "Categories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GUID",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "GUID",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "GUID",
                table: "Categories");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Items",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
