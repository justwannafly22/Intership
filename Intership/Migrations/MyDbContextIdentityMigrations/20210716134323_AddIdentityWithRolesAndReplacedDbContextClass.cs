using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Intership.Migrations.MyDbContextIdentityMigrations
{
    public partial class AddIdentityWithRolesAndReplacedDbContextClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    client_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    client_surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    contact_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    allow_email_notifications = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.id);
                    table.ForeignKey(
                        name: "FK_Clients_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Repairs",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    repairinfo_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    client_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repairs", x => x.id);
                    table.ForeignKey(
                        name: "FK_Repairs_Clients_client_id",
                        column: x => x.client_id,
                        principalTable: "Clients",
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
                    replaced_part_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "cadd64eb-fdfd-4e8d-bacc-e441159639fd", "bae80eb5-6e15-4874-93ae-682d96b5b1c9", "User", "USER" },
                    { "60eb162c-bdc5-4056-b105-c406242ad2f1", "565fdb87-2df9-4f3a-955e-627edf773ba4", "Administrator", "ADMINISTRATOR" },
                    { "70d1e966-2848-4d04-bf19-38fbc275f56e", "110182fb-13de-4952-baf1-d38d08543db7", "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "id", "age", "allow_email_notifications", "contact_number", "email", "client_name", "client_surname", "UserId" },
                values: new object[,]
                {
                    { new Guid("4987cad9-aabd-4cab-8ef2-cc2c6283da29"), 18, false, "+375 (29) 238-55-39", "pavlik@mail.ru", "Pasha", "Pavlov", null },
                    { new Guid("c766948e-6e43-4c37-a340-71a06347376d"), 35, false, "+375 (29) 238-44-39", "gagarina@mail.ru", "Polina", "Gagarina", null },
                    { new Guid("6beee7e9-8f29-4a6b-854b-98c87759cb2d"), 20, false, "+375 (29) 238-15-54", "stomatolog@mail.ru", "Dasha", "Semenova", null },
                    { new Guid("4ed8b5d0-01cb-4c1c-921f-0a58dab32f69"), 20, false, "+375 (29) 238-15-39", "holcan@mail.ru", "Egor", "Dubrovskiy", null },
                    { new Guid("116f6c7f-cc8c-4526-a3d5-ca799bf440a2"), 20, false, "+375 (29) 238-15-32", "IvanUI4@mail.ru", "Ivan", "Laptopov", null },
                    { new Guid("1d40d73b-9f63-43f6-8eba-ef91d54f1f08"), 23, false, "+375 (29) 238-15-12", "rofl@mail.ru", "Maksim", "Roflenov", null },
                    { new Guid("2acefc95-a35c-4f0a-848a-665ab939e6b8"), 25, false, "+375 (29) 238-15-30", "lolkekchel@mail.ru", "Igor", "Igorev", null },
                    { new Guid("c80a9219-4ff3-435a-be8a-3462482a73d9"), 20, false, "+375 (29) 123-45-67", "alex@mail.ru", "Alexey", "Voinovskiy", null },
                    { new Guid("51032953-9150-4072-9a56-ea22906e799c"), 20, false, "+375 (29) 123-45-68", "stasik@mail.ru", "Stasik", "Ignatenko", null },
                    { new Guid("9ff78f1f-701d-4d30-a619-e0d9e5a4cb65"), 38, false, "+375 (29) 238-15-24", "mazurova@mail.ru", "Masha", "Mazurova", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "product_description", "product_name", "price" },
                values: new object[,]
                {
                    { new Guid("338afc0c-7290-4c15-a5f5-cb091dea6ad3"), "Active noise cancellation", "Headphones", 50.0 },
                    { new Guid("cae134c8-1faf-4e65-b08d-864367afeb21"), "Shelf life - 10000 clicks", "Computer mouse", 20.0 },
                    { new Guid("9def4539-eb0b-4f28-ac0c-d7f4d7e18de0"), "Diagonal - 12,5 inches, resolution - 1920x1080p", "Monitor", 125.0 },
                    { new Guid("e357485f-cddd-4c92-8de7-702918e2bda8"), "Keydoard has a RGB-backlight", "Keyboard", 40.0 },
                    { new Guid("23cbb20e-8174-4ab6-b32e-ee2010f19217"), "Personal computer for games and comfortable work", "Personal computer", 1000.0 },
                    { new Guid("3fc64654-f1e8-4563-ad8f-98c4c56a548a"), "Dust container volume - 0.8l", "Vacuum cleaner", 80.0 },
                    { new Guid("3af8f791-6c93-4afb-820d-3c8bccc83bc4"), "Height - 85cm, width - 50cm", "Electric stove", 500.0 },
                    { new Guid("80abbca8-554d-4b16-b5de-024705497d4a"), "Default teapot", "Teapot", 20.0 },
                    { new Guid("d3bfdeae-ad9e-44e2-b666-52e758c19dda"), "Laptop for work and lowpower games", "Laptop", 750.0 },
                    { new Guid("95bdd46a-f616-4188-9f1a-3dc2eb1a3a64"), "Power - 1450w", "Coffee machine", 925.0 }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "id", "status_info" },
                values: new object[,]
                {
                    { new Guid("38b4bbaa-2da2-4cec-b6c2-a84f9dd3fa32"), "New" },
                    { new Guid("95b2d4fc-5356-42d8-9087-f1e292bd6bfb"), "Waiting to processing by agent" },
                    { new Guid("d3a5ea06-44b2-43e8-89c1-8d5a17bd7791"), "Processing by agent" },
                    { new Guid("cbdfc5bd-82a6-4a8f-b8ec-71a3279f2e07"), "Waiting to register the completing repair" },
                    { new Guid("23ea6ac5-a0a1-4da2-9102-5e7c472aa663"), "Completed" }
                });

            migrationBuilder.InsertData(
                table: "Repairs",
                columns: new[] { "id", "client_id", "name", "repairinfo_id" },
                values: new object[,]
                {
                    { new Guid("b70d7e3e-35c7-4c24-acda-1472ae0c1d55"), new Guid("4ed8b5d0-01cb-4c1c-921f-0a58dab32f69"), "Fixing the problem", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("228aea49-4717-4bf9-9cf4-585b33e54629"), new Guid("c80a9219-4ff3-435a-be8a-3462482a73d9"), "Fixing the problem", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("260e7b03-cf9e-4824-8e3d-174f6fb73e49"), new Guid("51032953-9150-4072-9a56-ea22906e799c"), "Fixing the problem", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("7478668c-1c7a-47ad-82c8-48c3744a1fdb"), new Guid("2acefc95-a35c-4f0a-848a-665ab939e6b8"), "Fixing the problem", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("7d844508-2b92-4fe5-afc8-5e05382b9761"), new Guid("1d40d73b-9f63-43f6-8eba-ef91d54f1f08"), "Fixing the problem", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("633693ac-2891-4fa9-99e9-ffbb9d33aa4b"), new Guid("116f6c7f-cc8c-4526-a3d5-ca799bf440a2"), "Fixing the problem", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("530f0ff1-2d7e-4be0-80e3-77453658c9de"), new Guid("9ff78f1f-701d-4d30-a619-e0d9e5a4cb65"), "Fixing the problem", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("04af2669-ed99-4517-9559-afd077ecd737"), new Guid("6beee7e9-8f29-4a6b-854b-98c87759cb2d"), "Fixing the problem", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("c016f3c3-5189-469a-a580-1798d88882ee"), new Guid("c766948e-6e43-4c37-a340-71a06347376d"), "Fixing the problem", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("29b9d37c-3f23-4507-96b5-8506b291218b"), new Guid("4987cad9-aabd-4cab-8ef2-cc2c6283da29"), "Fixing the problem", new Guid("00000000-0000-0000-0000-000000000000") }
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
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_UserId",
                table: "Clients",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_client_id",
                table: "Repairs",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_RepairsInfo_repair_id",
                table: "RepairsInfo",
                column: "repair_id",
                unique: true);

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "RepairsInfo");

            migrationBuilder.DropTable(
                name: "ReplacedParts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Repairs");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
