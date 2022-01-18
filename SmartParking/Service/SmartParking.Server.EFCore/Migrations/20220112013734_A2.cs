using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartParking.Server.EFCore.Migrations
{
    public partial class A2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "_id",
                table: "sys_user_info",
                newName: "user_id");

            migrationBuilder.AddColumn<string>(
                name: "user_icon",
                table: "sys_user_info",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "user_icon",
                table: "sys_user_info");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "sys_user_info",
                newName: "_id");
        }
    }
}
