using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Newslify.Migrations
{
    /// <inheritdoc />
    public partial class relationuserlanguage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LanguageID",
                table: "AbpUsers",
                newName: "LanguageId");

            migrationBuilder.AlterColumn<int>(
                name: "LanguageId",
                table: "AbpUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_LanguageId",
                table: "AbpUsers",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUsers_AppLanguages_LanguageId",
                table: "AbpUsers",
                column: "LanguageId",
                principalTable: "AppLanguages",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_AppLanguages_LanguageId",
                table: "AbpUsers");

            migrationBuilder.DropIndex(
                name: "IX_AbpUsers_LanguageId",
                table: "AbpUsers");

            migrationBuilder.RenameColumn(
                name: "LanguageId",
                table: "AbpUsers",
                newName: "LanguageID");

            migrationBuilder.AlterColumn<int>(
                name: "LanguageID",
                table: "AbpUsers",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
