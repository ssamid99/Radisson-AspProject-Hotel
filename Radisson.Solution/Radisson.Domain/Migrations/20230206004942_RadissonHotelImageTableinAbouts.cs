using Microsoft.EntityFrameworkCore.Migrations;

namespace Radisson.Domain.Migrations
{
    public partial class RadissonHotelImageTableinAbouts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RadissonHotelImage_RadissonHotels_RadissonHotelsId",
                table: "RadissonHotelImage");

            migrationBuilder.DropForeignKey(
                name: "FK_RadissonHotelImage_Users_CreatedByUserId",
                table: "RadissonHotelImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RadissonHotelImage",
                table: "RadissonHotelImage");

            migrationBuilder.RenameTable(
                name: "RadissonHotelImage",
                newName: "RadissonHotelImages");

            migrationBuilder.RenameIndex(
                name: "IX_RadissonHotelImage_RadissonHotelsId",
                table: "RadissonHotelImages",
                newName: "IX_RadissonHotelImages_RadissonHotelsId");

            migrationBuilder.RenameIndex(
                name: "IX_RadissonHotelImage_CreatedByUserId",
                table: "RadissonHotelImages",
                newName: "IX_RadissonHotelImages_CreatedByUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RadissonHotelImages",
                table: "RadissonHotelImages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RadissonHotelImages_RadissonHotels_RadissonHotelsId",
                table: "RadissonHotelImages",
                column: "RadissonHotelsId",
                principalTable: "RadissonHotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RadissonHotelImages_Users_CreatedByUserId",
                table: "RadissonHotelImages",
                column: "CreatedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RadissonHotelImages_RadissonHotels_RadissonHotelsId",
                table: "RadissonHotelImages");

            migrationBuilder.DropForeignKey(
                name: "FK_RadissonHotelImages_Users_CreatedByUserId",
                table: "RadissonHotelImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RadissonHotelImages",
                table: "RadissonHotelImages");

            migrationBuilder.RenameTable(
                name: "RadissonHotelImages",
                newName: "RadissonHotelImage");

            migrationBuilder.RenameIndex(
                name: "IX_RadissonHotelImages_RadissonHotelsId",
                table: "RadissonHotelImage",
                newName: "IX_RadissonHotelImage_RadissonHotelsId");

            migrationBuilder.RenameIndex(
                name: "IX_RadissonHotelImages_CreatedByUserId",
                table: "RadissonHotelImage",
                newName: "IX_RadissonHotelImage_CreatedByUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RadissonHotelImage",
                table: "RadissonHotelImage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RadissonHotelImage_RadissonHotels_RadissonHotelsId",
                table: "RadissonHotelImage",
                column: "RadissonHotelsId",
                principalTable: "RadissonHotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RadissonHotelImage_Users_CreatedByUserId",
                table: "RadissonHotelImage",
                column: "CreatedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
