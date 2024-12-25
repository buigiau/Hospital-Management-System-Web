using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagementSystem.Infrastucture.Migrations
{
    /// <inheritdoc />
    public partial class SeedPatient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "Patients",
                type: "int",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("0f240d10-9de9-4b8d-a8d9-08dd23e9eb4c"),
                column: "Gender",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("0f8b0db8-5358-46ac-a8dc-08dd23e9eb4c"),
                column: "Gender",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("127737de-a92a-42ba-a8d5-08dd23e9eb4c"),
                column: "Gender",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("2565ce39-534a-4774-a8d4-08dd23e9eb4c"),
                column: "Gender",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("60d23a8b-03c6-4360-a8db-08dd23e9eb4c"),
                column: "Gender",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("9c9a72ad-ce40-4872-a8d8-08dd23e9eb4c"),
                column: "Gender",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("9e8b1fbc-1fcc-4a59-a8d7-08dd23e9eb4c"),
                column: "Gender",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("9f1b91a3-08e1-43a9-a8d6-08dd23e9eb4c"),
                column: "Gender",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("a773eb06-a67e-4fec-a8da-08dd23e9eb4c"),
                column: "Gender",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("b83d3437-6e0a-4b21-a8d3-08dd23e9eb4c"),
                column: "Gender",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Patients",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("0f240d10-9de9-4b8d-a8d9-08dd23e9eb4c"),
                column: "Gender",
                value: "Female");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("0f8b0db8-5358-46ac-a8dc-08dd23e9eb4c"),
                column: "Gender",
                value: "Male");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("127737de-a92a-42ba-a8d5-08dd23e9eb4c"),
                column: "Gender",
                value: "Female");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("2565ce39-534a-4774-a8d4-08dd23e9eb4c"),
                column: "Gender",
                value: "Female");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("60d23a8b-03c6-4360-a8db-08dd23e9eb4c"),
                column: "Gender",
                value: "Female");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("9c9a72ad-ce40-4872-a8d8-08dd23e9eb4c"),
                column: "Gender",
                value: "Male");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("9e8b1fbc-1fcc-4a59-a8d7-08dd23e9eb4c"),
                column: "Gender",
                value: "Female");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("9f1b91a3-08e1-43a9-a8d6-08dd23e9eb4c"),
                column: "Gender",
                value: "Male");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("a773eb06-a67e-4fec-a8da-08dd23e9eb4c"),
                column: "Gender",
                value: "Male");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("b83d3437-6e0a-4b21-a8d3-08dd23e9eb4c"),
                column: "Gender",
                value: "Male");
        }
    }
}
