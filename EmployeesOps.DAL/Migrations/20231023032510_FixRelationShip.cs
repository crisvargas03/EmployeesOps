using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeesOps.DAL.Migrations
{
    /// <inheritdoc />
    public partial class FixRelationShip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_IdentificationTypes_DepartmentId",
                table: "Employees");

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

            migrationBuilder.CreateIndex(
                name: "IX_Employees_IdentificationTypeId",
                table: "Employees",
                column: "IdentificationTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_IdentificationTypes_IdentificationTypeId",
                table: "Employees",
                column: "IdentificationTypeId",
                principalTable: "IdentificationTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_IdentificationTypes_IdentificationTypeId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_IdentificationTypeId",
                table: "Employees");

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 1001,
                column: "CreationDate",
                value: new DateTime(2023, 10, 21, 23, 23, 4, 820, DateTimeKind.Local).AddTicks(617));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 1002,
                column: "CreationDate",
                value: new DateTime(2023, 10, 21, 23, 23, 4, 820, DateTimeKind.Local).AddTicks(629));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 1003,
                column: "CreationDate",
                value: new DateTime(2023, 10, 21, 23, 23, 4, 820, DateTimeKind.Local).AddTicks(630));

            migrationBuilder.UpdateData(
                table: "IdentificationTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 10, 21, 23, 23, 4, 820, DateTimeKind.Local).AddTicks(3250));

            migrationBuilder.UpdateData(
                table: "IdentificationTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 10, 21, 23, 23, 4, 820, DateTimeKind.Local).AddTicks(3256));

            migrationBuilder.UpdateData(
                table: "IdentificationTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2023, 10, 21, 23, 23, 4, 820, DateTimeKind.Local).AddTicks(3258));

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_IdentificationTypes_DepartmentId",
                table: "Employees",
                column: "DepartmentId",
                principalTable: "IdentificationTypes",
                principalColumn: "Id");
        }
    }
}
