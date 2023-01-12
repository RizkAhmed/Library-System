using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryCRUD.Migrations
{
    public partial class AuthorData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DateOfBirth",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Authors",
                type: "nvarchar(2500)",
                maxLength: 2500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Authors",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Authors");
        }
    }
}
