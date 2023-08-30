using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diploma.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class _3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryInformationId",
                table: "Orders",
                column: "DeliveryInformationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_DeliveryInformations_DeliveryInformationId",
                table: "Orders",
                column: "DeliveryInformationId",
                principalTable: "DeliveryInformations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_DeliveryInformations_DeliveryInformationId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DeliveryInformationId",
                table: "Orders");
        }
    }
}
