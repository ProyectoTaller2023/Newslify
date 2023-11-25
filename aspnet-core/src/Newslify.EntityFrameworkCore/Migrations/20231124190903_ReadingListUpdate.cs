using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Newslify.Migrations
{
    /// <inheritdoc />
    public partial class ReadingListUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppReadingLists_AppReadingLists_ParentReadingListId",
                table: "AppReadingLists");

            migrationBuilder.DropColumn(
                name: "ParentListId",
                table: "AppReadingLists");

            migrationBuilder.RenameColumn(
                name: "ParentReadingListId",
                table: "AppReadingLists",
                newName: "ReadingListId");

            migrationBuilder.RenameIndex(
                name: "IX_AppReadingLists_ParentReadingListId",
                table: "AppReadingLists",
                newName: "IX_AppReadingLists_ReadingListId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppReadingLists_AppReadingLists_ReadingListId",
                table: "AppReadingLists",
                column: "ReadingListId",
                principalTable: "AppReadingLists",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppReadingLists_AppReadingLists_ReadingListId",
                table: "AppReadingLists");

            migrationBuilder.RenameColumn(
                name: "ReadingListId",
                table: "AppReadingLists",
                newName: "ParentReadingListId");

            migrationBuilder.RenameIndex(
                name: "IX_AppReadingLists_ReadingListId",
                table: "AppReadingLists",
                newName: "IX_AppReadingLists_ParentReadingListId");

            migrationBuilder.AddColumn<int>(
                name: "ParentListId",
                table: "AppReadingLists",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AppReadingLists_AppReadingLists_ParentReadingListId",
                table: "AppReadingLists",
                column: "ParentReadingListId",
                principalTable: "AppReadingLists",
                principalColumn: "Id");
        }
    }
}
