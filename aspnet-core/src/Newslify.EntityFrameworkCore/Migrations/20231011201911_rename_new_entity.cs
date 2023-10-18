using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Newslify.Migrations
{
    /// <inheritdoc />
    public partial class renamenewentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KeywordNew");

            migrationBuilder.DropTable(
                name: "NewReadingList");

            migrationBuilder.DropTable(
                name: "AppNews");

            migrationBuilder.CreateTable(
                name: "AppSavedNews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Source = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSavedNews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KeywordSavedNew",
                columns: table => new
                {
                    KeywordsId = table.Column<int>(type: "int", nullable: false),
                    SavedNewsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeywordSavedNew", x => new { x.KeywordsId, x.SavedNewsId });
                    table.ForeignKey(
                        name: "FK_KeywordSavedNew_AppKeywords_KeywordsId",
                        column: x => x.KeywordsId,
                        principalTable: "AppKeywords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KeywordSavedNew_AppSavedNews_SavedNewsId",
                        column: x => x.SavedNewsId,
                        principalTable: "AppSavedNews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReadingListSavedNew",
                columns: table => new
                {
                    ReadingListsId = table.Column<int>(type: "int", nullable: false),
                    SavedNewsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReadingListSavedNew", x => new { x.ReadingListsId, x.SavedNewsId });
                    table.ForeignKey(
                        name: "FK_ReadingListSavedNew_AppReadingLists_ReadingListsId",
                        column: x => x.ReadingListsId,
                        principalTable: "AppReadingLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReadingListSavedNew_AppSavedNews_SavedNewsId",
                        column: x => x.SavedNewsId,
                        principalTable: "AppSavedNews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KeywordSavedNew_SavedNewsId",
                table: "KeywordSavedNew",
                column: "SavedNewsId");

            migrationBuilder.CreateIndex(
                name: "IX_ReadingListSavedNew_SavedNewsId",
                table: "ReadingListSavedNew",
                column: "SavedNewsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KeywordSavedNew");

            migrationBuilder.DropTable(
                name: "ReadingListSavedNew");

            migrationBuilder.DropTable(
                name: "AppSavedNews");

            migrationBuilder.CreateTable(
                name: "AppNews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Author = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Source = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppNews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KeywordNew",
                columns: table => new
                {
                    KeywordsId = table.Column<int>(type: "int", nullable: false),
                    NewsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeywordNew", x => new { x.KeywordsId, x.NewsId });
                    table.ForeignKey(
                        name: "FK_KeywordNew_AppKeywords_KeywordsId",
                        column: x => x.KeywordsId,
                        principalTable: "AppKeywords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KeywordNew_AppNews_NewsId",
                        column: x => x.NewsId,
                        principalTable: "AppNews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NewReadingList",
                columns: table => new
                {
                    NewsId = table.Column<int>(type: "int", nullable: false),
                    ReadingListsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewReadingList", x => new { x.NewsId, x.ReadingListsId });
                    table.ForeignKey(
                        name: "FK_NewReadingList_AppNews_NewsId",
                        column: x => x.NewsId,
                        principalTable: "AppNews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewReadingList_AppReadingLists_ReadingListsId",
                        column: x => x.ReadingListsId,
                        principalTable: "AppReadingLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KeywordNew_NewsId",
                table: "KeywordNew",
                column: "NewsId");

            migrationBuilder.CreateIndex(
                name: "IX_NewReadingList_ReadingListsId",
                table: "NewReadingList",
                column: "ReadingListsId");
        }
    }
}
