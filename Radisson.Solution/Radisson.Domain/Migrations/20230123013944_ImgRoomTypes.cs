using Microsoft.EntityFrameworkCore.Migrations;

namespace Radisson.Domain.Migrations
{
    public partial class ImgRoomTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "RoomTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "RoomTypes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "RoomTypes");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "RoomTypes");
        }
    }
}
