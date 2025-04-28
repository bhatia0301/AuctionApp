using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AuctionApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialDBSetUp : Migration
    {
        /// <inheritdoc />
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
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsBanned = table.Column<bool>(type: "bit", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
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
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartingPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    AuctionDuration = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ReservedPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ProductImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BoughtByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Auctions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentHighestBid = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    HighestBidUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BidCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auctions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Auctions_AspNetUsers_HighestBidUserId",
                        column: x => x.HighestBidUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Auctions_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bids",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuctionId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BidAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bids", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bids_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bids_Auctions_AuctionId",
                        column: x => x.AuctionId,
                        principalTable: "Auctions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5ad93cd7-35e6-4fc7-9690-714f86ec8ef2", "5ad93cd7-35e6-4fc7-9690-714f86ec8ef2", "Admin", "ADMIN" },
                    { "ac5e271a-005b-4ec8-8bdd-86571bdcdb1a", "ac5e271a-005b-4ec8-8bdd-86571bdcdb1a", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "IsBanned", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "279e30e5-426d-449e-86c8-c2a89ffc1ada", 0, "094bfe96-4011-4b64-828a-1b8dab47b65f", "ishita@gmail.com", true, "Ishita Roy", false, false, null, "ISHITA@GMAIL.COM", "ISHITA@GMAIL.COM", "AQAAAAIAAYagAAAAEN2ekXXkVMbbS4TzFVPb4DNwc7uwx/oC4S+bbRoeogMsk6wEbpvmG2ANG1gQdgqo5g==", "6851114378", false, "User", "279e30e5-426d-449e-86c8-c2a89ffc1ada", false, "ishita@gmail.com" },
                    { "41377029-b399-409c-8da2-7a4bcf802978", 0, "242b9571-6f4b-4cff-a10b-bbc9cd335f2d", "admin01@gmail.com", true, "Admin", false, false, null, "ADMIN01@GMAIL.COM", "ADMIN01@GMAIL.COM", "AQAAAAIAAYagAAAAEFY0rO92Y0MrcP7hgbO5XEpw5u1iSqXV/bSaKLVm/JkVkh9Geqa28hQW+xw8Axy0Sw==", "9851234567", false, "Admin", "41377029-b399-409c-8da2-7a4bcf802978", false, "admin01@gmail.com" },
                    { "4732b433-fd9c-48d3-8cb3-eccee797cb0d", 0, "b191400a-dc90-45ee-8b94-7caf5dd77731", "khushi@gmail.com", true, "Khushi Seth", false, false, null, "KHUSHI@GMAIL.COM", "KHUSHI@GMAIL.COM", "AQAAAAIAAYagAAAAECIT0SeV1XKaWTB6PZP535L4SODC/+CGGmLMsIT8KgaFSXTB80buawYAJ++C5dTXxw==", "7920012980", false, "User", "4732b433-fd9c-48d3-8cb3-eccee797cb0d", false, "khushi@gmail.com" },
                    { "6e3fccd2-60fb-4090-b281-33f0405d6a45", 0, "fa9e922a-7811-4c6b-95f8-e1d176a1dafe", "rohit@gmail.com", true, "Rohit Sharma", false, false, null, "ROHIT@GMAIL.COM", "ROHIT@GMAIL.COM", "AQAAAAIAAYagAAAAEN3mQPs3TFY1SU/DkdeeJYUbrZIRqDTvcpMDaTSYXvvxrRxL0sOB7hWRPNrznfC2Fg==", "7853454569", false, "User", "6e3fccd2-60fb-4090-b281-33f0405d6a45", false, "rohit@gmail.com" },
                    { "77311c10-f548-4e65-8bd5-5df2dd774c1c", 0, "10722e5c-5d95-4134-88eb-d5e0e2c49ef2", "abhi@gmail.com", true, "Abhi Verma", false, false, null, "ABHI@GMAIL.COM", "ABHI@GMAIL.COM", "AQAAAAIAAYagAAAAEFKp6S8ge97tem7QUYfAkSEW2wtsmRACHVO84bDbtWdlnqjY2uAimbch5OaNnxTRGA==", "6642714567", false, "User", "77311c10-f548-4e65-8bd5-5df2dd774c1c", false, "abhi@gmail.com" },
                    { "9bba7a43-19df-46d5-97ad-b1cf29053c02", 0, "0509b5fb-b87b-4670-8c9a-9ac90ade760c", "rahul@gmail.com", true, "Rahul Tiwari", false, false, null, "RAHUL@GMAIL.COM", "RAHUL@GMAIL.COM", "AQAAAAIAAYagAAAAEPaW2YH3GZzJRRfb1QLYiaFL7gDLu6DaHLQfmaFXNj3TNt8PM3X9SLgeCBdgcyGXkg==", "9921184560", false, "User", "9bba7a43-19df-46d5-97ad-b1cf29053c02", false, "rahul@gmail.com" },
                    { "9c8c7ba1-9f91-4ee4-8d47-fac0125dc74c", 0, "b18b4165-ab04-4680-9d4f-8db1705d4e52", "admin02@gmail.com", true, "Admin", false, false, null, "ADMIN02@GMAIL.COM", "ADMIN02@GMAIL.COM", "AQAAAAIAAYagAAAAEOtFBC4nwFmKcZWpheK/E57xOUi8ihvblksx6bP0q+rMMFPIy9KUv/pLoGkx0f/iKw==", "9851232351", false, "Admin", "9c8c7ba1-9f91-4ee4-8d47-fac0125dc74c", false, "admin02@gmail.com" },
                    { "ad014415-a368-4a32-9351-a8abf2485393", 0, "7ade9fbc-e6ba-4a77-be16-3d7356204c6e", "nitin@gmail.com", true, "Nitin Kumar", false, false, null, "NITIN@GMAIL.COM", "NITIN@GMAIL.COM", "AQAAAAIAAYagAAAAEH1Dl2R2UyD51C+gYrt4I5b+bpmDBYS0pIlp2nTphzPDFZg6YQAxdStxAha0ofYCgQ==", "8851114567", false, "User", "ad014415-a368-4a32-9351-a8abf2485393", false, "nitin@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "ac5e271a-005b-4ec8-8bdd-86571bdcdb1a", "279e30e5-426d-449e-86c8-c2a89ffc1ada" },
                    { "5ad93cd7-35e6-4fc7-9690-714f86ec8ef2", "41377029-b399-409c-8da2-7a4bcf802978" },
                    { "ac5e271a-005b-4ec8-8bdd-86571bdcdb1a", "4732b433-fd9c-48d3-8cb3-eccee797cb0d" },
                    { "ac5e271a-005b-4ec8-8bdd-86571bdcdb1a", "6e3fccd2-60fb-4090-b281-33f0405d6a45" },
                    { "ac5e271a-005b-4ec8-8bdd-86571bdcdb1a", "77311c10-f548-4e65-8bd5-5df2dd774c1c" },
                    { "ac5e271a-005b-4ec8-8bdd-86571bdcdb1a", "9bba7a43-19df-46d5-97ad-b1cf29053c02" },
                    { "5ad93cd7-35e6-4fc7-9690-714f86ec8ef2", "9c8c7ba1-9f91-4ee4-8d47-fac0125dc74c" },
                    { "ac5e271a-005b-4ec8-8bdd-86571bdcdb1a", "ad014415-a368-4a32-9351-a8abf2485393" }
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
                name: "IX_Auctions_HighestBidUserId",
                table: "Auctions",
                column: "HighestBidUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Auctions_ProductId",
                table: "Auctions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_AuctionId",
                table: "Bids",
                column: "AuctionId");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_UserId",
                table: "Bids",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UserId",
                table: "Products",
                column: "UserId");
        }

        /// <inheritdoc />
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
                name: "Bids");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Auctions");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
