﻿// <auto-generated />
using System;
using EmployeesOps.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmployeesOps.DAL.Migrations
{
    [DbContext(typeof(MainDbContext))]
    partial class MainDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EmployeesOps.DAL.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModificationBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Department");

                    b.HasData(
                        new
                        {
                            Id = 1001,
                            CreatedBy = "Dataseed",
                            CreationDate = new DateTime(2023, 10, 22, 23, 37, 50, 242, DateTimeKind.Local).AddTicks(7737),
                            IsDeleted = false,
                            Name = "IT Department"
                        },
                        new
                        {
                            Id = 1002,
                            CreatedBy = "Dataseed",
                            CreationDate = new DateTime(2023, 10, 22, 23, 37, 50, 242, DateTimeKind.Local).AddTicks(7748),
                            IsDeleted = false,
                            Name = "Sales Department"
                        },
                        new
                        {
                            Id = 1003,
                            CreatedBy = "Dataseed",
                            CreationDate = new DateTime(2023, 10, 22, 23, 37, 50, 242, DateTimeKind.Local).AddTicks(7749),
                            IsDeleted = false,
                            Name = "HHRR Department"
                        });
                });

            modelBuilder.Entity("EmployeesOps.DAL.Models.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EntryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("IdentificationNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("IdentificationTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastNames")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("ModificationBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Names")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<double>("Salary")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("IdentificationTypeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("EmployeesOps.DAL.Models.IdentificationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModificationBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("IdentificationTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = "Dataseed",
                            CreationDate = new DateTime(2023, 10, 22, 23, 37, 50, 242, DateTimeKind.Local).AddTicks(8325),
                            Description = "Cedula",
                            IsDeleted = false
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = "Dataseed",
                            CreationDate = new DateTime(2023, 10, 22, 23, 37, 50, 242, DateTimeKind.Local).AddTicks(8327),
                            Description = "SocialId",
                            IsDeleted = false
                        },
                        new
                        {
                            Id = 3,
                            CreatedBy = "Dataseed",
                            CreationDate = new DateTime(2023, 10, 22, 23, 37, 50, 242, DateTimeKind.Local).AddTicks(8328),
                            Description = "Passport",
                            IsDeleted = false
                        });
                });

            modelBuilder.Entity("EmployeesOps.DAL.Models.Employee", b =>
                {
                    b.HasOne("EmployeesOps.DAL.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("EmployeesOps.DAL.Models.IdentificationType", "IdentificationType")
                        .WithMany("Employees")
                        .HasForeignKey("IdentificationTypeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("IdentificationType");
                });

            modelBuilder.Entity("EmployeesOps.DAL.Models.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("EmployeesOps.DAL.Models.IdentificationType", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
