using Microsoft.EntityFrameworkCore.Migrations;

namespace Radisson.Domain.Migrations
{
    public partial class PeopleFixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservePeopleCloud_Peoples_PeopleId",
                table: "ReservePeopleCloud");

            migrationBuilder.AlterColumn<int>(
                name: "PeopleId",
                table: "ReservePeopleCloud",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PeopleFirst",
                table: "ReservePeopleCloud",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PeopleSecond",
                table: "ReservePeopleCloud",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PeopleThird",
                table: "ReservePeopleCloud",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservePeopleCloud_Peoples_PeopleId",
                table: "ReservePeopleCloud",
                column: "PeopleId",
                principalTable: "Peoples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservePeopleCloud_Peoples_PeopleId",
                table: "ReservePeopleCloud");

            migrationBuilder.DropColumn(
                name: "PeopleFirst",
                table: "ReservePeopleCloud");

            migrationBuilder.DropColumn(
                name: "PeopleSecond",
                table: "ReservePeopleCloud");

            migrationBuilder.DropColumn(
                name: "PeopleThird",
                table: "ReservePeopleCloud");

            migrationBuilder.AlterColumn<int>(
                name: "PeopleId",
                table: "ReservePeopleCloud",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservePeopleCloud_Peoples_PeopleId",
                table: "ReservePeopleCloud",
                column: "PeopleId",
                principalTable: "Peoples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
