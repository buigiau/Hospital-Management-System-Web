using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HospitalManagementSystem.Infrastucture.Migrations
{
    /// <inheritdoc />
    public partial class SeedDepartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentID", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("0bb4a1ed-67ac-402f-a51e-e5f8d49ea4f7"), "Department specializing in the treatment of cancer.", "Oncology" },
                    { new Guid("1c6b55b4-beb5-4f36-980d-015e040650b1"), "Department focusing on diagnostic imaging techniques.", "Radiology" },
                    { new Guid("342d07d0-c6f3-4641-b9b5-32b0b6a5012b"), "Department for treating musculoskeletal system disorders.", "Orthopedics" },
                    { new Guid("5c029728-0284-4b82-b631-e464f957d2e4"), "Department providing immediate care for urgent medical conditions.", "Emergency" },
                    { new Guid("67bb8c9f-cd45-474f-b7d5-7e2fc74d38e0"), "Department focused on the urinary tract and male reproductive organs.", "Urology" },
                    { new Guid("8a3019da-f02f-4fc3-97e2-51354f74bb34"), "Department providing medical care for children.", "Pediatrics" },
                    { new Guid("ad7353f9-d3a6-43ea-9d96-58de10e19a72"), "Department specializing in the treatment of skin conditions.", "Dermatology" },
                    { new Guid("b2c8d7f2-7d07-4e0e-bd55-21d8a64e315f"), "Department focused on the treatment of neurological disorders.", "Neurology" },
                    { new Guid("b9e1c8d5-cd61-40f9-9140-9869c2a17947"), "Department specializing in the diagnosis and treatment of digestive system disorders.", "Gastroenterology" },
                    { new Guid("d728f3a9-25ff-453b-b8b0-9f4708e8b6a0"), "Department specializing in the diagnosis and treatment of heart conditions.", "Cardiology" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("0bb4a1ed-67ac-402f-a51e-e5f8d49ea4f7"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("1c6b55b4-beb5-4f36-980d-015e040650b1"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("342d07d0-c6f3-4641-b9b5-32b0b6a5012b"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("5c029728-0284-4b82-b631-e464f957d2e4"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("67bb8c9f-cd45-474f-b7d5-7e2fc74d38e0"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("8a3019da-f02f-4fc3-97e2-51354f74bb34"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("ad7353f9-d3a6-43ea-9d96-58de10e19a72"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("b2c8d7f2-7d07-4e0e-bd55-21d8a64e315f"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("b9e1c8d5-cd61-40f9-9140-9869c2a17947"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("d728f3a9-25ff-453b-b8b0-9f4708e8b6a0"));
        }
    }
}
