using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICOFFE.Migrations
{
    public partial class Discovermenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiscoverMenu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstHrefName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstHrefURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscoverMenu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiscoverMenuImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageNameInFileSystem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscoverMenuId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscoverMenuImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiscoverMenuImages_DiscoverMenu_DiscoverMenuId",
                        column: x => x.DiscoverMenuId,
                        principalTable: "DiscoverMenu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DiscoverMenu",
                columns: new[] { "Id", "Content", "CreatedAt", "FirstHrefName", "FirstHrefURL", "Title", "UpdatedAt" },
                values: new object[] { 1, "Far far away, behind the word mountains", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "View Full Menu", "#", "Discover OUR MENU", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_DiscoverMenuImages_DiscoverMenuId",
                table: "DiscoverMenuImages",
                column: "DiscoverMenuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiscoverMenuImages");

            migrationBuilder.DropTable(
                name: "DiscoverMenu");
        }
    }
}
