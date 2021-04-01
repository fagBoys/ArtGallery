using Microsoft.EntityFrameworkCore.Migrations;

namespace ArtGallery.Migrations
{
    public partial class IdChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostID",
                table: "Post",
                newName: "PostId");

            migrationBuilder.RenameColumn(
                name: "PrimaryID",
                table: "Following",
                newName: "PrimaryId");

            migrationBuilder.RenameColumn(
                name: "AccountID",
                table: "Following",
                newName: "AccountId");

            migrationBuilder.RenameColumn(
                name: "FollowingID",
                table: "Following",
                newName: "FollowingId");

            migrationBuilder.AddColumn<string>(
                name: "AccountId",
                table: "Post",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Post_AccountId",
                table: "Post",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_AspNetUsers_AccountId",
                table: "Post",
                column: "AccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_AspNetUsers_AccountId",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_AccountId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Post");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "Post",
                newName: "PostID");

            migrationBuilder.RenameColumn(
                name: "PrimaryId",
                table: "Following",
                newName: "PrimaryID");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Following",
                newName: "AccountID");

            migrationBuilder.RenameColumn(
                name: "FollowingId",
                table: "Following",
                newName: "FollowingID");
        }
    }
}
