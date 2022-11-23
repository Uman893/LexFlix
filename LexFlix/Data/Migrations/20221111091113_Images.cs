using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LexFlix.Data.Migrations
{
    public partial class Images : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderRows_Movies_MovieId",
                table: "orderRows");

            migrationBuilder.DropForeignKey(
                name: "FK_orderRows_Orders_OrderId",
                table: "orderRows");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orderRows",
                table: "orderRows");

            migrationBuilder.RenameTable(
                name: "orderRows",
                newName: "OrderRows");

            migrationBuilder.RenameIndex(
                name: "IX_orderRows_OrderId",
                table: "OrderRows",
                newName: "IX_OrderRows_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_orderRows_MovieId",
                table: "OrderRows",
                newName: "IX_OrderRows_MovieId");

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderRows",
                table: "OrderRows",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderRows_Movies_MovieId",
                table: "OrderRows",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderRows_Orders_OrderId",
                table: "OrderRows",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderRows_Movies_MovieId",
                table: "OrderRows");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderRows_Orders_OrderId",
                table: "OrderRows");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderRows",
                table: "OrderRows");

            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Movies");

            migrationBuilder.RenameTable(
                name: "OrderRows",
                newName: "orderRows");

            migrationBuilder.RenameIndex(
                name: "IX_OrderRows_OrderId",
                table: "orderRows",
                newName: "IX_orderRows_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderRows_MovieId",
                table: "orderRows",
                newName: "IX_orderRows_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orderRows",
                table: "orderRows",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_orderRows_Movies_MovieId",
                table: "orderRows",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orderRows_Orders_OrderId",
                table: "orderRows",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
