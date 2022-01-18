using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartParking.Server.EFCore.Migrations
{
    public partial class A7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "age",
                table: "sys_user_info",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "age",
                table: "sys_user_info");
        }
    }
}
