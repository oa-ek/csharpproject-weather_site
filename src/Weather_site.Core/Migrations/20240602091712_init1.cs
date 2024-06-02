using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Weather_site.Core.Migrations
{
    /// <inheritdoc />
    public partial class init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weathers_Winds_WindId",
                table: "Weathers");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("7067e7c1-f026-48dd-bf5e-c6c6654eb663"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("749837dd-7765-48ca-8097-406788f6cccf"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4510dd92-816f-44d8-a084-e87f4a1aacde"));

            migrationBuilder.AlterColumn<Guid>(
                name: "WindId",
                table: "Weathers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("7ef386e5-85bd-4934-9ec0-d116094b19b1"), "UA" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { new Guid("33e4628d-2772-49fe-8a16-d63062b0c3d9"), new Guid("7ef386e5-85bd-4934-9ec0-d116094b19b1"), "Rivne" },
                    { new Guid("a2906bca-763b-4c71-9677-d7ce582f6c6e"), new Guid("7ef386e5-85bd-4934-9ec0-d116094b19b1"), "Osrtoh" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Weathers_Winds_WindId",
                table: "Weathers",
                column: "WindId",
                principalTable: "Winds",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weathers_Winds_WindId",
                table: "Weathers");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("33e4628d-2772-49fe-8a16-d63062b0c3d9"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("a2906bca-763b-4c71-9677-d7ce582f6c6e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7ef386e5-85bd-4934-9ec0-d116094b19b1"));

            migrationBuilder.AlterColumn<Guid>(
                name: "WindId",
                table: "Weathers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("4510dd92-816f-44d8-a084-e87f4a1aacde"), "UA" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { new Guid("7067e7c1-f026-48dd-bf5e-c6c6654eb663"), new Guid("4510dd92-816f-44d8-a084-e87f4a1aacde"), "Osrtoh" },
                    { new Guid("749837dd-7765-48ca-8097-406788f6cccf"), new Guid("4510dd92-816f-44d8-a084-e87f4a1aacde"), "Rivne" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Weathers_Winds_WindId",
                table: "Weathers",
                column: "WindId",
                principalTable: "Winds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
