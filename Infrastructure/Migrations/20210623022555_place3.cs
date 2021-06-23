using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class place3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings history_Places_FromPlace",
                table: "Bookings history");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings history_Places_ToPlace",
                table: "Bookings history");

            migrationBuilder.DropIndex(
                name: "IX_Bookings history_FromPlace",
                table: "Bookings history");

            migrationBuilder.DropIndex(
                name: "IX_Bookings history_ToPlace",
                table: "Bookings history");

            migrationBuilder.AddColumn<int>(
                name: "FPlacePlaceId",
                table: "Bookings history",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TPlacePlaceId",
                table: "Bookings history",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings history_FPlacePlaceId",
                table: "Bookings history",
                column: "FPlacePlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings history_TPlacePlaceId",
                table: "Bookings history",
                column: "TPlacePlaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings history_Places_FPlacePlaceId",
                table: "Bookings history",
                column: "FPlacePlaceId",
                principalTable: "Places",
                principalColumn: "PlaceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings history_Places_TPlacePlaceId",
                table: "Bookings history",
                column: "TPlacePlaceId",
                principalTable: "Places",
                principalColumn: "PlaceId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings history_Places_FPlacePlaceId",
                table: "Bookings history");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings history_Places_TPlacePlaceId",
                table: "Bookings history");

            migrationBuilder.DropIndex(
                name: "IX_Bookings history_FPlacePlaceId",
                table: "Bookings history");

            migrationBuilder.DropIndex(
                name: "IX_Bookings history_TPlacePlaceId",
                table: "Bookings history");

            migrationBuilder.DropColumn(
                name: "FPlacePlaceId",
                table: "Bookings history");

            migrationBuilder.DropColumn(
                name: "TPlacePlaceId",
                table: "Bookings history");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings history_FromPlace",
                table: "Bookings history",
                column: "FromPlace");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings history_ToPlace",
                table: "Bookings history",
                column: "ToPlace");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings history_Places_FromPlace",
                table: "Bookings history",
                column: "FromPlace",
                principalTable: "Places",
                principalColumn: "PlaceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings history_Places_ToPlace",
                table: "Bookings history",
                column: "ToPlace",
                principalTable: "Places",
                principalColumn: "PlaceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
