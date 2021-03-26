using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArtGallery.Migrations
{
    public partial class NewModelsAndPostChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "PostImage",
                table: "Post",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(MAX)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Caption",
                table: "Post",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "PostImage",
                table: "Post",
                type: "varbinary(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(byte[]),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Caption",
                table: "Post",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 1000);
        }
    }
}
