using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Intership.Migrations
{
    public partial class FixedRelationBetweenRepairsAndRepairsInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RepairsInfo_repair_id",
                table: "RepairsInfo");

            migrationBuilder.AddColumn<Guid>(
                name: "repairinfo_id",
                table: "Repairs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_RepairsInfo_repair_id",
                table: "RepairsInfo",
                column: "repair_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RepairsInfo_repair_id",
                table: "RepairsInfo");

            migrationBuilder.DropColumn(
                name: "repairinfo_id",
                table: "Repairs");

            migrationBuilder.CreateIndex(
                name: "IX_RepairsInfo_repair_id",
                table: "RepairsInfo",
                column: "repair_id");
        }
    }
}
