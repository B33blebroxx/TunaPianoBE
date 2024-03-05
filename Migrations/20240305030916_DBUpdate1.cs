using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TunaPianoBE.Migrations
{
    public partial class DBUpdate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "Songs",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Songs");
        }
    }
}
