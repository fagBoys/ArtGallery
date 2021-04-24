using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArtGallery.Migrations
{
    public partial class DateInComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
             name: "Date",
             table: "Comment",
             nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
