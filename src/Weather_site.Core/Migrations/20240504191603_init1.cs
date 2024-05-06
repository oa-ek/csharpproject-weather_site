using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Weather_site.Core.Migrations
{
    /// <inheritdoc />
    public partial class init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clouds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    all = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clouds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    lon = table.Column<double>(type: "float", nullable: false),
                    lat = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mains",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    temp = table.Column<double>(type: "float", nullable: false),
                    feels_like = table.Column<double>(type: "float", nullable: false),
                    temp_min = table.Column<double>(type: "float", nullable: false),
                    temp_max = table.Column<double>(type: "float", nullable: false),
                    pressure = table.Column<int>(type: "int", nullable: false),
                    humidity = table.Column<int>(type: "int", nullable: false),
                    seaLevel = table.Column<int>(type: "int", nullable: false),
                    GroundLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mains", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResultViewModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Humidity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TempFeelsLike = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Temp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TempMax = table.Column<double>(type: "float", nullable: false),
                    TempMin = table.Column<double>(type: "float", nullable: false),
                    WeatherIcon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultViewModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    type = table.Column<int>(type: "int", nullable: false),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sunrise = table.Column<int>(type: "int", nullable: false),
                    sunset = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Weathers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    main = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    icon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weathers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Winds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    speed = table.Column<double>(type: "float", nullable: false),
                    deg = table.Column<int>(type: "int", nullable: false),
                    Gust = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Winds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootObject",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    coordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    @base = table.Column<string>(name: "base", type: "nvarchar(max)", nullable: false),
                    mainId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    visibility = table.Column<int>(type: "int", nullable: false),
                    windId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    allId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    dt = table.Column<int>(type: "int", nullable: false),
                    sysId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    timezone = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cod = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootObject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RootObject_Clouds_allId",
                        column: x => x.allId,
                        principalTable: "Clouds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RootObject_Coords_coordId",
                        column: x => x.coordId,
                        principalTable: "Coords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RootObject_Mains_mainId",
                        column: x => x.mainId,
                        principalTable: "Mains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RootObject_Sys_sysId",
                        column: x => x.sysId,
                        principalTable: "Sys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RootObject_Winds_windId",
                        column: x => x.windId,
                        principalTable: "Winds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RootObjectWeather",
                columns: table => new
                {
                    objectsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    weatherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootObjectWeather", x => new { x.objectsId, x.weatherId });
                    table.ForeignKey(
                        name: "FK_RootObjectWeather_RootObject_objectsId",
                        column: x => x.objectsId,
                        principalTable: "RootObject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RootObjectWeather_Weathers_weatherId",
                        column: x => x.weatherId,
                        principalTable: "Weathers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RootObject_allId",
                table: "RootObject",
                column: "allId");

            migrationBuilder.CreateIndex(
                name: "IX_RootObject_coordId",
                table: "RootObject",
                column: "coordId");

            migrationBuilder.CreateIndex(
                name: "IX_RootObject_mainId",
                table: "RootObject",
                column: "mainId");

            migrationBuilder.CreateIndex(
                name: "IX_RootObject_sysId",
                table: "RootObject",
                column: "sysId");

            migrationBuilder.CreateIndex(
                name: "IX_RootObject_windId",
                table: "RootObject",
                column: "windId");

            migrationBuilder.CreateIndex(
                name: "IX_RootObjectWeather_weatherId",
                table: "RootObjectWeather",
                column: "weatherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResultViewModels");

            migrationBuilder.DropTable(
                name: "RootObjectWeather");

            migrationBuilder.DropTable(
                name: "RootObject");

            migrationBuilder.DropTable(
                name: "Weathers");

            migrationBuilder.DropTable(
                name: "Clouds");

            migrationBuilder.DropTable(
                name: "Coords");

            migrationBuilder.DropTable(
                name: "Mains");

            migrationBuilder.DropTable(
                name: "Sys");

            migrationBuilder.DropTable(
                name: "Winds");
        }
    }
}
