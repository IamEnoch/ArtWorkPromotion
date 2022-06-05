using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtWorkPromotion.API.Migrations
{
    public partial class RemoveLoationFromArt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Arts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Arts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
