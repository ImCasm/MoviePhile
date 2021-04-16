using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddForeignKeyPubComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "PublicationComments",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PublicationComments_AspNetUsers_UserId1",
                table: "PublicationComments");

            migrationBuilder.DropIndex(
                name: "IX_PublicationComments_UserId1",
                table: "PublicationComments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PublicationComments");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "PublicationComments");
        }
    }
}
