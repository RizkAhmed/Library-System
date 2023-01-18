using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryCRUD.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookUserAccount",
                columns: table => new
                {
                    BooksId = table.Column<int>(type: "int", nullable: false),
                    UserAccountsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookUserAccount", x => new { x.BooksId, x.UserAccountsId });
                    table.ForeignKey(
                        name: "FK_BookUserAccount_books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookUserAccount_UserAccounts_UserAccountsId",
                        column: x => x.UserAccountsId,
                        principalTable: "UserAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookUserAccount_UserAccountsId",
                table: "BookUserAccount",
                column: "UserAccountsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookUserAccount");
        }
    }
}
