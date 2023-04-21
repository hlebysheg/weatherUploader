using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace weatherUploader.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeatherFileInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Path = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    hash = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherFileInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WheatherForecast",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TimeMSC = table.Column<string>(type: "text", nullable: false),
                    T = table.Column<double>(type: "double precision", nullable: false),
                    Humidity = table.Column<double>(type: "double precision", nullable: false),
                    Td = table.Column<double>(type: "double precision", nullable: false),
                    Pressure = table.Column<double>(type: "double precision", nullable: false),
                    WindDirection = table.Column<string>(type: "text", nullable: true),
                    WindSpeed = table.Column<double>(type: "double precision", nullable: true),
                    Сloudiness = table.Column<double>(type: "double precision", nullable: true),
                    H = table.Column<double>(type: "double precision", nullable: true),
                    VV = table.Column<double>(type: "double precision", nullable: true),
                    WeatherConditions = table.Column<string>(type: "text", nullable: true),
                    FileInfoId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WheatherForecast", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WheatherForecast_WeatherFileInfo_FileInfoId",
                        column: x => x.FileInfoId,
                        principalTable: "WeatherFileInfo",
                        principalColumn: "Id");
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

            migrationBuilder.DropTable(
                name: "WeatherFileInfo");
        }
    }
}
