using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Newslify.Migrations
{
    /// <inheritdoc />
    public partial class modificarsavednewentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Source",
                table: "AppSavedNews");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "AppSavedNews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "PublishedAt",
                table: "AppSavedNews",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UrlToImage",
                table: "AppSavedNews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "AppSavedNews");

            migrationBuilder.DropColumn(
                name: "PublishedAt",
                table: "AppSavedNews");

            migrationBuilder.DropColumn(
                name: "UrlToImage",
                table: "AppSavedNews");

            migrationBuilder.AddColumn<string>(
                name: "Source",
                table: "AppSavedNews",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");
        }
    }
}
