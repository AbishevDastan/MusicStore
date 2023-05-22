using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Diploma.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ItemVariants",
                columns: new[] { "ItemId", "ItemTypeId", "InitialPrice", "Price" },
                values: new object[,]
                {
                    { 3, 1, 170m, 100m },
                    { 3, 2, 170m, 100m },
                    { 3, 3, 170m, 100m },
                    { 3, 4, 170m, 100m },
                    { 4, 1, 170m, 100m },
                    { 4, 2, 170m, 100m },
                    { 4, 3, 170m, 100m },
                    { 4, 4, 170m, 100m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ItemVariants",
                keyColumns: new[] { "ItemId", "ItemTypeId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "ItemVariants",
                keyColumns: new[] { "ItemId", "ItemTypeId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "ItemVariants",
                keyColumns: new[] { "ItemId", "ItemTypeId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "ItemVariants",
                keyColumns: new[] { "ItemId", "ItemTypeId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "ItemVariants",
                keyColumns: new[] { "ItemId", "ItemTypeId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "ItemVariants",
                keyColumns: new[] { "ItemId", "ItemTypeId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "ItemVariants",
                keyColumns: new[] { "ItemId", "ItemTypeId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "ItemVariants",
                keyColumns: new[] { "ItemId", "ItemTypeId" },
                keyValues: new object[] { 4, 4 });
        }
    }
}
