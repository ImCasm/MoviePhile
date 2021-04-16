using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class FixKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PublicationComments_AspNetUsers_UserId1",
                table: "PublicationComments");

            migrationBuilder.DropIndex(
                name: "IX_PublicationComments_UserId1",
                table: "PublicationComments");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "PublicationComments");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "PublicationComments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_PublicationComments_UserId",
                table: "PublicationComments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PublicationComments_AspNetUsers_UserId",
                table: "PublicationComments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PublicationComments_AspNetUsers_UserId",
                table: "PublicationComments");

            migrationBuilder.DropIndex(
                name: "IX_PublicationComments_UserId",
                table: "PublicationComments");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "PublicationComments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "PublicationComments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PublicationComments_UserId1",
                table: "PublicationComments",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PublicationComments_AspNetUsers_UserId1",
                table: "PublicationComments",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
