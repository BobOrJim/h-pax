using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductCatalog.Migrations
{
    public partial class v01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Productname = table.Column<string>(name: "Product name", type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "ImageUrl", "Product name", "Price" },
                values: new object[,]
                {
                    { new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), "Movie 1", "SomeURL", "Reservoir Dogs", 21 },
                    { new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"), "Movie 2", "SomeURL", "True Romance", 22 },
                    { new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"), "Movie 3", "SomeURL", "Pulp Fiction", 23 },
                    { new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"), "Movie 4", "SomeURL", "Natural BornKillers", 24 },
                    { new Guid("1098f549-e790-4e9f-aa16-18c2292a2ee9"), "Movie 5", "SomeURL", "From Dusk Till Dawn", 25 },
                    { new Guid("1198f549-e790-4e9f-aa16-18c2292a2ee9"), "Movie 6", "SomeURL", "Jackie Brown", 26 },
                    { new Guid("1298f549-e790-4e9f-aa16-18c2292a2ee9"), "Movie 7", "SomeURL", "Inglourious Basterds", 27 },
                    { new Guid("1398f549-e790-4e9f-aa16-18c2292a2ee9"), "Movie 8", "SomeURL", "Django Unchained", 28 },
                    { new Guid("1498f549-e790-4e9f-aa16-18c2292a2ee9"), "Movie 9", "SomeURL", "The Hateful Eight", 29 },
                    { new Guid("1598f549-e790-4e9f-aa16-18c2292a2ee9"), "Movie 10", "SomeURL", "Once Upon a Time In Hollywood", 30 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
