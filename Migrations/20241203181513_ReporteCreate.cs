using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Digesett.Migrations
{
    /// <inheritdoc />
    public partial class ReporteCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Fines",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 12, 3, 18, 15, 10, 3, DateTimeKind.Utc).AddTicks(4590), "$2a$11$yadal5Xlcgc2mVQOZDb0qu5hNjUvzGOejdXAuBIK11jGSrbdfbxWa" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Fines");

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
    }
}
