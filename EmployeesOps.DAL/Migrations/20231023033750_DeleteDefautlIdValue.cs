using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeesOps.DAL.Migrations
{
    /// <inheritdoc />
    public partial class DeleteDefautlIdValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWSEQUENTIALID()");

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 1001,
                column: "CreationDate",
                value: new DateTime(2023, 10, 22, 23, 37, 50, 242, DateTimeKind.Local).AddTicks(7737));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 1002,
                column: "CreationDate",
                value: new DateTime(2023, 10, 22, 23, 37, 50, 242, DateTimeKind.Local).AddTicks(7748));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 1003,
                column: "CreationDate",
                value: new DateTime(2023, 10, 22, 23, 37, 50, 242, DateTimeKind.Local).AddTicks(7749));

            migrationBuilder.UpdateData(
                table: "IdentificationTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 10, 22, 23, 37, 50, 242, DateTimeKind.Local).AddTicks(8325));

            migrationBuilder.UpdateData(
                table: "IdentificationTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 10, 22, 23, 37, 50, 242, DateTimeKind.Local).AddTicks(8327));

            migrationBuilder.UpdateData(
                table: "IdentificationTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2023, 10, 22, 23, 37, 50, 242, DateTimeKind.Local).AddTicks(8328));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWSEQUENTIALID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 1001,
                column: "CreationDate",
                value: new DateTime(2023, 10, 22, 23, 25, 10, 200, DateTimeKind.Local).AddTicks(3388));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 1002,
                column: "CreationDate",
                value: new DateTime(2023, 10, 22, 23, 25, 10, 200, DateTimeKind.Local).AddTicks(3398));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 1003,
                column: "CreationDate",
                value: new DateTime(2023, 10, 22, 23, 25, 10, 200, DateTimeKind.Local).AddTicks(3399));

            migrationBuilder.UpdateData(
                table: "IdentificationTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 10, 22, 23, 25, 10, 200, DateTimeKind.Local).AddTicks(3980));

            migrationBuilder.UpdateData(
                table: "IdentificationTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 10, 22, 23, 25, 10, 200, DateTimeKind.Local).AddTicks(3981));

            migrationBuilder.UpdateData(
                table: "IdentificationTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2023, 10, 22, 23, 25, 10, 200, DateTimeKind.Local).AddTicks(3982));
        }
    }
}
