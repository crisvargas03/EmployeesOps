using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeesOps.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Cloud : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 1001,
                column: "CreationDate",
                value: new DateTime(2023, 12, 14, 15, 42, 13, 755, DateTimeKind.Local).AddTicks(6796));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 1002,
                column: "CreationDate",
                value: new DateTime(2023, 12, 14, 15, 42, 13, 755, DateTimeKind.Local).AddTicks(6810));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 1003,
                column: "CreationDate",
                value: new DateTime(2023, 12, 14, 15, 42, 13, 755, DateTimeKind.Local).AddTicks(6811));

            migrationBuilder.UpdateData(
                table: "IdentificationTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 12, 14, 15, 42, 13, 755, DateTimeKind.Local).AddTicks(9055));

            migrationBuilder.UpdateData(
                table: "IdentificationTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 12, 14, 15, 42, 13, 755, DateTimeKind.Local).AddTicks(9059));

            migrationBuilder.UpdateData(
                table: "IdentificationTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2023, 12, 14, 15, 42, 13, 755, DateTimeKind.Local).AddTicks(9060));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 1001,
                column: "CreationDate",
                value: new DateTime(2023, 10, 31, 23, 6, 57, 8, DateTimeKind.Local).AddTicks(6147));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 1002,
                column: "CreationDate",
                value: new DateTime(2023, 10, 31, 23, 6, 57, 8, DateTimeKind.Local).AddTicks(6157));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 1003,
                column: "CreationDate",
                value: new DateTime(2023, 10, 31, 23, 6, 57, 8, DateTimeKind.Local).AddTicks(6158));

            migrationBuilder.UpdateData(
                table: "IdentificationTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 10, 31, 23, 6, 57, 8, DateTimeKind.Local).AddTicks(8553));

            migrationBuilder.UpdateData(
                table: "IdentificationTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 10, 31, 23, 6, 57, 8, DateTimeKind.Local).AddTicks(8556));

            migrationBuilder.UpdateData(
                table: "IdentificationTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2023, 10, 31, 23, 6, 57, 8, DateTimeKind.Local).AddTicks(8557));
        }
    }
}
