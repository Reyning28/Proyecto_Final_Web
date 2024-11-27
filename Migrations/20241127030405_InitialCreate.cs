using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Digesett.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Cedula = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fines",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    CitizenCedula = table.Column<string>(type: "TEXT", nullable: false),
                    CitizenName = table.Column<string>(type: "TEXT", nullable: false),
                    Concept = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Latitude = table.Column<double>(type: "REAL", nullable: false),
                    Longitude = table.Column<double>(type: "REAL", nullable: false),
                    PhotoUrl = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    AgentId = table.Column<string>(type: "TEXT", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fines_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "Cedula", "CreatedAt", "IsActive", "Name", "Password" },
                values: new object[] { "1", "001-0000000-0", new DateTime(2024, 11, 27, 3, 4, 4, 960, DateTimeKind.Utc).AddTicks(9250), true, "Agente Demo", "$2a$11$nmBSXiiUGSGkR93Ot9ybL.M13BkgPOnj9n9znBzWXELzLW9jM4k5u" });

            migrationBuilder.CreateIndex(
                name: "IX_Agents_Cedula",
                table: "Agents",
                column: "Cedula",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fines_AgentId",
                table: "Fines",
                column: "AgentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fines");

            migrationBuilder.DropTable(
                name: "Agents");
        }
    }
}
