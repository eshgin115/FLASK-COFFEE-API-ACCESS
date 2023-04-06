using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICOFFE.Migrations
{
    public partial class Food_and_Create_Table_Relation_With_Food : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FoodId",
                table: "BasketProducts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuantityDrink",
                table: "BasketProducts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuantityFood",
                table: "BasketProducts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SizeId",
                table: "BasketProducts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsVegan = table.Column<bool>(type: "bit", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ingredients = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodSizes",
                columns: table => new
                {
                    FoodId = table.Column<int>(type: "int", nullable: false),
                    SizeId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodSizes", x => new { x.FoodId, x.SizeId });
                    table.ForeignKey(
                        name: "FK_FoodSizes_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodSizes_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodTags",
                columns: table => new
                {
                    FoodId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodTags", x => new { x.FoodId, x.TagId });
                    table.ForeignKey(
                        name: "FK_FoodTags_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlantImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageNameInFileSystem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    FoodId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlantImages_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasketProducts_FoodId",
                table: "BasketProducts",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketProducts_SizeId",
                table: "BasketProducts",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodSizes_SizeId",
                table: "FoodSizes",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodTags_TagId",
                table: "FoodTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantImages_FoodId",
                table: "PlantImages",
                column: "FoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketProducts_Foods_FoodId",
                table: "BasketProducts",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketProducts_Sizes_SizeId",
                table: "BasketProducts",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketProducts_Foods_FoodId",
                table: "BasketProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_BasketProducts_Sizes_SizeId",
                table: "BasketProducts");

            migrationBuilder.DropTable(
                name: "FoodSizes");

            migrationBuilder.DropTable(
                name: "FoodTags");

            migrationBuilder.DropTable(
                name: "PlantImages");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropIndex(
                name: "IX_BasketProducts_FoodId",
                table: "BasketProducts");

            migrationBuilder.DropIndex(
                name: "IX_BasketProducts_SizeId",
                table: "BasketProducts");

            migrationBuilder.DropColumn(
                name: "FoodId",
                table: "BasketProducts");

            migrationBuilder.DropColumn(
                name: "QuantityDrink",
                table: "BasketProducts");

            migrationBuilder.DropColumn(
                name: "QuantityFood",
                table: "BasketProducts");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "BasketProducts");
        }
    }
}
