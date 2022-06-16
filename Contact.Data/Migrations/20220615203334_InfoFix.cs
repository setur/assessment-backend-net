using Microsoft.EntityFrameworkCore.Migrations;

namespace Contact.Data.Migrations
{
    public partial class InfoFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Info_People_PersonId",
                table: "Info");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "Info",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Info_People_PersonId",
                table: "Info",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Info_People_PersonId",
                table: "Info");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "Info",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Info_People_PersonId",
                table: "Info",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
