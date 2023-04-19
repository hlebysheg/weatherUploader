using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace weatherUploader.Migrations
{
    /// <inheritdoc />
    public partial class AddWheater : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WheatherForecast",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TimeMSC = table.Column<string>(type: "TEXT", nullable: false),
                    T = table.Column<double>(type: "REAL", nullable: false),
                    Humidity = table.Column<double>(type: "REAL", nullable: false),
                    Td = table.Column<double>(type: "REAL", nullable: false),
                    Pressure = table.Column<double>(type: "REAL", nullable: false),
                    WindDirection = table.Column<string>(type: "TEXT", nullable: true),
                    WindSpeed = table.Column<double>(type: "REAL", nullable: true),
                    Сloudiness = table.Column<int>(type: "INTEGER", nullable: true),
                    H = table.Column<int>(type: "INTEGER", nullable: true),
                    VV = table.Column<int>(type: "INTEGER", nullable: true),
                    WeatherConditions = table.Column<string>(type: "TEXT", nullable: true),
                    FileInfoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WheatherForecast", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WheatherForecast_WeatherFileInfo_FileInfoId",
                        column: x => x.FileInfoId,
                        principalTable: "WeatherFileInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WheatherForecast_FileInfoId",
                table: "WheatherForecast",
                column: "FileInfoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WheatherForecast");
        }
    }
}
