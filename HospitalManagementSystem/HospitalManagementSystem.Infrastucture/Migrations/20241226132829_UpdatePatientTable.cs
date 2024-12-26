using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagementSystem.Infrastucture.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePatientTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BloodGroup",
                table: "Patients",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Height",
                table: "Patients",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Weight",
                table: "Patients",
                type: "real",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientID",
                keyValue: new Guid("2a9bc1c7-56ae-4c90-a8f2-64a622a33244"),
                columns: new[] { "BloodGroup", "Height", "Weight" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientID",
                keyValue: new Guid("4bc8f14e-1e29-45c1-8e6a-b212d4466b64"),
                columns: new[] { "BloodGroup", "Height", "Weight" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientID",
                keyValue: new Guid("5f4e9a6f-df7b-4d95-bd4c-61bdbcdab928"),
                columns: new[] { "BloodGroup", "Height", "Weight" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientID",
                keyValue: new Guid("69d7ad97-f17c-4dbf-b8b8-19a1d9da6acb"),
                columns: new[] { "BloodGroup", "Height", "Weight" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientID",
                keyValue: new Guid("7c9d2e2f-5d52-45db-97f9-3d1a626022d4"),
                columns: new[] { "BloodGroup", "Height", "Weight" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientID",
                keyValue: new Guid("a3b2c5d8-ef88-4567-81d5-1a96ef519a8a"),
                columns: new[] { "BloodGroup", "Height", "Weight" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientID",
                keyValue: new Guid("a81b23c1-451b-43cd-9dcb-70a4f004ce98"),
                columns: new[] { "BloodGroup", "Height", "Weight" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientID",
                keyValue: new Guid("bd7263f8-ec8d-4a6f-b8f2-c1d15cd1d925"),
                columns: new[] { "BloodGroup", "Height", "Weight" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientID",
                keyValue: new Guid("d72b318f-8d9e-43fb-8279-cd3b06a13072"),
                columns: new[] { "BloodGroup", "Height", "Weight" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientID",
                keyValue: new Guid("de623f93-d8f6-4cdb-b4ab-bcf3959a3248"),
                columns: new[] { "BloodGroup", "Height", "Weight" },
                values: new object[] { null, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BloodGroup",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Patients");
        }
    }
}
