﻿// <auto-generated />
using System;
using Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HospitalManagementSystem.Infrastucture.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241224025452_SeedDepartment")]
    partial class SeedDepartment
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HospitalManagementSystem.Core.Domain.Entites.Appointment", b =>
                {
                    b.Property<Guid>("AppointmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DoctorID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Notes")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<Guid>("PatientID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoomID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("AppointmentID");

                    b.HasIndex("DoctorID");

                    b.HasIndex("PatientID");

                    b.HasIndex("RoomID");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("HospitalManagementSystem.Core.Domain.Entites.Department", b =>
                {
                    b.Property<Guid>("DepartmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("DepartmentID");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            DepartmentID = new Guid("d728f3a9-25ff-453b-b8b0-9f4708e8b6a0"),
                            Description = "Department specializing in the diagnosis and treatment of heart conditions.",
                            Name = "Cardiology"
                        },
                        new
                        {
                            DepartmentID = new Guid("b2c8d7f2-7d07-4e0e-bd55-21d8a64e315f"),
                            Description = "Department focused on the treatment of neurological disorders.",
                            Name = "Neurology"
                        },
                        new
                        {
                            DepartmentID = new Guid("8a3019da-f02f-4fc3-97e2-51354f74bb34"),
                            Description = "Department providing medical care for children.",
                            Name = "Pediatrics"
                        },
                        new
                        {
                            DepartmentID = new Guid("342d07d0-c6f3-4641-b9b5-32b0b6a5012b"),
                            Description = "Department for treating musculoskeletal system disorders.",
                            Name = "Orthopedics"
                        },
                        new
                        {
                            DepartmentID = new Guid("ad7353f9-d3a6-43ea-9d96-58de10e19a72"),
                            Description = "Department specializing in the treatment of skin conditions.",
                            Name = "Dermatology"
                        },
                        new
                        {
                            DepartmentID = new Guid("1c6b55b4-beb5-4f36-980d-015e040650b1"),
                            Description = "Department focusing on diagnostic imaging techniques.",
                            Name = "Radiology"
                        },
                        new
                        {
                            DepartmentID = new Guid("0bb4a1ed-67ac-402f-a51e-e5f8d49ea4f7"),
                            Description = "Department specializing in the treatment of cancer.",
                            Name = "Oncology"
                        },
                        new
                        {
                            DepartmentID = new Guid("5c029728-0284-4b82-b631-e464f957d2e4"),
                            Description = "Department providing immediate care for urgent medical conditions.",
                            Name = "Emergency"
                        },
                        new
                        {
                            DepartmentID = new Guid("b9e1c8d5-cd61-40f9-9140-9869c2a17947"),
                            Description = "Department specializing in the diagnosis and treatment of digestive system disorders.",
                            Name = "Gastroenterology"
                        },
                        new
                        {
                            DepartmentID = new Guid("67bb8c9f-cd45-474f-b7d5-7e2fc74d38e0"),
                            Description = "Department focused on the urinary tract and male reproductive organs.",
                            Name = "Urology"
                        });
                });

            modelBuilder.Entity("HospitalManagementSystem.Core.Domain.Entites.Doctor", b =>
                {
                    b.Property<Guid>("DoctorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Availability")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DepartmentID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("Gender")
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DoctorID");

                    b.HasIndex("DepartmentID");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("HospitalManagementSystem.Core.Domain.Entites.Invoice", b =>
                {
                    b.Property<Guid>("InvoiceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime?>("InvoiceDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentStatus")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<Guid>("TreatmentID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("InvoiceID");

                    b.HasIndex("TreatmentID");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("HospitalManagementSystem.Core.Domain.Entites.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("Gender")
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("PatientID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("HospitalManagementSystem.Core.Domain.Entites.Prescription", b =>
                {
                    b.Property<Guid>("PresciptionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Dosage")
                        .HasColumnType("int");

                    b.Property<string>("Instruction")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("MedicationName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("TreatmentID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PresciptionID");

                    b.HasIndex("TreatmentID");

                    b.ToTable("Prescriptions");
                });

            modelBuilder.Entity("HospitalManagementSystem.Core.Domain.Entites.Room", b =>
                {
                    b.Property<Guid>("RoomID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<Guid>("DepartmentID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.Property<string>("RoomType")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("RoomID");

                    b.HasIndex("DepartmentID");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("HospitalManagementSystem.Core.Domain.Entites.Treatment", b =>
                {
                    b.Property<Guid>("TreatmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DoctorID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("FollowUpDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PatientID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("TreatmentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TreatmentDetails")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("TreatmentID");

                    b.HasIndex("DoctorID");

                    b.HasIndex("PatientID");

                    b.ToTable("Treatments");
                });

            modelBuilder.Entity("HospitalManagementSystem.Core.Domain.IndentityEntities.ApplicationRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("HospitalManagementSystem.Core.Domain.IndentityEntities.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("HospitalManagementSystem.Core.Domain.Entites.Appointment", b =>
                {
                    b.HasOne("HospitalManagementSystem.Core.Domain.Entites.Doctor", "Doctor")
                        .WithMany("Appointments")
                        .HasForeignKey("DoctorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalManagementSystem.Core.Domain.Entites.Patient", "Patient")
                        .WithMany("Appointments")
                        .HasForeignKey("PatientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalManagementSystem.Core.Domain.Entites.Room", "Room")
                        .WithMany("Appointments")
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("HospitalManagementSystem.Core.Domain.Entites.Doctor", b =>
                {
                    b.HasOne("HospitalManagementSystem.Core.Domain.Entites.Department", "Department")
                        .WithMany("Doctors")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalManagementSystem.Core.Domain.IndentityEntities.ApplicationUser", "ApplicationUser")
                        .WithOne()
                        .HasForeignKey("HospitalManagementSystem.Core.Domain.Entites.Doctor", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("HospitalManagementSystem.Core.Domain.Entites.Invoice", b =>
                {
                    b.HasOne("HospitalManagementSystem.Core.Domain.Entites.Treatment", "Treatment")
                        .WithMany("Invoices")
                        .HasForeignKey("TreatmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Treatment");
                });

            modelBuilder.Entity("HospitalManagementSystem.Core.Domain.Entites.Patient", b =>
                {
                    b.HasOne("HospitalManagementSystem.Core.Domain.IndentityEntities.ApplicationUser", "ApplicationUser")
                        .WithOne()
                        .HasForeignKey("HospitalManagementSystem.Core.Domain.Entites.Patient", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("HospitalManagementSystem.Core.Domain.Entites.Prescription", b =>
                {
                    b.HasOne("HospitalManagementSystem.Core.Domain.Entites.Treatment", "Treatment")
                        .WithMany("Prescriptions")
                        .HasForeignKey("TreatmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Treatment");
                });

            modelBuilder.Entity("HospitalManagementSystem.Core.Domain.Entites.Room", b =>
                {
                    b.HasOne("HospitalManagementSystem.Core.Domain.Entites.Department", "Department")
                        .WithMany("Rooms")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("HospitalManagementSystem.Core.Domain.Entites.Treatment", b =>
                {
                    b.HasOne("HospitalManagementSystem.Core.Domain.Entites.Doctor", "Doctor")
                        .WithMany("Treatments")
                        .HasForeignKey("DoctorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalManagementSystem.Core.Domain.Entites.Patient", "Patient")
                        .WithMany("Treatments")
                        .HasForeignKey("PatientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("HospitalManagementSystem.Core.Domain.IndentityEntities.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("HospitalManagementSystem.Core.Domain.IndentityEntities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("HospitalManagementSystem.Core.Domain.IndentityEntities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("HospitalManagementSystem.Core.Domain.IndentityEntities.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalManagementSystem.Core.Domain.IndentityEntities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("HospitalManagementSystem.Core.Domain.IndentityEntities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HospitalManagementSystem.Core.Domain.Entites.Department", b =>
                {
                    b.Navigation("Doctors");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("HospitalManagementSystem.Core.Domain.Entites.Doctor", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Treatments");
                });

            modelBuilder.Entity("HospitalManagementSystem.Core.Domain.Entites.Patient", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Treatments");
                });

            modelBuilder.Entity("HospitalManagementSystem.Core.Domain.Entites.Room", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("HospitalManagementSystem.Core.Domain.Entites.Treatment", b =>
                {
                    b.Navigation("Invoices");

                    b.Navigation("Prescriptions");
                });
#pragma warning restore 612, 618
        }
    }
}