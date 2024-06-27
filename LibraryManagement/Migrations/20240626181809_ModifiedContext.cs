using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagement.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CloseDate",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ActiveBorrowOrderId",
                table: "Books",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_ActiveBorrowOrderId",
                table: "Books",
                column: "ActiveBorrowOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Orders_ActiveBorrowOrderId",
                table: "Books",
                column: "ActiveBorrowOrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Orders_ActiveBorrowOrderId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_ActiveBorrowOrderId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ActiveBorrowOrderId",
                table: "Books");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CloseDate",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }
    }
}
