using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmployeesOps.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Dataseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "IsDeleted", "ModificationBy", "ModificationDate", "Name" },
                values: new object[,]
                {
                    { 1001, "Dataseed", new DateTime(2023, 10, 21, 23, 23, 4, 820, DateTimeKind.Local).AddTicks(617), false, null, null, "IT Department" },
                    { 1002, "Dataseed", new DateTime(2023, 10, 21, 23, 23, 4, 820, DateTimeKind.Local).AddTicks(629), false, null, null, "Sales Department" },
                    { 1003, "Dataseed", new DateTime(2023, 10, 21, 23, 23, 4, 820, DateTimeKind.Local).AddTicks(630), false, null, null, "HHRR Department" }
                });

            migrationBuilder.InsertData(
                table: "IdentificationTypes",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "Description", "IsDeleted", "ModificationBy", "ModificationDate" },
                values: new object[,]
                {
                    { 1, "Dataseed", new DateTime(2023, 10, 21, 23, 23, 4, 820, DateTimeKind.Local).AddTicks(3250), "Cedula", false, null, null },
                    { 2, "Dataseed", new DateTime(2023, 10, 21, 23, 23, 4, 820, DateTimeKind.Local).AddTicks(3256), "SocialId", false, null, null },
                    { 3, "Dataseed", new DateTime(2023, 10, 21, 23, 23, 4, 820, DateTimeKind.Local).AddTicks(3258), "Passport", false, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 1001);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 1002);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 1003);

            migrationBuilder.DeleteData(
                table: "IdentificationTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "IdentificationTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "IdentificationTypes",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
