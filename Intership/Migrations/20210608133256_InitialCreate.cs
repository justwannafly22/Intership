using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Intership.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    client_name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    client_surname = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    age = table.Column<int>(type: "int", nullable: true),
                    contact_number = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    email = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    allow_email_notifications = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    product_name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    price = table.Column<double>(type: "float", nullable: false),
                    product_description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    status_info = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    order_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    count = table.Column<int>(type: "int", nullable: false),
                    advanced_info = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    client_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                name: "Repairs",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    product_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repairs", x => x.id);
                    table.ForeignKey(
                        name: "FK_Repairs_Products_product_id",
                        column: x => x.product_id,
                        principalTable: "Products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RepairsInfo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    repair_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    advanced_info = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    status_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    repair_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairsInfo", x => x.id);
                    table.ForeignKey(
                        name: "FK_RepairsInfo_Repairs_repair_id",
                        column: x => x.repair_id,
                        principalTable: "Repairs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RepairsInfo_Statuses_status_id",
                        column: x => x.status_id,
                        principalTable: "Statuses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReplacedParts",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    replaced_part_name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    price = table.Column<double>(type: "float", nullable: false),
                    replaced_part_count = table.Column<int>(type: "int", nullable: false),
                    advanced_info = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    repair_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    product_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReplacedParts", x => x.id);
                    table.ForeignKey(
                        name: "FK_ReplacedParts_Products_product_id",
                        column: x => x.product_id,
                        principalTable: "Products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReplacedParts_Repairs_repair_id",
                        column: x => x.repair_id,
                        principalTable: "Repairs",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "id", "age", "allow_email_notifications", "contact_number", "email", "client_name", "client_surname" },
                values: new object[,]
                {
                    { new Guid("4ed8b5d0-01cb-4c1c-921f-0a58dab32f69"), 20, false, "+375 (29) 238-15-39", "holcan@mail.ru", "Egor", "Dubrovskiy" },
                    { new Guid("c80a9219-4ff3-435a-be8a-3462482a73d9"), 20, false, "+375 (29) 123-45-67", "alex@mail.ru", "Alexey", "Voinovskiy" },
                    { new Guid("51032953-9150-4072-9a56-ea22906e799c"), 20, false, "+375 (29) 123-45-68", "stasik@mail.ru", "Stasik", "Ignatenko" },
                    { new Guid("2acefc95-a35c-4f0a-848a-665ab939e6b8"), 25, false, "+375 (29) 238-15-30", "lolkekchel@mail.ru", "Igor", "Igorev" },
                    { new Guid("1d40d73b-9f63-43f6-8eba-ef91d54f1f08"), 23, false, "+375 (29) 238-15-12", "rofl@mail.ru", "Maksim", "Roflenov" },
                    { new Guid("116f6c7f-cc8c-4526-a3d5-ca799bf440a2"), 20, false, "+375 (29) 238-15-32", "IvanUI4@mail.ru", "Ivan", "Laptopov" },
                    { new Guid("9ff78f1f-701d-4d30-a619-e0d9e5a4cb65"), 38, false, "+375 (29) 238-15-24", "mazurova@mail.ru", "Masha", "Mazurova" },
                    { new Guid("6beee7e9-8f29-4a6b-854b-98c87759cb2d"), 20, false, "+375 (29) 238-15-54", "stomatolog@mail.ru", "Dasha", "Semenova" },
                    { new Guid("c766948e-6e43-4c37-a340-71a06347376d"), 35, false, "+375 (29) 238-44-39", "gagarina@mail.ru", "Polina", "Gagarina" },
                    { new Guid("4987cad9-aabd-4cab-8ef2-cc2c6283da29"), 18, false, "+375 (29) 238-55-39", "pavlik@mail.ru", "Pasha", "Pavlov" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "product_description", "product_name", "price" },
                values: new object[,]
                {
                    { new Guid("338afc0c-7290-4c15-a5f5-cb091dea6ad3"), "Active noise cancellation", "Headphones", 50.0 },
                    { new Guid("cae134c8-1faf-4e65-b08d-864367afeb21"), "Shelf life - 10000 clicks", "Computer mouse", 20.0 },
                    { new Guid("e357485f-cddd-4c92-8de7-702918e2bda8"), "Keydoard has a RGB-backlight", "Keyboard", 40.0 },
                    { new Guid("9def4539-eb0b-4f28-ac0c-d7f4d7e18de0"), "Diagonal - 12,5 inches, resolution - 1920x1080p", "Monitor", 125.0 },
                    { new Guid("d3bfdeae-ad9e-44e2-b666-52e758c19dda"), "Laptop for work and lowpower games", "Laptop", 750.0 },
                    { new Guid("3fc64654-f1e8-4563-ad8f-98c4c56a548a"), "Dust container volume - 0.8l", "Vacuum cleaner", 80.0 },
                    { new Guid("95bdd46a-f616-4188-9f1a-3dc2eb1a3a64"), "Power - 1450w", "Coffee machine", 925.0 },
                    { new Guid("3af8f791-6c93-4afb-820d-3c8bccc83bc4"), "Height - 85cm, width - 50cm", "Electric stove", 500.0 },
                    { new Guid("80abbca8-554d-4b16-b5de-024705497d4a"), "Default teapot", "Teapot", 20.0 },
                    { new Guid("23cbb20e-8174-4ab6-b32e-ee2010f19217"), "Personal computer for games and comfortable work", "Personal computer", 1000.0 }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "id", "status_info" },
                values: new object[,]
                {
                    { new Guid("cbdfc5bd-82a6-4a8f-b8ec-71a3279f2e07"), "Waiting to register the completing repair" },
                    { new Guid("38b4bbaa-2da2-4cec-b6c2-a84f9dd3fa32"), "New" },
                    { new Guid("95b2d4fc-5356-42d8-9087-f1e292bd6bfb"), "Waiting to processing by agent" },
                    { new Guid("d3a5ea06-44b2-43e8-89c1-8d5a17bd7791"), "Processing by agent" },
                    { new Guid("23ea6ac5-a0a1-4da2-9102-5e7c472aa663"), "Completed" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "id", "advanced_info", "client_id", "count", "order_date", "product_id" },
                values: new object[,]
                {
                    { new Guid("b2333228-6d8e-43ae-8009-95e64ea50938"), "Advanced info is empty", new Guid("116f6c7f-cc8c-4526-a3d5-ca799bf440a2"), 1, new DateTime(2021, 6, 8, 14, 35, 0, 0, DateTimeKind.Unspecified), new Guid("80abbca8-554d-4b16-b5de-024705497d4a") },
                    { new Guid("15b6e738-a210-40aa-97b0-58798f4339af"), "Advanced info is empty", new Guid("2acefc95-a35c-4f0a-848a-665ab939e6b8"), 2, new DateTime(2021, 6, 7, 23, 12, 4, 0, DateTimeKind.Unspecified), new Guid("cae134c8-1faf-4e65-b08d-864367afeb21") },
                    { new Guid("5ea3751a-a36a-480b-b6b1-f78947b70b19"), "Advanced info is empty", new Guid("9ff78f1f-701d-4d30-a619-e0d9e5a4cb65"), 1, new DateTime(2021, 6, 8, 10, 10, 50, 0, DateTimeKind.Unspecified), new Guid("9def4539-eb0b-4f28-ac0c-d7f4d7e18de0") },
                    { new Guid("6fdff5b9-69c9-4f4b-88fe-936968128ea2"), "Advanced info is empty", new Guid("4987cad9-aabd-4cab-8ef2-cc2c6283da29"), 1, new DateTime(2021, 6, 7, 13, 27, 23, 0, DateTimeKind.Unspecified), new Guid("d3bfdeae-ad9e-44e2-b666-52e758c19dda") },
                    { new Guid("48784c17-efa4-41ab-9ff9-bdc676d7d20a"), "Advanced info is empty", new Guid("6beee7e9-8f29-4a6b-854b-98c87759cb2d"), 1, new DateTime(2021, 6, 8, 15, 15, 37, 0, DateTimeKind.Unspecified), new Guid("338afc0c-7290-4c15-a5f5-cb091dea6ad3") },
                    { new Guid("5d96d2dc-c8be-4846-9066-da88f1d2934a"), "Advanced info is empty", new Guid("116f6c7f-cc8c-4526-a3d5-ca799bf440a2"), 1, new DateTime(2021, 6, 8, 14, 35, 30, 0, DateTimeKind.Unspecified), new Guid("95bdd46a-f616-4188-9f1a-3dc2eb1a3a64") },
                    { new Guid("ac16b9e3-6bc2-43ee-b78f-7c7c2f3b084e"), "Advanced info is empty", new Guid("9ff78f1f-701d-4d30-a619-e0d9e5a4cb65"), 1, new DateTime(2021, 6, 8, 11, 30, 0, 0, DateTimeKind.Unspecified), new Guid("23cbb20e-8174-4ab6-b32e-ee2010f19217") },
                    { new Guid("0843b6af-8160-42e3-a65e-40a897851c8c"), "Advanced info is empty", new Guid("116f6c7f-cc8c-4526-a3d5-ca799bf440a2"), 1, new DateTime(2021, 6, 8, 14, 35, 15, 0, DateTimeKind.Unspecified), new Guid("3fc64654-f1e8-4563-ad8f-98c4c56a548a") },
                    { new Guid("9c26b939-fb16-493e-954e-5efe09ebf11f"), "Advanced info is empty", new Guid("1d40d73b-9f63-43f6-8eba-ef91d54f1f08"), 1, new DateTime(2021, 6, 7, 5, 2, 45, 0, DateTimeKind.Unspecified), new Guid("3af8f791-6c93-4afb-820d-3c8bccc83bc4") },
                    { new Guid("cb63b643-b3c3-4043-a710-6d6d02f02be8"), "Advanced info is empty", new Guid("c766948e-6e43-4c37-a340-71a06347376d"), 1, new DateTime(2021, 6, 8, 9, 57, 13, 0, DateTimeKind.Unspecified), new Guid("3af8f791-6c93-4afb-820d-3c8bccc83bc4") }
                });

            migrationBuilder.InsertData(
                table: "Repairs",
                columns: new[] { "id", "name", "product_id" },
                values: new object[,]
                {
                    { new Guid("7478668c-1c7a-47ad-82c8-48c3744a1fdb"), "Fixing the problem", new Guid("95bdd46a-f616-4188-9f1a-3dc2eb1a3a64") },
                    { new Guid("228aea49-4717-4bf9-9cf4-585b33e54629"), "Fixing the problem", new Guid("3af8f791-6c93-4afb-820d-3c8bccc83bc4") },
                    { new Guid("7d844508-2b92-4fe5-afc8-5e05382b9761"), "Fixing the problem", new Guid("23cbb20e-8174-4ab6-b32e-ee2010f19217") },
                    { new Guid("633693ac-2891-4fa9-99e9-ffbb9d33aa4b"), "Fixing the problem", new Guid("d3bfdeae-ad9e-44e2-b666-52e758c19dda") },
                    { new Guid("530f0ff1-2d7e-4be0-80e3-77453658c9de"), "Fixing the problem", new Guid("9def4539-eb0b-4f28-ac0c-d7f4d7e18de0") },
                    { new Guid("04af2669-ed99-4517-9559-afd077ecd737"), "Fixing the problem", new Guid("e357485f-cddd-4c92-8de7-702918e2bda8") },
                    { new Guid("b70d7e3e-35c7-4c24-acda-1472ae0c1d55"), "Fixing the problem", new Guid("80abbca8-554d-4b16-b5de-024705497d4a") },
                    { new Guid("c016f3c3-5189-469a-a580-1798d88882ee"), "Fixing the problem", new Guid("cae134c8-1faf-4e65-b08d-864367afeb21") },
                    { new Guid("260e7b03-cf9e-4824-8e3d-174f6fb73e49"), "Fixing the problem", new Guid("3fc64654-f1e8-4563-ad8f-98c4c56a548a") },
                    { new Guid("29b9d37c-3f23-4507-96b5-8506b291218b"), "Fixing the problem", new Guid("338afc0c-7290-4c15-a5f5-cb091dea6ad3") }
                });

            migrationBuilder.InsertData(
                table: "RepairsInfo",
                columns: new[] { "id", "advanced_info", "repair_date", "repair_id", "status_id" },
                values: new object[,]
                {
                    { new Guid("8a0d3ba9-0381-4ecd-8f08-a44b8a012c99"), "Advanced info is empty", new DateTime(2021, 6, 9, 13, 22, 12, 0, DateTimeKind.Unspecified), new Guid("b70d7e3e-35c7-4c24-acda-1472ae0c1d55"), new Guid("38b4bbaa-2da2-4cec-b6c2-a84f9dd3fa32") },
                    { new Guid("df698265-4600-4233-a43b-a14cefa0ce84"), "Advanced info is empty", new DateTime(2021, 6, 12, 21, 32, 23, 0, DateTimeKind.Unspecified), new Guid("228aea49-4717-4bf9-9cf4-585b33e54629"), new Guid("38b4bbaa-2da2-4cec-b6c2-a84f9dd3fa32") },
                    { new Guid("7042b0f5-de40-4ad8-be74-0af196e3e219"), "Advanced info is empty", new DateTime(2021, 6, 17, 15, 20, 10, 0, DateTimeKind.Unspecified), new Guid("c016f3c3-5189-469a-a580-1798d88882ee"), new Guid("cbdfc5bd-82a6-4a8f-b8ec-71a3279f2e07") },
                    { new Guid("7103bcce-ef4c-438d-bb7b-54843bc5876f"), "Advanced info is empty", new DateTime(2021, 6, 22, 21, 56, 46, 0, DateTimeKind.Unspecified), new Guid("260e7b03-cf9e-4824-8e3d-174f6fb73e49"), new Guid("38b4bbaa-2da2-4cec-b6c2-a84f9dd3fa32") },
                    { new Guid("ce657751-0172-404c-bee1-86577748fda7"), "Advanced info is empty", new DateTime(2021, 6, 17, 12, 40, 40, 0, DateTimeKind.Unspecified), new Guid("7478668c-1c7a-47ad-82c8-48c3744a1fdb"), new Guid("95b2d4fc-5356-42d8-9087-f1e292bd6bfb") },
                    { new Guid("d6f5f6bf-3576-490f-afa8-03aa30bf19f4"), "Advanced info is empty", new DateTime(2021, 6, 19, 14, 56, 50, 0, DateTimeKind.Unspecified), new Guid("04af2669-ed99-4517-9559-afd077ecd737"), new Guid("d3a5ea06-44b2-43e8-89c1-8d5a17bd7791") },
                    { new Guid("06ed2ac8-bd78-49e5-8541-6c05fca1c900"), "Advanced info is empty", new DateTime(2021, 6, 15, 23, 40, 30, 0, DateTimeKind.Unspecified), new Guid("7d844508-2b92-4fe5-afc8-5e05382b9761"), new Guid("95b2d4fc-5356-42d8-9087-f1e292bd6bfb") },
                    { new Guid("cb75f4fb-676f-4722-b298-a5f1ba86684e"), "Advanced info is empty", new DateTime(2021, 6, 23, 17, 30, 20, 0, DateTimeKind.Unspecified), new Guid("29b9d37c-3f23-4507-96b5-8506b291218b"), new Guid("23ea6ac5-a0a1-4da2-9102-5e7c472aa663") },
                    { new Guid("a806068a-828d-48c3-b708-08db47019bd0"), "Advanced info is empty", new DateTime(2021, 6, 12, 11, 1, 45, 0, DateTimeKind.Unspecified), new Guid("633693ac-2891-4fa9-99e9-ffbb9d33aa4b"), new Guid("38b4bbaa-2da2-4cec-b6c2-a84f9dd3fa32") },
                    { new Guid("aa2b4994-3cde-4bf9-af01-53c98b2d3d79"), "Advanced info is empty", new DateTime(2021, 6, 9, 16, 23, 59, 0, DateTimeKind.Unspecified), new Guid("530f0ff1-2d7e-4be0-80e3-77453658c9de"), new Guid("d3a5ea06-44b2-43e8-89c1-8d5a17bd7791") }
                });

            migrationBuilder.InsertData(
                table: "ReplacedParts",
                columns: new[] { "id", "advanced_info", "replaced_part_count", "replaced_part_name", "price", "product_id", "repair_id" },
                values: new object[,]
                {
                    { new Guid("e41aeec6-b638-4e13-ab30-92fdc681721c"), "Advanced info is empty", 50, "Replacement part", 1.5, new Guid("cae134c8-1faf-4e65-b08d-864367afeb21"), new Guid("c016f3c3-5189-469a-a580-1798d88882ee") },
                    { new Guid("b188a871-578f-41f8-8769-2f045028c464"), "Advanced info is empty", 3, "Replacement part", 7.5, new Guid("e357485f-cddd-4c92-8de7-702918e2bda8"), new Guid("04af2669-ed99-4517-9559-afd077ecd737") },
                    { new Guid("6ceb82ab-89b9-4a32-80c2-a6ac1c35c6e6"), "Advanced info is empty", 30, "Replacement part", 2.0, new Guid("9def4539-eb0b-4f28-ac0c-d7f4d7e18de0"), new Guid("530f0ff1-2d7e-4be0-80e3-77453658c9de") },
                    { new Guid("0f65d970-5eb6-4e61-8630-a536dbe9fa98"), "Advanced info is empty", 3, "Replacement part", 5.0, new Guid("80abbca8-554d-4b16-b5de-024705497d4a"), new Guid("7d844508-2b92-4fe5-afc8-5e05382b9761") },
                    { new Guid("477bd3bc-182a-4997-9a48-3cb419e5ce82"), "Advanced info is empty", 2, "Replacement part", 10.0, new Guid("80abbca8-554d-4b16-b5de-024705497d4a"), new Guid("7478668c-1c7a-47ad-82c8-48c3744a1fdb") },
                    { new Guid("d2ce0637-b66e-47ab-80f8-846ade723769"), "Advanced info is empty", 1, "Replacement part", 25.0, new Guid("3fc64654-f1e8-4563-ad8f-98c4c56a548a"), new Guid("260e7b03-cf9e-4824-8e3d-174f6fb73e49") },
                    { new Guid("4795f7f9-5c54-4426-9686-3bb27b9223a2"), "Advanced info is empty", 1, "Replacement part", 20.0, new Guid("3af8f791-6c93-4afb-820d-3c8bccc83bc4"), new Guid("228aea49-4717-4bf9-9cf4-585b33e54629") },
                    { new Guid("2f6b761f-24a5-4f50-94b8-2a27b1f21823"), "Advanced info is empty", 1, "Replacement part", 15.0, new Guid("80abbca8-554d-4b16-b5de-024705497d4a"), new Guid("b70d7e3e-35c7-4c24-acda-1472ae0c1d55") },
                    { new Guid("882adfb5-628f-46fe-82da-44e91f5f4de9"), "Advanced info is empty", 2, "Replacement part", 30.0, new Guid("d3bfdeae-ad9e-44e2-b666-52e758c19dda"), new Guid("633693ac-2891-4fa9-99e9-ffbb9d33aa4b") },
                    { new Guid("0cc0c42d-a52c-411e-9ffa-983acc519854"), "Advanced info is empty", 3, "Replacement part", 8.25, new Guid("338afc0c-7290-4c15-a5f5-cb091dea6ad3"), new Guid("29b9d37c-3f23-4507-96b5-8506b291218b") }
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
                name: "IX_Repairs_product_id",
                table: "Repairs",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_RepairsInfo_repair_id",
                table: "RepairsInfo",
                column: "repair_id");

            migrationBuilder.CreateIndex(
                name: "IX_RepairsInfo_status_id",
                table: "RepairsInfo",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_ReplacedParts_product_id",
                table: "ReplacedParts",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_ReplacedParts_repair_id",
                table: "ReplacedParts",
                column: "repair_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "RepairsInfo");

            migrationBuilder.DropTable(
                name: "ReplacedParts");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Repairs");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
