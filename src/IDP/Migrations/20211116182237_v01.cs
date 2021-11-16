using Microsoft.EntityFrameworkCore.Migrations;

namespace IDP.Migrations
{
    public partial class v01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "d71341f6-43d1-451e-9889-415c60e5f004");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "41268aa6-7a9a-4af0-aa85-9d171a0b57d7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "ccada512-ad06-4019-9140-83c03c67c4c0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "b4c67a6c-33f7-49c6-882b-b7db8b3799e5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5",
                column: "ConcurrencyStamp",
                value: "ca952a98-03cb-49dd-8acc-42eb9d280edc");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7", "3d21aa89-6f15-4d84-9d70-06f7f1c162e7", "ApplicationRole", "Masters_Degree_In_Forestry", "Masters_Degree_In_Forestry" },
                    { "8", "c90cabf2-42e9-4953-963f-1ddedc9c77ef", "ApplicationRole", "Masters_Degree_In_Forestry", "Masters_Degree_In_Mining" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c7b0a260-f0ec-43dc-901a-fdf3e87cc7ce", "AQAAAAEAACcQAAAAEMrRD1XzyycwmJvNPIirD0MR2oKQ4mYHx5LOB6zkRZROCOV/kPIAQa4yxQfi/Yf3cQ==", "9ce9ffcf-d024-41c6-9534-e70db7f98bad" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "01469ae6-93b0-4409-a1d7-489aaea0b36d", "AQAAAAEAACcQAAAAEIMGt1tKQQFji0RdckayQEub34rhipQIxnLfuIfB7cVezMSpAlbVGbSonVRWBDWr6Q==", "eb0f0518-def5-4129-9ee1-4663e3a73671" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8d7480a7-4fb1-4c57-9817-1d0f9074b263", "AQAAAAEAACcQAAAAECLsigS+SiUuvu7QsIITeVViSouN6m+YChRJxa9lNBKApdJmx4YOIK0Yc69AzMT3TA==", "4eb1acb4-f05e-4110-bda0-2c87f1458623" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "3a42ce3b-e53e-44b0-87c0-cdd80f742007");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "889eb0ce-833c-4967-a3dd-c9b8b45d68b4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "6080a92c-9af9-4eeb-b3ea-1acb6b099cd6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "4af7a64e-c617-4757-a047-ce3bccdebb41");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5",
                column: "ConcurrencyStamp",
                value: "9ac1f4c7-514f-4c3a-b786-38617289c49e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "6", "915a29cc-36bd-4cdc-b3bb-c8f3a3aa286d", "ApplicationRole", "slask", "slask" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "10eed7fb-7b0d-4d6e-8047-adfeaf1562b0", "AQAAAAEAACcQAAAAEAdfa7nI8qeZwFoheeXjPS3x8dfmBMySrI89QGzb7thM/HNlkKsmoLn2MM+ezjYn+w==", "ee301b26-f870-42d3-abff-34d7200a961f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "29509aef-d504-48cc-9ab1-c3fcc2c1e67c", "AQAAAAEAACcQAAAAEB0jm0F0YOESZRM8s8aQwkBtqsu9BWiGK0e6uDWpK32jtarc+VipYv6/JVFHjU12XA==", "eb9ec0b0-1b40-4481-94d4-93b4bbba9d6c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2de6be56-64f1-402c-81b7-adf05d6c3c7d", "AQAAAAEAACcQAAAAEMVHmEVKeEEZsSq/Fd2u+K884fHQELZQwiQfM1yIgao4CkW7a8nyFmVG8QWU9BkMFw==", "c39d4585-36a1-40db-a052-cdc93fd0ccdc" });
        }
    }
}
