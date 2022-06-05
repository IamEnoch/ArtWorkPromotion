using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtWorkPromotion.API.Migrations
{
    public partial class ChangesToUserSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                schema: "Security",
                table: "AppUsers",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                schema: "Security",
                table: "AppUsers",
                newName: "Location");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                schema: "Security",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                schema: "Security",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "Security",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                schema: "Security",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "Brand",
                schema: "Security",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "Security",
                table: "AppUsers");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "Security",
                table: "AppUsers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Location",
                schema: "Security",
                table: "AppUsers",
                newName: "FirstName");
        }
    }
}
