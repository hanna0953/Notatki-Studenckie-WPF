using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Notatki_Studenckie_v3.Migrations
{
    /// <inheritdoc />
    public partial class lol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Topic_Category_CategoryRefID",
                table: "Topic");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Topic",
                table: "Topic");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Topic",
                newName: "Topics");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameColumn(
                name: "QuickTextDB",
                table: "QuickNotes",
                newName: "QuickTextDb");

            migrationBuilder.RenameColumn(
                name: "QuickNoteID",
                table: "QuickNotes",
                newName: "QuickNoteId");

            migrationBuilder.RenameColumn(
                name: "TopicTextDB",
                table: "Topics",
                newName: "TopicTextDb");

            migrationBuilder.RenameColumn(
                name: "CategoryRefID",
                table: "Topics",
                newName: "CategoryRefId");

            migrationBuilder.RenameColumn(
                name: "TopicID",
                table: "Topics",
                newName: "TopicId");

            migrationBuilder.RenameIndex(
                name: "IX_Topic_CategoryRefID",
                table: "Topics",
                newName: "IX_Topics_CategoryRefId");

            migrationBuilder.RenameColumn(
                name: "CategoryNameDB",
                table: "Categories",
                newName: "CategoryNameDb");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Categories",
                newName: "CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Topics",
                table: "Topics",
                column: "TopicId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_Categories_CategoryRefId",
                table: "Topics",
                column: "CategoryRefId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Topics_Categories_CategoryRefId",
                table: "Topics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Topics",
                table: "Topics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Topics",
                newName: "Topic");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameColumn(
                name: "QuickTextDb",
                table: "QuickNotes",
                newName: "QuickTextDB");

            migrationBuilder.RenameColumn(
                name: "QuickNoteId",
                table: "QuickNotes",
                newName: "QuickNoteID");

            migrationBuilder.RenameColumn(
                name: "TopicTextDb",
                table: "Topic",
                newName: "TopicTextDB");

            migrationBuilder.RenameColumn(
                name: "CategoryRefId",
                table: "Topic",
                newName: "CategoryRefID");

            migrationBuilder.RenameColumn(
                name: "TopicId",
                table: "Topic",
                newName: "TopicID");

            migrationBuilder.RenameIndex(
                name: "IX_Topics_CategoryRefId",
                table: "Topic",
                newName: "IX_Topic_CategoryRefID");

            migrationBuilder.RenameColumn(
                name: "CategoryNameDb",
                table: "Category",
                newName: "CategoryNameDB");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Category",
                newName: "CategoryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Topic",
                table: "Topic",
                column: "TopicID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Topic_Category_CategoryRefID",
                table: "Topic",
                column: "CategoryRefID",
                principalTable: "Category",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
