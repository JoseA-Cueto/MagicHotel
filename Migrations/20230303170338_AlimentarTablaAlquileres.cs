using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicHotel.Migrations
{
    public partial class AlimentarTablaAlquileres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hoteles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Detalle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tarifa = table.Column<double>(type: "float", nullable: false),
                    Tourist = table.Column<int>(type: "int", nullable: false),
                    SquareMeters = table.Column<int>(type: "int", nullable: false),
                    ImagenUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amenidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hoteles", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Hoteles",
                columns: new[] { "Id", "Amenidad", "Detalle", "FechaInicio", "FechaUpdate", "ImagenUrl", "Name", "SquareMeters", "Tarifa", "Tourist" },
                values: new object[] { 1, "", "", new DateTime(2023, 3, 3, 9, 3, 38, 440, DateTimeKind.Local).AddTicks(421), new DateTime(2023, 3, 3, 9, 3, 38, 440, DateTimeKind.Local).AddTicks(439), "", "Hotel Habana Libre...", 50, 200.0, 5 });

            migrationBuilder.InsertData(
                table: "Hoteles",
                columns: new[] { "Id", "Amenidad", "Detalle", "FechaInicio", "FechaUpdate", "ImagenUrl", "Name", "SquareMeters", "Tarifa", "Tourist" },
                values: new object[] { 2, "", "", new DateTime(2023, 3, 3, 9, 3, 38, 440, DateTimeKind.Local).AddTicks(441), new DateTime(2023, 3, 3, 9, 3, 38, 440, DateTimeKind.Local).AddTicks(442), "", "Hotel Nacional...", 60, 250.0, 3 });

            migrationBuilder.InsertData(
                table: "Hoteles",
                columns: new[] { "Id", "Amenidad", "Detalle", "FechaInicio", "FechaUpdate", "ImagenUrl", "Name", "SquareMeters", "Tarifa", "Tourist" },
                values: new object[] { 3, "", "", new DateTime(2023, 3, 3, 9, 3, 38, 440, DateTimeKind.Local).AddTicks(444), new DateTime(2023, 3, 3, 9, 3, 38, 440, DateTimeKind.Local).AddTicks(445), "", "Hotel Copacavana...", 70, 300.0, 10 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hoteles");
        }
    }
}
