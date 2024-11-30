using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Digesett.Migrations
{
    /// <inheritdoc />
    public partial class FinesCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AgentId",
                table: "Fines",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 11, 30, 15, 48, 6, 571, DateTimeKind.Utc).AddTicks(2074), "$2a$11$27PdFGrdLcRs6jZe4.2srecactxnZghTRqUN4rW70fJI6eMYEZzqK" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AgentId",
                table: "Fines",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 11, 29, 19, 38, 17, 617, DateTimeKind.Utc).AddTicks(9550), "$2a$11$H9dFehI2G2EZEuNR2C69x.DE3B7Lm7gXwdRPgRtrALgCwuDpK77uu" });
        }
    }
}
