using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Digesett.Migrations
{
    /// <inheritdoc />
    public partial class AddConceptoMulta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConceptosMultas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Concept = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConceptosMultas", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 11, 29, 19, 38, 17, 617, DateTimeKind.Utc).AddTicks(9550), "$2a$11$H9dFehI2G2EZEuNR2C69x.DE3B7Lm7gXwdRPgRtrALgCwuDpK77uu" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConceptosMultas");

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 11, 27, 3, 4, 4, 960, DateTimeKind.Utc).AddTicks(9250), "$2a$11$nmBSXiiUGSGkR93Ot9ybL.M13BkgPOnj9n9znBzWXELzLW9jM4k5u" });
        }
    }
}
