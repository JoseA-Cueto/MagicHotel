using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicHotel.Migrations
{
    public partial class AlimentarTablaHotel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Hoteles",
                columns: new[] { "Id", "Amenidad", "Detalle", "FechaInicio", "FechaUpdate", "ImagenUrl", "Name", "SquareMeters", "Tarifa", "Tourist" },
                values: new object[] { 1, "", "", new DateTime(2023, 3, 1, 22, 41, 35, 806, DateTimeKind.Local).AddTicks(1468), new DateTime(2023, 3, 1, 22, 41, 35, 806, DateTimeKind.Local).AddTicks(1476), "", "Hotel Habana Libre...", 50, 200.0, 5 });

            migrationBuilder.InsertData(
                table: "Hoteles",
                columns: new[] { "Id", "Amenidad", "Detalle", "FechaInicio", "FechaUpdate", "ImagenUrl", "Name", "SquareMeters", "Tarifa", "Tourist" },
                values: new object[] { 2, "", "", new DateTime(2023, 3, 1, 22, 41, 35, 806, DateTimeKind.Local).AddTicks(1478), new DateTime(2023, 3, 1, 22, 41, 35, 806, DateTimeKind.Local).AddTicks(1479), "", "Hotel Nacional...", 60, 250.0, 3 });

            migrationBuilder.InsertData(
                table: "Hoteles",
                columns: new[] { "Id", "Amenidad", "Detalle", "FechaInicio", "FechaUpdate", "ImagenUrl", "Name", "SquareMeters", "Tarifa", "Tourist" },
                values: new object[] { 3, "", "", new DateTime(2023, 3, 1, 22, 41, 35, 806, DateTimeKind.Local).AddTicks(1480), new DateTime(2023, 3, 1, 22, 41, 35, 806, DateTimeKind.Local).AddTicks(1480), "", "Hotel Copacavana...", 70, 300.0, 10 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hoteles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hoteles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hoteles",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
