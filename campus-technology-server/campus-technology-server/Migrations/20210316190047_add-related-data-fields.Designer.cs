﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using campus_technology_server.AppleAppRequest;

namespace campus_technology_server.Migrations
{
    [DbContext(typeof(AppleAppRequestContext))]
    [Migration("20210316190047_add-related-data-fields")]
    partial class addrelateddatafields
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AppleAppRequest.Models.AppleAppApplicationModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("ReferenceId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Vendor")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AppleAppApplications");
                });

            modelBuilder.Entity("AppleAppRequest.Models.AppleAppApproverModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("ReferenceId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AppleAppApprovers");
                });

            modelBuilder.Entity("AppleAppRequest.Models.AppleAppDeviceModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AssetTag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("ReferenceId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AppleAppDevices");
                });

            modelBuilder.Entity("AppleAppRequest.Models.AppleAppRejectReasonModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("ReferenceId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AppleAppRejectReasons");
                });

            modelBuilder.Entity("AppleAppRequest.Models.AppleAppRequestModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicationIds")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Approver")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ApproverId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeviceIds")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Provider")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReferenceId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RejectReasonId")
                        .HasColumnType("int");

                    b.Property<string>("Requester")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AppleAppRequests");
                });
#pragma warning restore 612, 618
        }
    }
}
