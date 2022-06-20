using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtWorkPromotion.API.Migrations
{
    public partial class ArtImageUrlAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StoragePath",
                table: "Arts",
                newName: "ArtImageUrl");

            migrationBuilder.CreateTable(
                name: "Social",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WhatsApp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Facebook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instagram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pintrest = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Social", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Social_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalSchema: "Security",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Social_AppUserId",
                table: "Social",
                column: "AppUserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Social");

            migrationBuilder.RenameColumn(
                name: "ArtImageUrl",
                table: "Arts",
                newName: "StoragePath");
        }
    }
}
