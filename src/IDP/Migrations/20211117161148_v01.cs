using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IDP.Migrations
{
    public partial class v01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
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
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
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
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("0110b1f9-8e0b-4a4f-a52e-dd20c3d4a539"), "607302ac-6283-4ace-a8e2-cb324a00111d", "User", "USER" },
                    { new Guid("0210b1f9-8e0b-4a4f-a52e-dd20c3d4a539"), "9c5afc6c-4361-4348-a4e7-dabd4056fb7e", "Admin", "ADMIN" },
                    { new Guid("0310b1f9-8e0b-4a4f-a52e-dd20c3d4a539"), "865f255e-0aef-4168-a7de-e6e86e75b563", "Root", "ROOT" },
                    { new Guid("0410b1f9-8e0b-4a4f-a52e-dd20c3d4a539"), "91ba73c1-3c13-4aaf-9b15-f64abd2578c3", "Spare1", "SPARE1" },
                    { new Guid("0510b1f9-8e0b-4a4f-a52e-dd20c3d4a539"), "0995f152-34ae-4c9f-b14b-1b603a48db26", "Spare2", "SPARE2" },
                    { new Guid("0610b1f9-8e0b-4a4f-a52e-dd20c3d4a539"), "31b9dfb7-83bb-4092-9561-1cc956060523", "Masters_Degree_In_Forestry", "Masters_Degree_In_Forestry" },
                    { new Guid("0710b1f9-8e0b-4a4f-a52e-dd20c3d4a539"), "1816db76-ddd2-4cb1-94ac-de769485e31a", "Masters_Degree_In_Forestry", "Masters_Degree_In_Mining" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("2798f549-e790-4e9f-aa16-18c2292a2ee9"), 0, "2534cd7f-f63a-408f-8d9b-7d0784ae85bf", "FRIEND5@USER.com", true, false, null, "FRIEND5@USER.com", "FRIEND5@USER.com", "AQAAAAEAACcQAAAAEPsIDhvaU3ISUDKSCMvsTXf0vHzGvMCW+YC+HM2eZneQ9LFAEbCJw1Ba0RPr36USvQ==", null, false, null, false, "FRIEND5@USER.com" },
                    { new Guid("2698f549-e790-4e9f-aa16-18c2292a2ee9"), 0, "af4f48d4-37bf-424b-9432-1ed30be23d32", "FRIEND4@USER.com", true, false, null, "FRIEND4@USER.com", "FRIEND4@USER.com", "AQAAAAEAACcQAAAAEJlF0DwmN5Apm/y9RnQ57mgzZfgRUTdSdjybdTcyUEpDEBTNU+7PnthCCTeFhWpfgg==", null, false, null, false, "FRIEND4@USER.com" },
                    { new Guid("2598f549-e790-4e9f-aa16-18c2292a2ee9"), 0, "681a377a-b22a-42b4-b7ab-4e0b7f396c39", "FRIEND3@USER.com", true, false, null, "FRIEND3@USER.com", "FRIEND3@USER.com", "AQAAAAEAACcQAAAAEM8TX6FrmoIxdCZUy5e3Gqes53spsBNrgWU4m6RMZbGx67YUsvTN7UjnZMWt2+EqnA==", null, false, null, false, "FRIEND3@USER.com" },
                    { new Guid("2498f549-e790-4e9f-aa16-18c2292a2ee9"), 0, "9c1e0c39-34da-4d04-aabd-3350dc8ed070", "FRIEND2@USER.com", true, false, null, "FRIEND2@USER.com", "FRIEND2@USER.com", "AQAAAAEAACcQAAAAEG8i/Wy/fGiI3umVsajF4BZ6vnAesYtWrmjM42Kf7XO/M+7kKF3jjN6zT6SJmm7dFQ==", null, false, null, false, "FRIEND2@USER.com" },
                    { new Guid("2113179f-7837-473a-a4d5-a5571b43e6a6"), 0, "9332437c-ff60-4dd7-b1c7-6ba94b828e9c", "ROOT@ROOT.com", true, false, null, "ROOT@ROOT.com", "ROOT@ROOT.com", "AQAAAAEAACcQAAAAEBuAxQP909NQfAIWCI8+EklwPhgqPRMiqPywTUyW8PzPZ8BRSXkazjTunnJOXLMlDA==", null, false, null, false, "ROOT@ROOT.com" },
                    { new Guid("223f3002-7e53-441e-8b76-f6280be284aa"), 0, "54d8f34a-2ef3-44ff-b84c-3369aa3ad2e8", "USER@USER.com", true, false, null, "USER@USER.com", "USER@USER.com", "AQAAAAEAACcQAAAAECAoAom7liMz1GodY62fJFp/PEhCy2yprMjFHbaMRGOheDIR0Qdb9TptJCSyH5A2aQ==", null, false, null, false, "USER@USER.com" },
                    { new Guid("2898f549-e790-4e9f-aa16-18c2292a2ee9"), 0, "5ab19b5b-0726-4452-904e-a2861771f4f1", "FRIEND6@USER.com", true, false, null, "FRIEND6@USER.com", "FRIEND6@USER.com", "AQAAAAEAACcQAAAAEPf5e3VoeRV+HYZVFFBwDLPP8OPdQ/mPjQTk/TWfnEc/bekyaTRJarzS5ocVOLFaZQ==", null, false, null, false, "FRIEND6@USER.com" },
                    { new Guid("20788d2f-8003-43c1-92a4-edc76a7c5dde"), 0, "a817e67f-ee13-4776-9a30-3c0cb00ac316", "ADMIN@ADMIN.com", true, false, null, "ADMIN@ADMIN.com", "ADMIN@ADMIN.com", "AQAAAAEAACcQAAAAEHboeogtYYQcixrU8aQ9Qai2jXOEThfvJESaeQTRnhpwAYWaMR1/rXAH/yRSdhteEg==", null, false, null, false, "ADMIN@ADMIN.com" },
                    { new Guid("2398f549-e790-4e9f-aa16-18c2292a2ee9"), 0, "c6c4d505-cc63-49ad-92e6-8fb1ee44966f", "FRIEND1@USER.com", true, false, null, "FRIEND1@USER.com", "FRIEND1@USER.com", "AQAAAAEAACcQAAAAEFqNc2wFYmYyJkSXwBzvNjvnsDiYvPh9PXoMlxFBKfZ1Ruzz0jeowZNJ4fFcI7qLEw==", null, false, null, false, "FRIEND1@USER.com" },
                    { new Guid("2998f549-e790-4e9f-aa16-18c2292a2ee9"), 0, "767de5f5-66c7-4a4e-82ac-3dd8c7f01edf", "FRIEND7@USER.com", true, false, null, "FRIEND7@USER.com", "FRIEND7@USER.com", "AQAAAAEAACcQAAAAEE+8qS9gKDqrlSRCQDiDWjnvsAdBpBa7k/YGb4B6R+P8bbxhZxcankoTRIVlq3s3Ng==", null, false, null, false, "FRIEND7@USER.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("20788d2f-8003-43c1-92a4-edc76a7c5dde"), new Guid("0210b1f9-8e0b-4a4f-a52e-dd20c3d4a539") },
                    { new Guid("20788d2f-8003-43c1-92a4-edc76a7c5dde"), new Guid("0110b1f9-8e0b-4a4f-a52e-dd20c3d4a539") },
                    { new Guid("2113179f-7837-473a-a4d5-a5571b43e6a6"), new Guid("0310b1f9-8e0b-4a4f-a52e-dd20c3d4a539") },
                    { new Guid("2113179f-7837-473a-a4d5-a5571b43e6a6"), new Guid("0110b1f9-8e0b-4a4f-a52e-dd20c3d4a539") },
                    { new Guid("223f3002-7e53-441e-8b76-f6280be284aa"), new Guid("0110b1f9-8e0b-4a4f-a52e-dd20c3d4a539") },
                    { new Guid("2398f549-e790-4e9f-aa16-18c2292a2ee9"), new Guid("0110b1f9-8e0b-4a4f-a52e-dd20c3d4a539") },
                    { new Guid("2498f549-e790-4e9f-aa16-18c2292a2ee9"), new Guid("0110b1f9-8e0b-4a4f-a52e-dd20c3d4a539") },
                    { new Guid("2598f549-e790-4e9f-aa16-18c2292a2ee9"), new Guid("0110b1f9-8e0b-4a4f-a52e-dd20c3d4a539") },
                    { new Guid("2698f549-e790-4e9f-aa16-18c2292a2ee9"), new Guid("0110b1f9-8e0b-4a4f-a52e-dd20c3d4a539") },
                    { new Guid("2798f549-e790-4e9f-aa16-18c2292a2ee9"), new Guid("0110b1f9-8e0b-4a4f-a52e-dd20c3d4a539") },
                    { new Guid("2898f549-e790-4e9f-aa16-18c2292a2ee9"), new Guid("0110b1f9-8e0b-4a4f-a52e-dd20c3d4a539") },
                    { new Guid("2998f549-e790-4e9f-aa16-18c2292a2ee9"), new Guid("0110b1f9-8e0b-4a4f-a52e-dd20c3d4a539") }
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
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
