using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIBasket.Migrations
{
    public partial class v01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Baskets",
                columns: table => new
                {
                    BasketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CouponId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baskets", x => x.BasketId);
                });

            migrationBuilder.CreateTable(
                name: "BasketLines",
                columns: table => new
                {
                    BasketLineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BasketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketLines", x => x.BasketLineId);
                    table.ForeignKey(
                        name: "FK_BasketLines_Baskets_BasketId",
                        column: x => x.BasketId,
                        principalTable: "Baskets",
                        principalColumn: "BasketId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Baskets",
                columns: new[] { "BasketId", "CouponId", "UserId" },
                values: new object[] { new Guid("b650b275-5ce8-4fcc-afc4-56005109e2e5"), null, new Guid("20788d2f-8003-43c1-92a4-edc76a7c5dde") });

            migrationBuilder.InsertData(
                table: "Baskets",
                columns: new[] { "BasketId", "CouponId", "UserId" },
                values: new object[] { new Guid("8b19d011-3710-4b87-9b5f-2a1e6ee1404b"), null, new Guid("20788d2f-8003-43c1-92a4-edc76a7c5dde") });

            migrationBuilder.InsertData(
                table: "Baskets",
                columns: new[] { "BasketId", "CouponId", "UserId" },
                values: new object[] { new Guid("d650b275-5ce8-4fcc-afc4-56005109e2e5"), null, new Guid("2398f549-e790-4e9f-aa16-18c2292a2ee9") });

            migrationBuilder.InsertData(
                table: "BasketLines",
                columns: new[] { "BasketLineId", "Amount", "BasketId", "Price", "ProductId" },
                values: new object[,]
                {
                    { new Guid("a94d70c5-1217-463b-b318-93679084bada"), 1, new Guid("b650b275-5ce8-4fcc-afc4-56005109e2e5"), 21, new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde") },
                    { new Guid("b94d70c5-1217-463b-b318-93679084bada"), 2, new Guid("b650b275-5ce8-4fcc-afc4-56005109e2e5"), 22, new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6") },
                    { new Guid("c94d70c5-1217-463b-b318-93679084bada"), 1, new Guid("b650b275-5ce8-4fcc-afc4-56005109e2e5"), 23, new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa") },
                    { new Guid("972b1de4-fd41-4d6d-8d7a-cf80219e60d7"), 3, new Guid("8b19d011-3710-4b87-9b5f-2a1e6ee1404b"), 24, new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9") },
                    { new Guid("a72b1de4-fd41-4d6d-8d7a-cf80219e60d7"), 1, new Guid("8b19d011-3710-4b87-9b5f-2a1e6ee1404b"), 25, new Guid("1098f549-e790-4e9f-aa16-18c2292a2ee9") },
                    { new Guid("b72b1de4-fd41-4d6d-8d7a-cf80219e60d7"), 1, new Guid("8b19d011-3710-4b87-9b5f-2a1e6ee1404b"), 26, new Guid("1198f549-e790-4e9f-aa16-18c2292a2ee9") },
                    { new Guid("c72b1de4-fd41-4d6d-8d7a-cf80219e60d7"), 1, new Guid("d650b275-5ce8-4fcc-afc4-56005109e2e5"), 27, new Guid("1298f549-e790-4e9f-aa16-18c2292a2ee9") },
                    { new Guid("d72b1de4-fd41-4d6d-8d7a-cf80219e60d7"), 1, new Guid("d650b275-5ce8-4fcc-afc4-56005109e2e5"), 28, new Guid("1398f549-e790-4e9f-aa16-18c2292a2ee9") },
                    { new Guid("e72b1de4-fd41-4d6d-8d7a-cf80219e60d7"), 1, new Guid("d650b275-5ce8-4fcc-afc4-56005109e2e5"), 29, new Guid("1498f549-e790-4e9f-aa16-18c2292a2ee9") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasketLines_BasketId",
                table: "BasketLines",
                column: "BasketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketLines");

            migrationBuilder.DropTable(
                name: "Baskets");
        }
    }
}
