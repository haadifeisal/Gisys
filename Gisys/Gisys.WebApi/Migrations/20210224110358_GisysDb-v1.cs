using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gisys.WebApi.Migrations
{
    public partial class GisysDbv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Consultant",
                columns: table => new
                {
                    consultantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    yearOfEmployment = table.Column<int>(type: "int", nullable: false),
                    chargedHours = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultant", x => x.consultantId);
                });

            migrationBuilder.CreateTable(
                name: "NetResult",
                columns: table => new
                {
                    netResultId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    net = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NetResult", x => x.netResultId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consultant");

            migrationBuilder.DropTable(
                name: "NetResult");
        }
    }
}
