using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HospitalManagementSystem.Infrastucture.Migrations
{
    /// <inheritdoc />
    public partial class AddPrimaryKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Patients_PatientID",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_AspNetUsers_Id",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Treatments_Patients_PatientID",
                table: "Treatments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Patients",
                table: "Patients");

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("0f240d10-9de9-4b8d-a8d9-08dd23e9eb4c"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("0f8b0db8-5358-46ac-a8dc-08dd23e9eb4c"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("127737de-a92a-42ba-a8d5-08dd23e9eb4c"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("2565ce39-534a-4774-a8d4-08dd23e9eb4c"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("60d23a8b-03c6-4360-a8db-08dd23e9eb4c"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("9c9a72ad-ce40-4872-a8d8-08dd23e9eb4c"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("9e8b1fbc-1fcc-4a59-a8d7-08dd23e9eb4c"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("9f1b91a3-08e1-43a9-a8d6-08dd23e9eb4c"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("a773eb06-a67e-4fec-a8da-08dd23e9eb4c"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("b83d3437-6e0a-4b21-a8d3-08dd23e9eb4c"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Patients",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patients",
                table: "Patients",
                column: "PatientID");

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientID", "Address", "DateOfBirth", "Email", "FirstName", "Gender", "Id", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("2a9bc1c7-56ae-4c90-a8f2-64a622a33244"), "234 Cedar Ln, Hilltown", new DateTime(1988, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "david.martinez@example.com", "David", 0, new Guid("9c9a72ad-ce40-4872-a8d8-08dd23e9eb4c"), "Martinez", "+1703456789" },
                    { new Guid("4bc8f14e-1e29-45c1-8e6a-b212d4466b64"), "321 Birch Blvd, Riverside", new DateTime(1975, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "michael.johnson@example.com", "Michael", 0, new Guid("9f1b91a3-08e1-43a9-a8d6-08dd23e9eb4c"), "Johnson", "+1555647382" },
                    { new Guid("5f4e9a6f-df7b-4d95-bd4c-61bdbcdab928"), "123 Main St, Cityville", new DateTime(1985, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@example.com", "John", 0, new Guid("b83d3437-6e0a-4b21-a8d3-08dd23e9eb4c"), "Doe", "+1234567890" },
                    { new Guid("69d7ad97-f17c-4dbf-b8b8-19a1d9da6acb"), "111 Pinewood Dr, Metrocity", new DateTime(1980, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "ethan.davis@example.com", "Ethan", 0, new Guid("a773eb06-a67e-4fec-a8da-08dd23e9eb4c"), "Davis", "+1709586473" },
                    { new Guid("7c9d2e2f-5d52-45db-97f9-3d1a626022d4"), "654 Maple St, Lakeside", new DateTime(1995, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "sophia.williams@example.com", "Sophia", 1, new Guid("9e8b1fbc-1fcc-4a59-a8d7-08dd23e9eb4c"), "Williams", "+1612456987" },
                    { new Guid("a3b2c5d8-ef88-4567-81d5-1a96ef519a8a"), "456 Oak Ave, Townsville", new DateTime(1990, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@example.com", "Jane", 1, new Guid("2565ce39-534a-4774-a8d4-08dd23e9eb4c"), "Smith", "+1987654321" },
                    { new Guid("a81b23c1-451b-43cd-9dcb-70a4f004ce98"), "987 Elm Dr, Brightville", new DateTime(1992, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "olivia.taylor@example.com", "Olivia", 1, new Guid("0f240d10-9de9-4b8d-a8d9-08dd23e9eb4c"), "Taylor", "+1543728460" },
                    { new Guid("bd7263f8-ec8d-4a6f-b8f2-c1d15cd1d925"), "789 Pine Rd, Greenfield", new DateTime(1982, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "alice.brown@example.com", "Alice", 1, new Guid("127737de-a92a-42ba-a8d5-08dd23e9eb4c"), "Brown", "+1122334455" },
                    { new Guid("d72b318f-8d9e-43fb-8279-cd3b06a13072"), "432 Willow St, Westwood", new DateTime(1996, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "isabella.miller@example.com", "Isabella", 1, new Guid("60d23a8b-03c6-4360-a8db-08dd23e9eb4c"), "Miller", "+1812456789" },
                    { new Guid("de623f93-d8f6-4cdb-b4ab-bcf3959a3248"), "876 Spruce Ave, Sunnydale", new DateTime(1993, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "liam.garcia@example.com", "Liam", 0, new Guid("0f8b0db8-5358-46ac-a8dc-08dd23e9eb4c"), "Garcia", "+1557448392" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Id",
                table: "Patients",
                column: "Id",
                unique: true,
                filter: "[Id] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Patients_PatientID",
                table: "Appointments",
                column: "PatientID",
                principalTable: "Patients",
                principalColumn: "PatientID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_AspNetUsers_Id",
                table: "Patients",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Treatments_Patients_PatientID",
                table: "Treatments",
                column: "PatientID",
                principalTable: "Patients",
                principalColumn: "PatientID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Patients_PatientID",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_AspNetUsers_Id",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Treatments_Patients_PatientID",
                table: "Treatments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Patients",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_Id",
                table: "Patients");

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientID",
                keyValue: new Guid("2a9bc1c7-56ae-4c90-a8f2-64a622a33244"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientID",
                keyValue: new Guid("4bc8f14e-1e29-45c1-8e6a-b212d4466b64"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientID",
                keyValue: new Guid("5f4e9a6f-df7b-4d95-bd4c-61bdbcdab928"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientID",
                keyValue: new Guid("69d7ad97-f17c-4dbf-b8b8-19a1d9da6acb"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientID",
                keyValue: new Guid("7c9d2e2f-5d52-45db-97f9-3d1a626022d4"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientID",
                keyValue: new Guid("a3b2c5d8-ef88-4567-81d5-1a96ef519a8a"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientID",
                keyValue: new Guid("a81b23c1-451b-43cd-9dcb-70a4f004ce98"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientID",
                keyValue: new Guid("bd7263f8-ec8d-4a6f-b8f2-c1d15cd1d925"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientID",
                keyValue: new Guid("d72b318f-8d9e-43fb-8279-cd3b06a13072"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientID",
                keyValue: new Guid("de623f93-d8f6-4cdb-b4ab-bcf3959a3248"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Patients",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patients",
                table: "Patients",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Address", "DateOfBirth", "Email", "FirstName", "Gender", "LastName", "PatientID", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("0f240d10-9de9-4b8d-a8d9-08dd23e9eb4c"), "987 Elm Dr, Brightville", new DateTime(1992, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "olivia.taylor@example.com", "Olivia", 1, "Taylor", new Guid("a81b23c1-451b-43cd-9dcb-70a4f004ce98"), "+1543728460" },
                    { new Guid("0f8b0db8-5358-46ac-a8dc-08dd23e9eb4c"), "876 Spruce Ave, Sunnydale", new DateTime(1993, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "liam.garcia@example.com", "Liam", 0, "Garcia", new Guid("de623f93-d8f6-4cdb-b4ab-bcf3959a3248"), "+1557448392" },
                    { new Guid("127737de-a92a-42ba-a8d5-08dd23e9eb4c"), "789 Pine Rd, Greenfield", new DateTime(1982, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "alice.brown@example.com", "Alice", 1, "Brown", new Guid("bd7263f8-ec8d-4a6f-b8f2-c1d15cd1d925"), "+1122334455" },
                    { new Guid("2565ce39-534a-4774-a8d4-08dd23e9eb4c"), "456 Oak Ave, Townsville", new DateTime(1990, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@example.com", "Jane", 1, "Smith", new Guid("a3b2c5d8-ef88-4567-81d5-1a96ef519a8a"), "+1987654321" },
                    { new Guid("60d23a8b-03c6-4360-a8db-08dd23e9eb4c"), "432 Willow St, Westwood", new DateTime(1996, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "isabella.miller@example.com", "Isabella", 1, "Miller", new Guid("d72b318f-8d9e-43fb-8279-cd3b06a13072"), "+1812456789" },
                    { new Guid("9c9a72ad-ce40-4872-a8d8-08dd23e9eb4c"), "234 Cedar Ln, Hilltown", new DateTime(1988, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "david.martinez@example.com", "David", 0, "Martinez", new Guid("2a9bc1c7-56ae-4c90-a8f2-64a622a33244"), "+1703456789" },
                    { new Guid("9e8b1fbc-1fcc-4a59-a8d7-08dd23e9eb4c"), "654 Maple St, Lakeside", new DateTime(1995, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "sophia.williams@example.com", "Sophia", 1, "Williams", new Guid("7c9d2e2f-5d52-45db-97f9-3d1a626022d4"), "+1612456987" },
                    { new Guid("9f1b91a3-08e1-43a9-a8d6-08dd23e9eb4c"), "321 Birch Blvd, Riverside", new DateTime(1975, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "michael.johnson@example.com", "Michael", 0, "Johnson", new Guid("4bc8f14e-1e29-45c1-8e6a-b212d4466b64"), "+1555647382" },
                    { new Guid("a773eb06-a67e-4fec-a8da-08dd23e9eb4c"), "111 Pinewood Dr, Metrocity", new DateTime(1980, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "ethan.davis@example.com", "Ethan", 0, "Davis", new Guid("69d7ad97-f17c-4dbf-b8b8-19a1d9da6acb"), "+1709586473" },
                    { new Guid("b83d3437-6e0a-4b21-a8d3-08dd23e9eb4c"), "123 Main St, Cityville", new DateTime(1985, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@example.com", "John", 0, "Doe", new Guid("5f4e9a6f-df7b-4d95-bd4c-61bdbcdab928"), "+1234567890" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Patients_PatientID",
                table: "Appointments",
                column: "PatientID",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_AspNetUsers_Id",
                table: "Patients",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Treatments_Patients_PatientID",
                table: "Treatments",
                column: "PatientID",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
