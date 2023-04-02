using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Radisson.Domain.Migrations
{
    public partial class FixAbout : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RadissonHotelImages");

            migrationBuilder.AddColumn<string>(
                name: "FullText",
                table: "RadissonHotels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "RadissonHotels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullText",
                table: "RadissonHotels");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "RadissonHotels");

            migrationBuilder.CreateTable(
                name: "RadissonHotelImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RadissonHotelsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RadissonHotelImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RadissonHotelImages_RadissonHotels_RadissonHotelsId",
                        column: x => x.RadissonHotelsId,
                        principalTable: "RadissonHotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RadissonHotelImages_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "Membership",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RadissonHotelImages_CreatedByUserId",
                table: "RadissonHotelImages",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RadissonHotelImages_RadissonHotelsId",
                table: "RadissonHotelImages",
                column: "RadissonHotelsId");
        }
    }
}
