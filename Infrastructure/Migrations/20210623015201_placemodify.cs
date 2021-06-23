using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class placemodify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Places_PlaceId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings history_Places_PlaceId",
                table: "Bookings history");

            migrationBuilder.DropIndex(
                name: "IX_Bookings history_PlaceId",
                table: "Bookings history");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_PlaceId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "PlaceId",
                table: "Bookings history");

            migrationBuilder.DropColumn(
                name: "PlaceId",
                table: "Bookings");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings history_FromPlace",
                table: "Bookings history",
                column: "FromPlace");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings history_ToPlace",
                table: "Bookings history",
                column: "ToPlace");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_FromPlace",
                table: "Bookings",
                column: "FromPlace");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ToPlace",
                table: "Bookings",
                column: "ToPlace");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Places_FromPlace",
                table: "Bookings",
                column: "FromPlace",
                principalTable: "Places",
                principalColumn: "PlaceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Places_ToPlace",
                table: "Bookings",
                column: "ToPlace",
                principalTable: "Places",
                principalColumn: "PlaceId",
                onDelete: ReferentialAction.Cascade);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Places_FromPlace",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Places_ToPlace",
                table: "Bookings");

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

            migrationBuilder.DropIndex(
                name: "IX_Bookings_FromPlace",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_ToPlace",
                table: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "PlaceId",
                table: "Bookings history",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlaceId",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings history_PlaceId",
                table: "Bookings history",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_PlaceId",
                table: "Bookings",
                column: "PlaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Places_PlaceId",
                table: "Bookings",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "PlaceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings history_Places_PlaceId",
                table: "Bookings history",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "PlaceId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
