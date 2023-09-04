using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Diploma.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "images/Categories/acoustic-guitars-category.jpg");

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price", "QuantityInStock", "SoldQuantity", "StockStatus" },
                values: new object[,]
                {
                    { 1, 1, "", "images/Items/acoustic-guitar-1.jpg", "Martin 000-28 Eric Clapton Signature Auditorium Acoustic Guitar", 3500m, 10, 0, 0 },
                    { 2, 1, "", "images/Items/acoustic-guitar-2.jpg", "Ibanez AW54OPN Artwood Dreadnought Acoustic Guitar", 399m, 20, 0, 0 },
                    { 3, 1, "", "images/Items/acoustic-guitar-3.jpg", "Ibanez Talman TCY10E Acoustic-electric Guitar", 1999m, 17, 0, 0 },
                    { 4, 2, "", "images/Items/electric-guitar-1.jpg", "Jackson JS Series Kelly JS32", 1499m, 20, 0, 0 },
                    { 5, 2, "", "images/Items/electric-guitar-2.jpg", "Jackson JS Series Dinky Arch Top JS22", 1m, 10, 0, 0 },
                    { 6, 3, "", "images/Items/bass-guitar-1.jpg", "Jackson JS Series Spectra Bass JS2", 999m, 23, 0, 0 },
                    { 7, 3, "", "images/Items/bass-guitar-2.jpg", "Ibanez SR Standard 5-String Electric Bass Guitar", 1799m, 7, 0, 0 },
                    { 8, 4, "", "images/Items/drums-1.jpg", "Donner DED-100 Electric Drum Set", 399m, 15, 0, 0 },
                    { 9, 4, "", "images/Items/drums-2.jpg", "Vangoa Acoustic Drum Kit", 899m, 6, 0, 0 },
                    { 10, 5, "", "images/Items/trumpet-1.jpg", "Glory Bb Trumpet", 128m, 12, 0, 0 },
                    { 11, 6, "", "images/Items/violin-1.jpg", "Poseidon Violin", 99m, 15, 0, 0 },
                    { 12, 6, "", "images/Items/violin-2.jpg", "Mendini By Cecilio Violin - MV500+92D", 249m, 6, 0, 0 },
                    { 13, 7, "", "images/Items/piano-1.jpg", "Cossain Digital Piano", 599m, 8, 0, 0 },
                    { 14, 7, "", "images/Items/piano-2.jpg", "FingerBallet Portable Piano Keyboard", 399m, 10, 0, 0 },
                    { 15, 7, "", "images/Items/piano-3.jpg", "MAGICON BX2 88-Key Foldable Electronic Piano", 720m, 10, 0, 0 },
                    { 16, 8, "", "images/Items/synthesizer-1.jpg", "Behringer DeepMind 6 37-Key 6-Voice Analog Synthesizer", 499m, 4, 0, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "images/Categories/acoustic-fuitars-category.jpg");
        }
    }
}
