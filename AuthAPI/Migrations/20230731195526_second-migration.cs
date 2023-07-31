using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AuthAPI.Migrations
{
    /// <inheritdoc />
    public partial class secondmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FavoriteFruits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FruitName = table.Column<string>(type: "TEXT", nullable: false),
                    FruitColor = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteFruits", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "FavoriteFruits",
                columns: new[] { "Id", "FruitColor", "FruitName" },
                values: new object[,]
                {
                    { 1, "Orange", "Orange" },
                    { 2, "Green", "PawPaw" },
                    { 3, "Red", "Strawberry" },
                    { 4, "Green", "Mango" },
                    { 5, "Yellow", "Pineapple" },
                    { 6, "Green", "Apple" },
                    { 7, "Green", "Watermelon" },
                    { 8, "Yellow", "Banana" },
                    { 9, "Green", "Avocado" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteFruits");
        }
    }
}
