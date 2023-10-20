using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Newslify.Migrations
{
    /// <inheritdoc />
    public partial class relationswithuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userId",
                table: "AppLogReadNews",
                newName: "UserId");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "AppReadingLists",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_AppReadingLists_UserId",
                table: "AppReadingLists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppLogReadNews_UserId",
                table: "AppLogReadNews",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppLogReadNews_AbpUsers_UserId",
                table: "AppLogReadNews",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppReadingLists_AbpUsers_UserId",
                table: "AppReadingLists",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppLogReadNews_AbpUsers_UserId",
                table: "AppLogReadNews");

            migrationBuilder.DropForeignKey(
                name: "FK_AppReadingLists_AbpUsers_UserId",
                table: "AppReadingLists");

            migrationBuilder.DropIndex(
                name: "IX_AppReadingLists_UserId",
                table: "AppReadingLists");

            migrationBuilder.DropIndex(
                name: "IX_AppLogReadNews_UserId",
                table: "AppLogReadNews");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AppReadingLists");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AppLogReadNews",
                newName: "userId");
        }
    }
}
