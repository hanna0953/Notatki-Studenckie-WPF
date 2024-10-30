using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Notatki_Studenckie_v3.Migrations
{
    /// <inheritdoc />
    public partial class InitialD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryNameDB = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "QuickNotes",
                columns: table => new
                {
                    QuickNoteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuickTextDB = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuickNotes", x => x.QuickNoteID);
                });

            migrationBuilder.CreateTable(
                name: "Topic",
                columns: table => new
                {
                    TopicID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TopicTextDB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryRefID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topic", x => x.TopicID);
                    table.ForeignKey(
                        name: "FK_Topic_Category_CategoryRefID",
                        column: x => x.CategoryRefID,
                        principalTable: "Category",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "CategoryNameDB" },
                values: new object[] { 1, "[Kategoria 1]" });

            migrationBuilder.InsertData(
                table: "QuickNotes",
                columns: new[] { "QuickNoteID", "QuickTextDB" },
                values: new object[] { 1, "[przykładowa notatka]" });

            migrationBuilder.InsertData(
                table: "Topic",
                columns: new[] { "TopicID", "CategoryRefID", "TopicTextDB" },
                values: new object[] { 1, 1, "Losowa notatka, która zawiera jakieś informacje" });

            migrationBuilder.CreateIndex(
                name: "IX_Topic_CategoryRefID",
                table: "Topic",
                column: "CategoryRefID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuickNotes");

            migrationBuilder.DropTable(
                name: "Topic");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
