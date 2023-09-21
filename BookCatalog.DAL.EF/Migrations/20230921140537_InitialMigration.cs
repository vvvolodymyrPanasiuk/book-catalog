using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookCatalog.DAL.EF.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PublicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PageCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Description", "PageCount", "PublicationDate", "Title" },
                values: new object[,]
                {
                    { new Guid("00f3f660-08fd-41c1-b7a2-951b63696458"), "Description for Book 4", 40, new DateTime(2023, 9, 17, 0, 0, 0, 0, DateTimeKind.Local), "Book 4" },
                    { new Guid("0384694d-1bf7-4315-a6ed-e403edabc7ed"), "Description for Book 12", 120, new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Local), "Book 12" },
                    { new Guid("0636ccf7-87f5-46c6-93d2-abe1caad5daf"), "Description for Book 28", 280, new DateTime(2023, 8, 24, 0, 0, 0, 0, DateTimeKind.Local), "Book 28" },
                    { new Guid("0da409b0-e062-462a-a170-6fa8907077eb"), "Description for Book 13", 130, new DateTime(2023, 9, 8, 0, 0, 0, 0, DateTimeKind.Local), "Book 13" },
                    { new Guid("14b29c2f-cb24-432a-8edc-d45a4bdce3b6"), "Description for Book 5", 5, new DateTime(2023, 9, 11, 0, 0, 0, 0, DateTimeKind.Local), "Book 5" },
                    { new Guid("2cd410e9-6ab1-4217-871c-dcdb01a84b83"), "Description for Book 18", 180, new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Local), "Book 18" },
                    { new Guid("3040ddc4-5f16-40ed-9d69-125e249b7a4e"), "Description for Book 22", 220, new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Local), "Book 22" },
                    { new Guid("40aaca33-54ae-4dc9-bf2e-5023865003ba"), "Description for Book 49", 490, new DateTime(2023, 8, 3, 0, 0, 0, 0, DateTimeKind.Local), "Book 49" },
                    { new Guid("44fdbe9a-cd44-49cd-941a-d311bba9dd2e"), "Description for Book 21", 210, new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Local), "Book 21" },
                    { new Guid("46fd9d2d-5701-45ff-82cf-ab54725201dc"), "Description for Book 48", 480, new DateTime(2023, 8, 4, 0, 0, 0, 0, DateTimeKind.Local), "Book 48" },
                    { new Guid("4b06e75f-bd08-4dab-aacb-4a4c3fa9443e"), "Description for Book 46", 460, new DateTime(2023, 8, 6, 0, 0, 0, 0, DateTimeKind.Local), "Book 46" },
                    { new Guid("5015bb03-f71d-4721-a4f5-c76867bf2561"), "Description for Book 14", 140, new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Local), "Book 14" },
                    { new Guid("51c657d6-99da-4a4c-8926-db81db19190b"), "Description for Book 9", 90, new DateTime(2023, 9, 12, 0, 0, 0, 0, DateTimeKind.Local), "Book 9" },
                    { new Guid("57679eba-bcfa-42c0-9ebb-b92191f66080"), "Description for Book 20", 20, new DateTime(2023, 8, 12, 0, 0, 0, 0, DateTimeKind.Local), "Book 20" },
                    { new Guid("628b5235-5fbd-4f41-a881-eece17e79cf7"), "Description for Book 33", 330, new DateTime(2023, 8, 19, 0, 0, 0, 0, DateTimeKind.Local), "Book 33" },
                    { new Guid("68f9fa12-f3ad-4d07-8301-607f42bc80af"), "Description for Book 47", 470, new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Local), "Book 47" },
                    { new Guid("6a6d2934-1f49-4f70-b2cf-124d4d8ed34d"), "Description for Book 2", 20, new DateTime(2023, 9, 19, 0, 0, 0, 0, DateTimeKind.Local), "Book 2" },
                    { new Guid("71392f48-b247-4001-b306-ba75ba8f1d26"), "Description for Book 0", 0, new DateTime(2023, 9, 21, 0, 0, 0, 0, DateTimeKind.Local), "Book 0" },
                    { new Guid("729af3ef-82e8-4095-a357-f2770feefe75"), "Description for Book 3", 30, new DateTime(2023, 9, 18, 0, 0, 0, 0, DateTimeKind.Local), "Book 3" },
                    { new Guid("7a27d6b4-c68d-4a37-a437-744639a3fcb9"), "Description for Book 8", 80, new DateTime(2023, 9, 13, 0, 0, 0, 0, DateTimeKind.Local), "Book 8" },
                    { new Guid("80eda9f1-dd17-423a-9913-628a6fa890e7"), "Description for Book 37", 370, new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Local), "Book 37" },
                    { new Guid("823d1635-24be-41f2-8102-e536890778f3"), "Description for Book 32", 320, new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Local), "Book 32" },
                    { new Guid("83ea80d2-55bf-49be-bb2f-9f1d73358e61"), "Description for Book 38", 380, new DateTime(2023, 8, 14, 0, 0, 0, 0, DateTimeKind.Local), "Book 38" },
                    { new Guid("85c85e80-7006-4767-b8f4-fb404a8a3420"), "Description for Book 36", 360, new DateTime(2023, 8, 16, 0, 0, 0, 0, DateTimeKind.Local), "Book 36" },
                    { new Guid("85e701b0-eaa1-4c99-969c-670869961c1f"), "Description for Book 11", 110, new DateTime(2023, 9, 10, 0, 0, 0, 0, DateTimeKind.Local), "Book 11" },
                    { new Guid("8f1e3639-f548-47fd-9f1b-8d2fe0360556"), "Description for Book 34", 340, new DateTime(2023, 8, 18, 0, 0, 0, 0, DateTimeKind.Local), "Book 34" },
                    { new Guid("95dab451-30e9-4e34-9922-c888ce2e2b35"), "Description for Book 19", 190, new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Local), "Book 19" },
                    { new Guid("99e32b98-5b8a-45dd-9231-d811c4a299f9"), "Description for Book 41", 410, new DateTime(2023, 8, 11, 0, 0, 0, 0, DateTimeKind.Local), "Book 41" },
                    { new Guid("9b1197b0-30f4-4d55-aafa-da6cb807ef6f"), "Description for Book 1", 10, new DateTime(2023, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), "Book 1" },
                    { new Guid("9e9829c7-a27a-445d-9164-a517fe9b8dff"), "Description for Book 24", 240, new DateTime(2023, 8, 28, 0, 0, 0, 0, DateTimeKind.Local), "Book 24" },
                    { new Guid("a3d91e02-9b94-46d5-a7ba-dcf18d273001"), "Description for Book 30", 30, new DateTime(2023, 7, 23, 0, 0, 0, 0, DateTimeKind.Local), "Book 30" },
                    { new Guid("a5977c02-4041-4976-b206-7eb393856361"), "Description for Book 42", 420, new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Local), "Book 42" },
                    { new Guid("a8044022-6f30-47b0-9574-daeb79c3c851"), "Description for Book 23", 230, new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Local), "Book 23" },
                    { new Guid("a9501a80-aec5-438f-b2c8-b438abf60acd"), "Description for Book 44", 440, new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Local), "Book 44" },
                    { new Guid("ac1b3f14-4f96-4e6f-a6b7-e3591f459273"), "Description for Book 15", 15, new DateTime(2023, 8, 22, 0, 0, 0, 0, DateTimeKind.Local), "Book 15" },
                    { new Guid("b3c47cc9-0a0e-4f1f-a9e0-80fc1269926e"), "Description for Book 39", 390, new DateTime(2023, 8, 13, 0, 0, 0, 0, DateTimeKind.Local), "Book 39" },
                    { new Guid("b63b912b-fbb9-4ed0-a143-016ca2ca17d4"), "Description for Book 29", 290, new DateTime(2023, 8, 23, 0, 0, 0, 0, DateTimeKind.Local), "Book 29" },
                    { new Guid("c55a0781-5dd4-496d-933d-770896f54875"), "Description for Book 16", 160, new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Local), "Book 16" },
                    { new Guid("ce752470-7a99-4592-8307-e6ffd8bc6508"), "Description for Book 27", 270, new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Local), "Book 27" },
                    { new Guid("cf85653b-b46b-41ac-a819-441b1a9c6707"), "Description for Book 40", 40, new DateTime(2023, 7, 3, 0, 0, 0, 0, DateTimeKind.Local), "Book 40" },
                    { new Guid("d425148d-f9db-4066-9b8e-cc6db298af88"), "Description for Book 31", 310, new DateTime(2023, 8, 21, 0, 0, 0, 0, DateTimeKind.Local), "Book 31" },
                    { new Guid("d570c707-f6ea-4b4c-b6b5-69623b76e250"), "Description for Book 43", 430, new DateTime(2023, 8, 9, 0, 0, 0, 0, DateTimeKind.Local), "Book 43" },
                    { new Guid("d8022eaa-e83c-45b1-9e18-11fadb1ce37f"), "Description for Book 25", 25, new DateTime(2023, 8, 2, 0, 0, 0, 0, DateTimeKind.Local), "Book 25" },
                    { new Guid("db4051d0-8c03-4bd9-ba4c-c371d2087c50"), "Description for Book 7", 70, new DateTime(2023, 9, 14, 0, 0, 0, 0, DateTimeKind.Local), "Book 7" },
                    { new Guid("dc7ccfc1-3a54-4ee7-b4de-56c23aa52ffd"), "Description for Book 10", 10, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Local), "Book 10" },
                    { new Guid("e01a21c3-8b2c-48f3-80cb-b1be0b6b5ece"), "Description for Book 17", 170, new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Local), "Book 17" },
                    { new Guid("e673d23f-de31-43d8-81f5-1fb74ad50351"), "Description for Book 45", 45, new DateTime(2023, 6, 23, 0, 0, 0, 0, DateTimeKind.Local), "Book 45" },
                    { new Guid("e9523829-b0e6-49da-8a63-4839886fee2a"), "Description for Book 26", 260, new DateTime(2023, 8, 26, 0, 0, 0, 0, DateTimeKind.Local), "Book 26" },
                    { new Guid("f460bd0c-7a3d-448e-a4d3-1658abab5435"), "Description for Book 6", 60, new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Local), "Book 6" },
                    { new Guid("fb924469-5d47-47b1-8d69-e3a3a36fffcf"), "Description for Book 35", 35, new DateTime(2023, 7, 13, 0, 0, 0, 0, DateTimeKind.Local), "Book 35" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_PageCount",
                table: "Books",
                column: "PageCount");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublicationDate",
                table: "Books",
                column: "PublicationDate");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Title",
                table: "Books",
                column: "Title");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
