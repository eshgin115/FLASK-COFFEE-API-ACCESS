using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICOFFE.Migrations
{
    public partial class ShortInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShortInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlaceInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortеTitleStreet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TitleStreet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkingHoursByDay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoursOfWork = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShortInfo", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ShortInfo",
                columns: new[] { "Id", "CreatedAt", "HoursOfWork", "PhoneNumber", "PlaceInfo", "ShortеTitleStreet", "TitleStreet", "UpdatedAt", "WorkingHoursByDay" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "8:00am - 9:00pm", "000 (123) 456 7890", "A small river named Duden flows by their place and supplies.", "198 West 21th Street", "203 Fake St. Mountain View, San Francisco, California, USA", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Open Monday-Friday" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShortInfo");
        }
    }
}
