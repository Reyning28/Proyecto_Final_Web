using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Digesett.Migrations
{
    /// <inheritdoc />
    public partial class super_userAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 12, 4, 18, 17, 58, 984, DateTimeKind.Utc).AddTicks(4235), "$2a$11$MDFY6nC5Kls6KxovujWUDep1P28b6WhWHhxVEEhips099jBJjttjm" });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "Cedula", "CreatedAt", "IsActive", "Name", "Password" },
                values: new object[] { "2", "002-0000000-0", new DateTime(2024, 12, 4, 18, 17, 59, 393, DateTimeKind.Utc).AddTicks(4714), true, "adamix", "$2a$11$C7j50DdUCHclRUove94saOchNZIckEaJm5Z0TR2mkGrVLKan.s3sa" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 12, 3, 18, 15, 10, 3, DateTimeKind.Utc).AddTicks(4590), "$2a$11$yadal5Xlcgc2mVQOZDb0qu5hNjUvzGOejdXAuBIK11jGSrbdfbxWa" });
        }
    }
}
