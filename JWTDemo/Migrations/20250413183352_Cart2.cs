using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JWTDemo.Migrations
{
    /// <inheritdoc />
    public partial class Cart2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "CartId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 12, 1, 10, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "CartId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 12, 1, 10, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "CartId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 12, 1, 10, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "CartId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 12, 0, 1, 5, 485, DateTimeKind.Local).AddTicks(6977));

            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "CartId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 13, 0, 1, 5, 489, DateTimeKind.Local).AddTicks(2434));

            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "CartId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 11, 0, 1, 5, 489, DateTimeKind.Local).AddTicks(2461));
        }
    }
}
