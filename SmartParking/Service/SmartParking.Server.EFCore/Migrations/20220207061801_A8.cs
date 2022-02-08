using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartParking.Server.EFCore.Migrations
{
    public partial class A8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "state",
                table: "sys_user_info",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "state",
                table: "sys_user_info");
        }
    }
}
