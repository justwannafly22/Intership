using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Intership.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_Products_product_id",
                table: "Repairs");

            migrationBuilder.DropIndex(
                name: "IX_Repairs_product_id",
                table: "Repairs");

            migrationBuilder.DropColumn(
                name: "product_id",
                table: "Repairs");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "contact_number",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "client_surname",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "client_name",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.CreateTable(
                name: "ProductRepair",
                columns: table => new
                {
                    ProductsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RepairsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductRepair", x => new { x.ProductsId, x.RepairsId });
                    table.ForeignKey(
                        name: "FK_ProductRepair_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductRepair_Repairs_RepairsId",
                        column: x => x.RepairsId,
                        principalTable: "Repairs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductRepair_RepairsId",
                table: "ProductRepair",
                column: "RepairsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductRepair");

            migrationBuilder.AddColumn<Guid>(
                name: "product_id",
                table: "Repairs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Clients",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "contact_number",
                table: "Clients",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "client_surname",
                table: "Clients",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "client_name",
                table: "Clients",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "id",
                keyValue: new Guid("04af2669-ed99-4517-9559-afd077ecd737"),
                column: "product_id",
                value: new Guid("e357485f-cddd-4c92-8de7-702918e2bda8"));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "id",
                keyValue: new Guid("228aea49-4717-4bf9-9cf4-585b33e54629"),
                column: "product_id",
                value: new Guid("3af8f791-6c93-4afb-820d-3c8bccc83bc4"));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "id",
                keyValue: new Guid("260e7b03-cf9e-4824-8e3d-174f6fb73e49"),
                column: "product_id",
                value: new Guid("3fc64654-f1e8-4563-ad8f-98c4c56a548a"));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "id",
                keyValue: new Guid("29b9d37c-3f23-4507-96b5-8506b291218b"),
                column: "product_id",
                value: new Guid("338afc0c-7290-4c15-a5f5-cb091dea6ad3"));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "id",
                keyValue: new Guid("530f0ff1-2d7e-4be0-80e3-77453658c9de"),
                column: "product_id",
                value: new Guid("9def4539-eb0b-4f28-ac0c-d7f4d7e18de0"));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "id",
                keyValue: new Guid("633693ac-2891-4fa9-99e9-ffbb9d33aa4b"),
                column: "product_id",
                value: new Guid("d3bfdeae-ad9e-44e2-b666-52e758c19dda"));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "id",
                keyValue: new Guid("7478668c-1c7a-47ad-82c8-48c3744a1fdb"),
                column: "product_id",
                value: new Guid("95bdd46a-f616-4188-9f1a-3dc2eb1a3a64"));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "id",
                keyValue: new Guid("7d844508-2b92-4fe5-afc8-5e05382b9761"),
                column: "product_id",
                value: new Guid("23cbb20e-8174-4ab6-b32e-ee2010f19217"));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "id",
                keyValue: new Guid("b70d7e3e-35c7-4c24-acda-1472ae0c1d55"),
                column: "product_id",
                value: new Guid("80abbca8-554d-4b16-b5de-024705497d4a"));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "id",
                keyValue: new Guid("c016f3c3-5189-469a-a580-1798d88882ee"),
                column: "product_id",
                value: new Guid("cae134c8-1faf-4e65-b08d-864367afeb21"));

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_product_id",
                table: "Repairs",
                column: "product_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_Products_product_id",
                table: "Repairs",
                column: "product_id",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
