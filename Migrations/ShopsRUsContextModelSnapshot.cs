﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopsRUs.Data;

namespace ShopsRUs.Migrations
{
    [DbContext(typeof(ShopsRUsContext))]
    partial class ShopsRUsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ShopsRUs.Model.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CUstomerTypeID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CUstomerTypeID");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("ShopsRUs.Model.CustomerType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CustomerType");

                    b.HasData(
                        new
                        {
                            Id = new Guid("42597c90-ad38-42e3-9423-6180735a0895"),
                            Name = "Affiliate"
                        },
                        new
                        {
                            Id = new Guid("1c8ac228-5531-44fc-8f32-b3ae9feb2ce6"),
                            Name = "Employee"
                        },
                        new
                        {
                            Id = new Guid("a97c408a-7991-412b-b686-8cf2cdfd9b7c"),
                            Name = "Customer"
                        });
                });

            modelBuilder.Entity("ShopsRUs.Model.Discount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CustomerTypeId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("CustomerorBIllType")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PercentOrFixed")
                        .HasColumnType("bit");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerTypeId");

                    b.ToTable("Discount");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e14ad1cb-cd48-433f-96d2-849c30bbd184"),
                            CustomerTypeId = new Guid("42597c90-ad38-42e3-9423-6180735a0895"),
                            CustomerorBIllType = true,
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Discount for Affiliate",
                            Key = "Affiliate",
                            PercentOrFixed = true,
                            Value = 0.1m
                        },
                        new
                        {
                            Id = new Guid("456d0c56-fced-4324-8e10-15c85aa3d5cb"),
                            CustomerTypeId = new Guid("1c8ac228-5531-44fc-8f32-b3ae9feb2ce6"),
                            CustomerorBIllType = true,
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Discount for Employee",
                            Key = "Employee",
                            PercentOrFixed = true,
                            Value = 0.3m
                        },
                        new
                        {
                            Id = new Guid("e92e4be2-7fbd-44f4-b5b6-1006b218fc5d"),
                            CustomerTypeId = new Guid("a97c408a-7991-412b-b686-8cf2cdfd9b7c"),
                            CustomerorBIllType = true,
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Discount for Customers that has spent over 2 years",
                            Key = "2 years",
                            PercentOrFixed = true,
                            Value = 0.05m
                        },
                        new
                        {
                            Id = new Guid("12858bf9-d0ea-4da8-b0d5-d28e955ac40b"),
                            CustomerTypeId = new Guid("00000000-0000-0000-0000-000000000000"),
                            CustomerorBIllType = false,
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "For every $100, customer get $5 discount",
                            Key = "100 dollars",
                            PercentOrFixed = false,
                            Value = 5m
                        });
                });

            modelBuilder.Entity("ShopsRUs.Model.Invoice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("AmountReceived")
                        .HasColumnType("float");

                    b.Property<double>("BalanceDue")
                        .HasColumnType("float");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateStamp")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("InvoiceDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("InvoiceType")
                        .HasColumnType("int");

                    b.Property<string>("ReferenceId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalAmount")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Invoice");
                });

            modelBuilder.Entity("ShopsRUs.Model.Customer", b =>
                {
                    b.HasOne("ShopsRUs.Model.CustomerType", "CustomerType")
                        .WithMany()
                        .HasForeignKey("CUstomerTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ShopsRUs.Model.Discount", b =>
                {
                    b.HasOne("ShopsRUs.Model.CustomerType", "CustomerType")
                        .WithMany()
                        .HasForeignKey("CustomerTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ShopsRUs.Model.Invoice", b =>
                {
                    b.HasOne("ShopsRUs.Model.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
