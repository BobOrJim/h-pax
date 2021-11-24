using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IDP.Migrations
{
    public partial class V01 : Migration
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
                    { new Guid("0110b1f9-8e0b-4a4f-a52e-dd20c3d4a539"), "a65c39f2-fea0-44e2-8352-95b288027d94", "User", "USER" },
                    { new Guid("0210b1f9-8e0b-4a4f-a52e-dd20c3d4a539"), "ef0a0978-7de1-459e-8002-bec95ca0e637", "Admin", "ADMIN" },
                    { new Guid("0310b1f9-8e0b-4a4f-a52e-dd20c3d4a539"), "ed767924-6add-4529-b663-a79bb9fcc4e9", "Root", "ROOT" },
                    { new Guid("0410b1f9-8e0b-4a4f-a52e-dd20c3d4a539"), "ace8160a-0eb2-4e27-81f9-bc6fb32628b4", "Spare1", "SPARE1" },
                    { new Guid("0510b1f9-8e0b-4a4f-a52e-dd20c3d4a539"), "677cc527-436c-42d0-af16-08cb4b2f3d24", "Spare2", "SPARE2" },
                    { new Guid("0610b1f9-8e0b-4a4f-a52e-dd20c3d4a539"), "e8ee73b8-dbe1-4811-815d-d938732255bd", "Masters_Degree_In_Forestry", "Masters_Degree_In_Forestry" },
                    { new Guid("0710b1f9-8e0b-4a4f-a52e-dd20c3d4a539"), "771173f7-ed57-49b8-8b63-7e9a9b81ff84", "Masters_Degree_In_Forestry", "Masters_Degree_In_Mining" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("2798f549-e790-4e9f-aa16-18c2292a2ee9"), 0, "1cb7f339-06c9-4658-9e45-7f0fce3ab2bc", "FRIEND5@USER.com", true, false, null, "FRIEND5@USER.com", "FRIEND5@USER.com", "AQAAAAEAACcQAAAAEFAOI+4Fq61VfEmc89mkktO0ulvBnPT7decZs6S5jADCpEepIwjX/NCYnrwwn2H+ww==", null, false, "5966f0ff-ada0-4daa-94af-07cdc125a7b6", false, "FRIEND5@USER.com" },
                    { new Guid("2698f549-e790-4e9f-aa16-18c2292a2ee9"), 0, "9e7c384d-f598-4d1e-84da-4b7acabf5e95", "FRIEND4@USER.com", true, false, null, "FRIEND4@USER.com", "FRIEND4@USER.com", "AQAAAAEAACcQAAAAEGUD1nfuXvgtL8RvAiHpr8Qb4CplBHOk/gi+NIx+pVDc869TAmyAmVL3dViQaq7Ksw==", null, false, "a268d7d3-bb09-4e06-ad81-a8b258ca2f1b", false, "FRIEND4@USER.com" },
                    { new Guid("2598f549-e790-4e9f-aa16-18c2292a2ee9"), 0, "6fb82e55-ee2f-4e8b-b9bb-29070993a913", "FRIEND3@USER.com", true, false, null, "FRIEND3@USER.com", "FRIEND3@USER.com", "AQAAAAEAACcQAAAAEAXWyXQ3gjTw+4ZLW3hju2qJ3dGyLPKhWJJ/OGFZZV9shUrJu946JW/1N1ldn7fOiQ==", null, false, "055d80af-60df-4f25-a2ef-cefefabd54b4", false, "FRIEND3@USER.com" },
                    { new Guid("2498f549-e790-4e9f-aa16-18c2292a2ee9"), 0, "a518b260-058b-490a-b62b-b6b62acde2b5", "FRIEND2@USER.com", true, false, null, "FRIEND2@USER.com", "FRIEND2@USER.com", "AQAAAAEAACcQAAAAEPpsj74KIv0Rvv4Ha7uLlARPlKf83PoRzSEWSliVW2BcqHIQZ6ShsN40lAhlXK5jDQ==", null, false, "ade158aa-cbdb-4382-ae97-f05abfee1fce", false, "FRIEND2@USER.com" },
                    { new Guid("2113179f-7837-473a-a4d5-a5571b43e6a6"), 0, "6355465b-628a-4c0b-b5df-1485b29fbfd1", "ROOT@ROOT.com", true, false, null, "ROOT@ROOT.com", "ROOT@ROOT.com", "AQAAAAEAACcQAAAAEG12pDD6TOFEzs9ZP829QRzTqEAQph6J15NpkhtJk89zh6IqDLwcVCskDjht24+rRw==", null, false, "ba4a67d4-142f-4009-abdf-60a80e601bc1", false, "ROOT@ROOT.com" },
                    { new Guid("223f3002-7e53-441e-8b76-f6280be284aa"), 0, "6f79d491-0173-4099-9bdf-3b1626998a03", "USER@USER.com", true, false, null, "USER@USER.com", "USER@USER.com", "AQAAAAEAACcQAAAAEItEAlTjfaC9DXV6USP4uX/C7qjjDZbnCyoYRpu+XhMfKhct6jT5x+Cg3msLw53TKg==", null, false, "39483c47-0ad3-4b90-82d8-c8a63e418410", false, "USER@USER.com" },
                    { new Guid("2898f549-e790-4e9f-aa16-18c2292a2ee9"), 0, "171ee182-f470-4e8f-99fc-b2e6690eb201", "FRIEND6@USER.com", true, false, null, "FRIEND6@USER.com", "FRIEND6@USER.com", "AQAAAAEAACcQAAAAEEEaJslF0J7JkiaTeZL509GqJ47KRk8jTiyXLXdEwE0mUgg+CF4QyL9GrYTVbsTm7w==", null, false, "b4148cb9-2a78-41d6-8569-593e477ac520", false, "FRIEND6@USER.com" },
                    { new Guid("20788d2f-8003-43c1-92a4-edc76a7c5dde"), 0, "8d9e9daa-946c-4d17-a115-997b3b8b89ea", "ADMIN@ADMIN.com", true, false, null, "ADMIN@ADMIN.com", "ADMIN@ADMIN.com", "AQAAAAEAACcQAAAAEEMN8ieJRgbLJ303e+jnjsKxkKw5z7x5xLnJQgciWGZernXyMsZeuwJrCBDQ1XSHNQ==", null, false, "471ee140-1f96-4869-8449-0bb25425ba6b", false, "ADMIN@ADMIN.com" },
                    { new Guid("2398f549-e790-4e9f-aa16-18c2292a2ee9"), 0, "d6576aa7-01b8-4bb8-8317-8b9bf1bec1c3", "FRIEND1@USER.com", true, false, null, "FRIEND1@USER.com", "FRIEND1@USER.com", "AQAAAAEAACcQAAAAEFkUZBt87fuRxrinkBQnuxQZ9F4UNdrFjyuoXsEVQitQj15uZ2btdwSfmyDNU39l6Q==", null, false, "2951f404-84b3-41ab-8e4e-ba854636ca56", false, "FRIEND1@USER.com" },
                    { new Guid("2998f549-e790-4e9f-aa16-18c2292a2ee9"), 0, "4ce941b1-1312-4596-9544-01474fbe57e6", "FRIEND7@USER.com", true, false, null, "FRIEND7@USER.com", "FRIEND7@USER.com", "AQAAAAEAACcQAAAAEF5pRTLQtbrtP5KTsJdO3gzzmOfOP+UalfbMxzBl4nFS/zAxJxW43LQRvZWoRPoT/w==", null, false, "01b30284-7fa3-4946-96ce-2f6139c0cbc1", false, "FRIEND7@USER.com" }
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
