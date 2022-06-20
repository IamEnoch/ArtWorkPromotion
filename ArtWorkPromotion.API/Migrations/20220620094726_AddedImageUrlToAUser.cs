using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtWorkPromotion.API.Migrations
{
    public partial class AddedImageUrlToAUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserImageUrl",
                schema: "Security",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserImageUrl",
                schema: "Security",
                table: "AppUsers");
        }
    }
}
