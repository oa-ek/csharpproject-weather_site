using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Weather_site.Core.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clouds",
                columns: table => new
                {
                    all = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clouds", x => x.all);
                });

            migrationBuilder.CreateTable(
                name: "Coords",
                columns: table => new
                {
                    lon = table.Column<double>(type: "float", nullable: false),
                    lat = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coords", x => x.lon);
                });

            migrationBuilder.CreateTable(
                name: "Mains",
                columns: table => new
                {
                    temp = table.Column<double>(type: "float", nullable: false),
                    feels_like = table.Column<double>(type: "float", nullable: false),
                    temp_min = table.Column<int>(type: "int", nullable: false),
                    temp_max = table.Column<double>(type: "float", nullable: false),
                    pressure = table.Column<int>(type: "int", nullable: false),
                    humidity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mains", x => x.temp);
                });

            migrationBuilder.CreateTable(
                name: "ResultViewModels",
                columns: table => new
                {
                    City = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Humidity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TempFeelsLike = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Temp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TempMax = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TempMin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WeatherIcon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultViewModels", x => x.City);
                });

            migrationBuilder.CreateTable(
                name: "Sys",
                columns: table => new
                {
                    type = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id = table.Column<int>(type: "int", nullable: false),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sunrise = table.Column<int>(type: "int", nullable: false),
                    sunset = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys", x => x.type);
                });

            migrationBuilder.CreateTable(
                name: "Winds",
                columns: table => new
                {
                    speed = table.Column<double>(type: "float", nullable: false),
                    deg = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Winds", x => x.speed);
                });

            migrationBuilder.CreateTable(
                name: "RootObjects",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    coordlon = table.Column<double>(type: "float", nullable: false),
                    @base = table.Column<string>(name: "base", type: "nvarchar(max)", nullable: false),
                    maintemp = table.Column<double>(type: "float", nullable: false),
                    visibility = table.Column<int>(type: "int", nullable: false),
                    windspeed = table.Column<double>(type: "float", nullable: false),
                    cloudsall = table.Column<int>(type: "int", nullable: false),
                    dt = table.Column<int>(type: "int", nullable: false),
                    systype = table.Column<int>(type: "int", nullable: false),
                    timezone = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cod = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootObjects", x => x.id);
                    table.ForeignKey(
                        name: "FK_RootObjects_Clouds_cloudsall",
                        column: x => x.cloudsall,
                        principalTable: "Clouds",
                        principalColumn: "all",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RootObjects_Coords_coordlon",
                        column: x => x.coordlon,
                        principalTable: "Coords",
                        principalColumn: "lon",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RootObjects_Mains_maintemp",
                        column: x => x.maintemp,
                        principalTable: "Mains",
                        principalColumn: "temp",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RootObjects_Sys_systype",
                        column: x => x.systype,
                        principalTable: "Sys",
                        principalColumn: "type",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RootObjects_Winds_windspeed",
                        column: x => x.windspeed,
                        principalTable: "Winds",
                        principalColumn: "speed",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Weathers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    main = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RootObjectid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weathers", x => x.id);
                    table.ForeignKey(
                        name: "FK_Weathers_RootObjects_RootObjectid",
                        column: x => x.RootObjectid,
                        principalTable: "RootObjects",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RootObjects_cloudsall",
                table: "RootObjects",
                column: "cloudsall");

            migrationBuilder.CreateIndex(
                name: "IX_RootObjects_coordlon",
                table: "RootObjects",
                column: "coordlon");

            migrationBuilder.CreateIndex(
                name: "IX_RootObjects_maintemp",
                table: "RootObjects",
                column: "maintemp");

            migrationBuilder.CreateIndex(
                name: "IX_RootObjects_systype",
                table: "RootObjects",
                column: "systype");

            migrationBuilder.CreateIndex(
                name: "IX_RootObjects_windspeed",
                table: "RootObjects",
                column: "windspeed");

            migrationBuilder.CreateIndex(
                name: "IX_Weathers_RootObjectid",
                table: "Weathers",
                column: "RootObjectid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResultViewModels");

            migrationBuilder.DropTable(
                name: "Weathers");

            migrationBuilder.DropTable(
                name: "RootObjects");

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
