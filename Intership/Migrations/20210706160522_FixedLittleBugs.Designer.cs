﻿// <auto-generated />
using System;
using Intership.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Intership.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20210706160522_FixedLittleBugs")]
    partial class FixedLittleBugs
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Intership.Data.Entities.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<int>("Age")
                        .HasColumnType("int")
                        .HasColumnName("age");

                    b.Property<bool>("AllowEmailNotification")
                        .HasColumnType("bit")
                        .HasColumnName("allow_email_notifications");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("contact_number");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("client_name");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("client_surname");

                    b.HasKey("Id");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4ed8b5d0-01cb-4c1c-921f-0a58dab32f69"),
                            Age = 20,
                            AllowEmailNotification = false,
                            ContactNumber = "+375 (29) 238-15-39",
                            Email = "holcan@mail.ru",
                            Name = "Egor",
                            Surname = "Dubrovskiy"
                        },
                        new
                        {
                            Id = new Guid("c80a9219-4ff3-435a-be8a-3462482a73d9"),
                            Age = 20,
                            AllowEmailNotification = false,
                            ContactNumber = "+375 (29) 123-45-67",
                            Email = "alex@mail.ru",
                            Name = "Alexey",
                            Surname = "Voinovskiy"
                        },
                        new
                        {
                            Id = new Guid("51032953-9150-4072-9a56-ea22906e799c"),
                            Age = 20,
                            AllowEmailNotification = false,
                            ContactNumber = "+375 (29) 123-45-68",
                            Email = "stasik@mail.ru",
                            Name = "Stasik",
                            Surname = "Ignatenko"
                        },
                        new
                        {
                            Id = new Guid("2acefc95-a35c-4f0a-848a-665ab939e6b8"),
                            Age = 25,
                            AllowEmailNotification = false,
                            ContactNumber = "+375 (29) 238-15-30",
                            Email = "lolkekchel@mail.ru",
                            Name = "Igor",
                            Surname = "Igorev"
                        },
                        new
                        {
                            Id = new Guid("1d40d73b-9f63-43f6-8eba-ef91d54f1f08"),
                            Age = 23,
                            AllowEmailNotification = false,
                            ContactNumber = "+375 (29) 238-15-12",
                            Email = "rofl@mail.ru",
                            Name = "Maksim",
                            Surname = "Roflenov"
                        },
                        new
                        {
                            Id = new Guid("116f6c7f-cc8c-4526-a3d5-ca799bf440a2"),
                            Age = 20,
                            AllowEmailNotification = false,
                            ContactNumber = "+375 (29) 238-15-32",
                            Email = "IvanUI4@mail.ru",
                            Name = "Ivan",
                            Surname = "Laptopov"
                        },
                        new
                        {
                            Id = new Guid("9ff78f1f-701d-4d30-a619-e0d9e5a4cb65"),
                            Age = 38,
                            AllowEmailNotification = false,
                            ContactNumber = "+375 (29) 238-15-24",
                            Email = "mazurova@mail.ru",
                            Name = "Masha",
                            Surname = "Mazurova"
                        },
                        new
                        {
                            Id = new Guid("6beee7e9-8f29-4a6b-854b-98c87759cb2d"),
                            Age = 20,
                            AllowEmailNotification = false,
                            ContactNumber = "+375 (29) 238-15-54",
                            Email = "stomatolog@mail.ru",
                            Name = "Dasha",
                            Surname = "Semenova"
                        },
                        new
                        {
                            Id = new Guid("c766948e-6e43-4c37-a340-71a06347376d"),
                            Age = 35,
                            AllowEmailNotification = false,
                            ContactNumber = "+375 (29) 238-44-39",
                            Email = "gagarina@mail.ru",
                            Name = "Polina",
                            Surname = "Gagarina"
                        },
                        new
                        {
                            Id = new Guid("4987cad9-aabd-4cab-8ef2-cc2c6283da29"),
                            Age = 18,
                            AllowEmailNotification = false,
                            ContactNumber = "+375 (29) 238-55-39",
                            Email = "pavlik@mail.ru",
                            Name = "Pasha",
                            Surname = "Pavlov"
                        });
                });

            modelBuilder.Entity("Intership.Data.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("product_description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)")
                        .HasColumnName("product_name");

                    b.Property<double>("Price")
                        .HasColumnType("float")
                        .HasColumnName("price");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("80abbca8-554d-4b16-b5de-024705497d4a"),
                            Description = "Default teapot",
                            Name = "Teapot",
                            Price = 20.0
                        },
                        new
                        {
                            Id = new Guid("3af8f791-6c93-4afb-820d-3c8bccc83bc4"),
                            Description = "Height - 85cm, width - 50cm",
                            Name = "Electric stove",
                            Price = 500.0
                        },
                        new
                        {
                            Id = new Guid("3fc64654-f1e8-4563-ad8f-98c4c56a548a"),
                            Description = "Dust container volume - 0.8l",
                            Name = "Vacuum cleaner",
                            Price = 80.0
                        },
                        new
                        {
                            Id = new Guid("95bdd46a-f616-4188-9f1a-3dc2eb1a3a64"),
                            Description = "Power - 1450w",
                            Name = "Coffee machine",
                            Price = 925.0
                        },
                        new
                        {
                            Id = new Guid("23cbb20e-8174-4ab6-b32e-ee2010f19217"),
                            Description = "Personal computer for games and comfortable work",
                            Name = "Personal computer",
                            Price = 1000.0
                        },
                        new
                        {
                            Id = new Guid("d3bfdeae-ad9e-44e2-b666-52e758c19dda"),
                            Description = "Laptop for work and lowpower games",
                            Name = "Laptop",
                            Price = 750.0
                        },
                        new
                        {
                            Id = new Guid("9def4539-eb0b-4f28-ac0c-d7f4d7e18de0"),
                            Description = "Diagonal - 12,5 inches, resolution - 1920x1080p",
                            Name = "Monitor",
                            Price = 125.0
                        },
                        new
                        {
                            Id = new Guid("e357485f-cddd-4c92-8de7-702918e2bda8"),
                            Description = "Keydoard has a RGB-backlight",
                            Name = "Keyboard",
                            Price = 40.0
                        },
                        new
                        {
                            Id = new Guid("cae134c8-1faf-4e65-b08d-864367afeb21"),
                            Description = "Shelf life - 10000 clicks",
                            Name = "Computer mouse",
                            Price = 20.0
                        },
                        new
                        {
                            Id = new Guid("338afc0c-7290-4c15-a5f5-cb091dea6ad3"),
                            Description = "Active noise cancellation",
                            Name = "Headphones",
                            Price = 50.0
                        });
                });

            modelBuilder.Entity("Intership.Data.Entities.Repair", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("client_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)")
                        .HasColumnName("name");

                    b.Property<Guid>("RepairInfoId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("repairinfo_id");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Repairs");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b70d7e3e-35c7-4c24-acda-1472ae0c1d55"),
                            ClientId = new Guid("4ed8b5d0-01cb-4c1c-921f-0a58dab32f69"),
                            Name = "Fixing the problem",
                            RepairInfoId = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("228aea49-4717-4bf9-9cf4-585b33e54629"),
                            ClientId = new Guid("c80a9219-4ff3-435a-be8a-3462482a73d9"),
                            Name = "Fixing the problem",
                            RepairInfoId = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("260e7b03-cf9e-4824-8e3d-174f6fb73e49"),
                            ClientId = new Guid("51032953-9150-4072-9a56-ea22906e799c"),
                            Name = "Fixing the problem",
                            RepairInfoId = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("7478668c-1c7a-47ad-82c8-48c3744a1fdb"),
                            ClientId = new Guid("2acefc95-a35c-4f0a-848a-665ab939e6b8"),
                            Name = "Fixing the problem",
                            RepairInfoId = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("7d844508-2b92-4fe5-afc8-5e05382b9761"),
                            ClientId = new Guid("1d40d73b-9f63-43f6-8eba-ef91d54f1f08"),
                            Name = "Fixing the problem",
                            RepairInfoId = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("633693ac-2891-4fa9-99e9-ffbb9d33aa4b"),
                            ClientId = new Guid("116f6c7f-cc8c-4526-a3d5-ca799bf440a2"),
                            Name = "Fixing the problem",
                            RepairInfoId = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("530f0ff1-2d7e-4be0-80e3-77453658c9de"),
                            ClientId = new Guid("9ff78f1f-701d-4d30-a619-e0d9e5a4cb65"),
                            Name = "Fixing the problem",
                            RepairInfoId = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("04af2669-ed99-4517-9559-afd077ecd737"),
                            ClientId = new Guid("6beee7e9-8f29-4a6b-854b-98c87759cb2d"),
                            Name = "Fixing the problem",
                            RepairInfoId = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("c016f3c3-5189-469a-a580-1798d88882ee"),
                            ClientId = new Guid("c766948e-6e43-4c37-a340-71a06347376d"),
                            Name = "Fixing the problem",
                            RepairInfoId = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("29b9d37c-3f23-4507-96b5-8506b291218b"),
                            ClientId = new Guid("4987cad9-aabd-4cab-8ef2-cc2c6283da29"),
                            Name = "Fixing the problem",
                            RepairInfoId = new Guid("00000000-0000-0000-0000-000000000000")
                        });
                });

            modelBuilder.Entity("Intership.Data.Entities.RepairInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("AdvancedInfo")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("advanced_info");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("repair_date");

                    b.Property<Guid>("RepairId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("repair_id");

                    b.Property<Guid>("StatusId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("status_id");

                    b.HasKey("Id");

                    b.HasIndex("RepairId")
                        .IsUnique();

                    b.HasIndex("StatusId");

                    b.ToTable("RepairsInfo");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8a0d3ba9-0381-4ecd-8f08-a44b8a012c99"),
                            AdvancedInfo = "Advanced info is empty",
                            Date = new DateTime(2021, 6, 9, 13, 22, 12, 0, DateTimeKind.Unspecified),
                            RepairId = new Guid("b70d7e3e-35c7-4c24-acda-1472ae0c1d55"),
                            StatusId = new Guid("38b4bbaa-2da2-4cec-b6c2-a84f9dd3fa32")
                        },
                        new
                        {
                            Id = new Guid("df698265-4600-4233-a43b-a14cefa0ce84"),
                            AdvancedInfo = "Advanced info is empty",
                            Date = new DateTime(2021, 6, 12, 21, 32, 23, 0, DateTimeKind.Unspecified),
                            RepairId = new Guid("228aea49-4717-4bf9-9cf4-585b33e54629"),
                            StatusId = new Guid("38b4bbaa-2da2-4cec-b6c2-a84f9dd3fa32")
                        },
                        new
                        {
                            Id = new Guid("7103bcce-ef4c-438d-bb7b-54843bc5876f"),
                            AdvancedInfo = "Advanced info is empty",
                            Date = new DateTime(2021, 6, 22, 21, 56, 46, 0, DateTimeKind.Unspecified),
                            RepairId = new Guid("260e7b03-cf9e-4824-8e3d-174f6fb73e49"),
                            StatusId = new Guid("38b4bbaa-2da2-4cec-b6c2-a84f9dd3fa32")
                        },
                        new
                        {
                            Id = new Guid("ce657751-0172-404c-bee1-86577748fda7"),
                            AdvancedInfo = "Advanced info is empty",
                            Date = new DateTime(2021, 6, 17, 12, 40, 40, 0, DateTimeKind.Unspecified),
                            RepairId = new Guid("7478668c-1c7a-47ad-82c8-48c3744a1fdb"),
                            StatusId = new Guid("95b2d4fc-5356-42d8-9087-f1e292bd6bfb")
                        },
                        new
                        {
                            Id = new Guid("06ed2ac8-bd78-49e5-8541-6c05fca1c900"),
                            AdvancedInfo = "Advanced info is empty",
                            Date = new DateTime(2021, 6, 15, 23, 40, 30, 0, DateTimeKind.Unspecified),
                            RepairId = new Guid("7d844508-2b92-4fe5-afc8-5e05382b9761"),
                            StatusId = new Guid("95b2d4fc-5356-42d8-9087-f1e292bd6bfb")
                        },
                        new
                        {
                            Id = new Guid("a806068a-828d-48c3-b708-08db47019bd0"),
                            AdvancedInfo = "Advanced info is empty",
                            Date = new DateTime(2021, 6, 12, 11, 1, 45, 0, DateTimeKind.Unspecified),
                            RepairId = new Guid("633693ac-2891-4fa9-99e9-ffbb9d33aa4b"),
                            StatusId = new Guid("38b4bbaa-2da2-4cec-b6c2-a84f9dd3fa32")
                        },
                        new
                        {
                            Id = new Guid("aa2b4994-3cde-4bf9-af01-53c98b2d3d79"),
                            AdvancedInfo = "Advanced info is empty",
                            Date = new DateTime(2021, 6, 9, 16, 23, 59, 0, DateTimeKind.Unspecified),
                            RepairId = new Guid("530f0ff1-2d7e-4be0-80e3-77453658c9de"),
                            StatusId = new Guid("d3a5ea06-44b2-43e8-89c1-8d5a17bd7791")
                        },
                        new
                        {
                            Id = new Guid("d6f5f6bf-3576-490f-afa8-03aa30bf19f4"),
                            AdvancedInfo = "Advanced info is empty",
                            Date = new DateTime(2021, 6, 19, 14, 56, 50, 0, DateTimeKind.Unspecified),
                            RepairId = new Guid("04af2669-ed99-4517-9559-afd077ecd737"),
                            StatusId = new Guid("d3a5ea06-44b2-43e8-89c1-8d5a17bd7791")
                        },
                        new
                        {
                            Id = new Guid("7042b0f5-de40-4ad8-be74-0af196e3e219"),
                            AdvancedInfo = "Advanced info is empty",
                            Date = new DateTime(2021, 6, 17, 15, 20, 10, 0, DateTimeKind.Unspecified),
                            RepairId = new Guid("c016f3c3-5189-469a-a580-1798d88882ee"),
                            StatusId = new Guid("cbdfc5bd-82a6-4a8f-b8ec-71a3279f2e07")
                        },
                        new
                        {
                            Id = new Guid("cb75f4fb-676f-4722-b298-a5f1ba86684e"),
                            AdvancedInfo = "Advanced info is empty",
                            Date = new DateTime(2021, 6, 23, 17, 30, 20, 0, DateTimeKind.Unspecified),
                            RepairId = new Guid("29b9d37c-3f23-4507-96b5-8506b291218b"),
                            StatusId = new Guid("23ea6ac5-a0a1-4da2-9102-5e7c472aa663")
                        });
                });

            modelBuilder.Entity("Intership.Data.Entities.ReplacedPart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("AdvancedInfo")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("advanced_info");

                    b.Property<int>("Count")
                        .HasColumnType("int")
                        .HasColumnName("replaced_part_count");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("replaced_part_name");

                    b.Property<double>("Price")
                        .HasColumnType("float")
                        .HasColumnName("price");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("product_id");

                    b.Property<Guid>("RepairId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("repair_id");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("RepairId");

                    b.ToTable("ReplacedParts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2f6b761f-24a5-4f50-94b8-2a27b1f21823"),
                            AdvancedInfo = "Advanced info is empty",
                            Count = 1,
                            Name = "Replacement part",
                            Price = 15.0,
                            ProductId = new Guid("80abbca8-554d-4b16-b5de-024705497d4a"),
                            RepairId = new Guid("b70d7e3e-35c7-4c24-acda-1472ae0c1d55")
                        },
                        new
                        {
                            Id = new Guid("4795f7f9-5c54-4426-9686-3bb27b9223a2"),
                            AdvancedInfo = "Advanced info is empty",
                            Count = 1,
                            Name = "Replacement part",
                            Price = 20.0,
                            ProductId = new Guid("3af8f791-6c93-4afb-820d-3c8bccc83bc4"),
                            RepairId = new Guid("228aea49-4717-4bf9-9cf4-585b33e54629")
                        },
                        new
                        {
                            Id = new Guid("d2ce0637-b66e-47ab-80f8-846ade723769"),
                            AdvancedInfo = "Advanced info is empty",
                            Count = 1,
                            Name = "Replacement part",
                            Price = 25.0,
                            ProductId = new Guid("3fc64654-f1e8-4563-ad8f-98c4c56a548a"),
                            RepairId = new Guid("260e7b03-cf9e-4824-8e3d-174f6fb73e49")
                        },
                        new
                        {
                            Id = new Guid("477bd3bc-182a-4997-9a48-3cb419e5ce82"),
                            AdvancedInfo = "Advanced info is empty",
                            Count = 2,
                            Name = "Replacement part",
                            Price = 10.0,
                            ProductId = new Guid("80abbca8-554d-4b16-b5de-024705497d4a"),
                            RepairId = new Guid("7478668c-1c7a-47ad-82c8-48c3744a1fdb")
                        },
                        new
                        {
                            Id = new Guid("0f65d970-5eb6-4e61-8630-a536dbe9fa98"),
                            AdvancedInfo = "Advanced info is empty",
                            Count = 3,
                            Name = "Replacement part",
                            Price = 5.0,
                            ProductId = new Guid("80abbca8-554d-4b16-b5de-024705497d4a"),
                            RepairId = new Guid("7d844508-2b92-4fe5-afc8-5e05382b9761")
                        },
                        new
                        {
                            Id = new Guid("882adfb5-628f-46fe-82da-44e91f5f4de9"),
                            AdvancedInfo = "Advanced info is empty",
                            Count = 2,
                            Name = "Replacement part",
                            Price = 30.0,
                            ProductId = new Guid("d3bfdeae-ad9e-44e2-b666-52e758c19dda"),
                            RepairId = new Guid("633693ac-2891-4fa9-99e9-ffbb9d33aa4b")
                        },
                        new
                        {
                            Id = new Guid("6ceb82ab-89b9-4a32-80c2-a6ac1c35c6e6"),
                            AdvancedInfo = "Advanced info is empty",
                            Count = 30,
                            Name = "Replacement part",
                            Price = 2.0,
                            ProductId = new Guid("9def4539-eb0b-4f28-ac0c-d7f4d7e18de0"),
                            RepairId = new Guid("530f0ff1-2d7e-4be0-80e3-77453658c9de")
                        },
                        new
                        {
                            Id = new Guid("b188a871-578f-41f8-8769-2f045028c464"),
                            AdvancedInfo = "Advanced info is empty",
                            Count = 3,
                            Name = "Replacement part",
                            Price = 7.5,
                            ProductId = new Guid("e357485f-cddd-4c92-8de7-702918e2bda8"),
                            RepairId = new Guid("04af2669-ed99-4517-9559-afd077ecd737")
                        },
                        new
                        {
                            Id = new Guid("e41aeec6-b638-4e13-ab30-92fdc681721c"),
                            AdvancedInfo = "Advanced info is empty",
                            Count = 50,
                            Name = "Replacement part",
                            Price = 1.5,
                            ProductId = new Guid("cae134c8-1faf-4e65-b08d-864367afeb21"),
                            RepairId = new Guid("c016f3c3-5189-469a-a580-1798d88882ee")
                        },
                        new
                        {
                            Id = new Guid("0cc0c42d-a52c-411e-9ffa-983acc519854"),
                            AdvancedInfo = "Advanced info is empty",
                            Count = 3,
                            Name = "Replacement part",
                            Price = 8.25,
                            ProductId = new Guid("338afc0c-7290-4c15-a5f5-cb091dea6ad3"),
                            RepairId = new Guid("29b9d37c-3f23-4507-96b5-8506b291218b")
                        });
                });

            modelBuilder.Entity("Intership.Data.Entities.Status", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("StatusInfo")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)")
                        .HasColumnName("status_info");

                    b.HasKey("Id");

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            Id = new Guid("38b4bbaa-2da2-4cec-b6c2-a84f9dd3fa32"),
                            StatusInfo = "New"
                        },
                        new
                        {
                            Id = new Guid("95b2d4fc-5356-42d8-9087-f1e292bd6bfb"),
                            StatusInfo = "Waiting to processing by agent"
                        },
                        new
                        {
                            Id = new Guid("d3a5ea06-44b2-43e8-89c1-8d5a17bd7791"),
                            StatusInfo = "Processing by agent"
                        },
                        new
                        {
                            Id = new Guid("cbdfc5bd-82a6-4a8f-b8ec-71a3279f2e07"),
                            StatusInfo = "Waiting to register the completing repair"
                        },
                        new
                        {
                            Id = new Guid("23ea6ac5-a0a1-4da2-9102-5e7c472aa663"),
                            StatusInfo = "Completed"
                        });
                });

            modelBuilder.Entity("Intership.Data.Entities.Repair", b =>
                {
                    b.HasOne("Intership.Data.Entities.Client", "Client")
                        .WithMany("Repairs")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Intership.Data.Entities.RepairInfo", b =>
                {
                    b.HasOne("Intership.Data.Entities.Repair", "Repair")
                        .WithOne("RepairInfo")
                        .HasForeignKey("Intership.Data.Entities.RepairInfo", "RepairId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Intership.Data.Entities.Status", "Status")
                        .WithMany("RepairsInfo")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Repair");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Intership.Data.Entities.ReplacedPart", b =>
                {
                    b.HasOne("Intership.Data.Entities.Product", "Product")
                        .WithMany("ReplacedParts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Intership.Data.Entities.Repair", "Repair")
                        .WithMany("ReplacedParts")
                        .HasForeignKey("RepairId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Repair");
                });

            modelBuilder.Entity("Intership.Data.Entities.Client", b =>
                {
                    b.Navigation("Repairs");
                });

            modelBuilder.Entity("Intership.Data.Entities.Product", b =>
                {
                    b.Navigation("ReplacedParts");
                });

            modelBuilder.Entity("Intership.Data.Entities.Repair", b =>
                {
                    b.Navigation("RepairInfo");

                    b.Navigation("ReplacedParts");
                });

            modelBuilder.Entity("Intership.Data.Entities.Status", b =>
                {
                    b.Navigation("RepairsInfo");
                });
#pragma warning restore 612, 618
        }
    }
}
