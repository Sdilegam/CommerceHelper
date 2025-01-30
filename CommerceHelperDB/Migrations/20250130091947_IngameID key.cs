using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommerceHelperDB.Migrations
{
    /// <inheritdoc />
    public partial class IngameIDkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prices_Items_ItemId",
                table: "Prices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "Prices",
                newName: "ItemInGameId");

            migrationBuilder.RenameIndex(
                name: "IX_Prices_ItemId",
                table: "Prices",
                newName: "IX_Prices_ItemInGameId");

            migrationBuilder.AlterColumn<int>(
                name: "InGameId",
                table: "Items",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "Items",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "InGameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prices_Items_ItemInGameId",
                table: "Prices",
                column: "ItemInGameId",
                principalTable: "Items",
                principalColumn: "InGameId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prices_Items_ItemInGameId",
                table: "Prices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "ItemInGameId",
                table: "Prices",
                newName: "ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Prices_ItemInGameId",
                table: "Prices",
                newName: "IX_Prices_ItemId");

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "Items",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "InGameId",
                table: "Items",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prices_Items_ItemId",
                table: "Prices",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
