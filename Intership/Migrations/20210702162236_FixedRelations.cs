using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Intership.Migrations
{
    public partial class FixedRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ProductRepair");

            migrationBuilder.AddColumn<Guid>(
                name: "client_id",
                table: "Repairs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "id",
                keyValue: new Guid("04af2669-ed99-4517-9559-afd077ecd737"),
                column: "client_id",
                value: new Guid("6beee7e9-8f29-4a6b-854b-98c87759cb2d"));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "id",
                keyValue: new Guid("228aea49-4717-4bf9-9cf4-585b33e54629"),
                column: "client_id",
                value: new Guid("c80a9219-4ff3-435a-be8a-3462482a73d9"));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "id",
                keyValue: new Guid("260e7b03-cf9e-4824-8e3d-174f6fb73e49"),
                column: "client_id",
                value: new Guid("51032953-9150-4072-9a56-ea22906e799c"));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "id",
                keyValue: new Guid("29b9d37c-3f23-4507-96b5-8506b291218b"),
                column: "client_id",
                value: new Guid("4987cad9-aabd-4cab-8ef2-cc2c6283da29"));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "id",
                keyValue: new Guid("530f0ff1-2d7e-4be0-80e3-77453658c9de"),
                column: "client_id",
                value: new Guid("9ff78f1f-701d-4d30-a619-e0d9e5a4cb65"));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "id",
                keyValue: new Guid("633693ac-2891-4fa9-99e9-ffbb9d33aa4b"),
                column: "client_id",
                value: new Guid("116f6c7f-cc8c-4526-a3d5-ca799bf440a2"));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "id",
                keyValue: new Guid("7478668c-1c7a-47ad-82c8-48c3744a1fdb"),
                column: "client_id",
                value: new Guid("2acefc95-a35c-4f0a-848a-665ab939e6b8"));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "id",
                keyValue: new Guid("7d844508-2b92-4fe5-afc8-5e05382b9761"),
                column: "client_id",
                value: new Guid("1d40d73b-9f63-43f6-8eba-ef91d54f1f08"));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "id",
                keyValue: new Guid("b70d7e3e-35c7-4c24-acda-1472ae0c1d55"),
                column: "client_id",
                value: new Guid("4ed8b5d0-01cb-4c1c-921f-0a58dab32f69"));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "id",
                keyValue: new Guid("c016f3c3-5189-469a-a580-1798d88882ee"),
                column: "client_id",
                value: new Guid("c766948e-6e43-4c37-a340-71a06347376d"));

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_client_id",
                table: "Repairs",
                column: "client_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_Clients_client_id",
                table: "Repairs",
                column: "client_id",
                principalTable: "Clients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_Clients_client_id",
                table: "Repairs");

            migrationBuilder.DropIndex(
                name: "IX_Repairs_client_id",
                table: "Repairs");

            migrationBuilder.DropColumn(
                name: "client_id",
                table: "Repairs");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    advanced_info = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    client_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    count = table.Column<int>(type: "int", nullable: false),
                    order_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    product_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.id);
                    table.ForeignKey(
                        name: "FK_Orders_Clients_client_id",
                        column: x => x.client_id,
                        principalTable: "Clients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Products_product_id",
                        column: x => x.product_id,
                        principalTable: "Products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "id", "advanced_info", "client_id", "count", "order_date", "product_id" },
                values: new object[,]
                {
                    { new Guid("b2333228-6d8e-43ae-8009-95e64ea50938"), "Advanced info is empty", new Guid("116f6c7f-cc8c-4526-a3d5-ca799bf440a2"), 1, new DateTime(2021, 6, 8, 14, 35, 0, 0, DateTimeKind.Unspecified), new Guid("80abbca8-554d-4b16-b5de-024705497d4a") },
                    { new Guid("0843b6af-8160-42e3-a65e-40a897851c8c"), "Advanced info is empty", new Guid("116f6c7f-cc8c-4526-a3d5-ca799bf440a2"), 1, new DateTime(2021, 6, 8, 14, 35, 15, 0, DateTimeKind.Unspecified), new Guid("3fc64654-f1e8-4563-ad8f-98c4c56a548a") },
                    { new Guid("5d96d2dc-c8be-4846-9066-da88f1d2934a"), "Advanced info is empty", new Guid("116f6c7f-cc8c-4526-a3d5-ca799bf440a2"), 1, new DateTime(2021, 6, 8, 14, 35, 30, 0, DateTimeKind.Unspecified), new Guid("95bdd46a-f616-4188-9f1a-3dc2eb1a3a64") },
                    { new Guid("ac16b9e3-6bc2-43ee-b78f-7c7c2f3b084e"), "Advanced info is empty", new Guid("9ff78f1f-701d-4d30-a619-e0d9e5a4cb65"), 1, new DateTime(2021, 6, 8, 11, 30, 0, 0, DateTimeKind.Unspecified), new Guid("23cbb20e-8174-4ab6-b32e-ee2010f19217") },
                    { new Guid("5ea3751a-a36a-480b-b6b1-f78947b70b19"), "Advanced info is empty", new Guid("9ff78f1f-701d-4d30-a619-e0d9e5a4cb65"), 1, new DateTime(2021, 6, 8, 10, 10, 50, 0, DateTimeKind.Unspecified), new Guid("9def4539-eb0b-4f28-ac0c-d7f4d7e18de0") },
                    { new Guid("48784c17-efa4-41ab-9ff9-bdc676d7d20a"), "Advanced info is empty", new Guid("6beee7e9-8f29-4a6b-854b-98c87759cb2d"), 1, new DateTime(2021, 6, 8, 15, 15, 37, 0, DateTimeKind.Unspecified), new Guid("338afc0c-7290-4c15-a5f5-cb091dea6ad3") },
                    { new Guid("cb63b643-b3c3-4043-a710-6d6d02f02be8"), "Advanced info is empty", new Guid("c766948e-6e43-4c37-a340-71a06347376d"), 1, new DateTime(2021, 6, 8, 9, 57, 13, 0, DateTimeKind.Unspecified), new Guid("3af8f791-6c93-4afb-820d-3c8bccc83bc4") },
                    { new Guid("6fdff5b9-69c9-4f4b-88fe-936968128ea2"), "Advanced info is empty", new Guid("4987cad9-aabd-4cab-8ef2-cc2c6283da29"), 1, new DateTime(2021, 6, 7, 13, 27, 23, 0, DateTimeKind.Unspecified), new Guid("d3bfdeae-ad9e-44e2-b666-52e758c19dda") },
                    { new Guid("9c26b939-fb16-493e-954e-5efe09ebf11f"), "Advanced info is empty", new Guid("1d40d73b-9f63-43f6-8eba-ef91d54f1f08"), 1, new DateTime(2021, 6, 7, 5, 2, 45, 0, DateTimeKind.Unspecified), new Guid("3af8f791-6c93-4afb-820d-3c8bccc83bc4") },
                    { new Guid("15b6e738-a210-40aa-97b0-58798f4339af"), "Advanced info is empty", new Guid("2acefc95-a35c-4f0a-848a-665ab939e6b8"), 2, new DateTime(2021, 6, 7, 23, 12, 4, 0, DateTimeKind.Unspecified), new Guid("cae134c8-1faf-4e65-b08d-864367afeb21") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_client_id",
                table: "Orders",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_product_id",
                table: "Orders",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductRepair_RepairsId",
                table: "ProductRepair",
                column: "RepairsId");
        }
    }
}
