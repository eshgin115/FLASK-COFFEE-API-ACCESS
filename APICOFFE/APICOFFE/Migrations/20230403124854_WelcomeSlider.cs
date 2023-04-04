using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICOFFE.Migrations
{
    public partial class WelcomeSlider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WelcomeSliders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subheading = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageNameInFileSystem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstHrefName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstHrefURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondHrefName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondHrefURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    ForPage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WelcomeSliders", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WelcomeSliders");
        }
    }
}
