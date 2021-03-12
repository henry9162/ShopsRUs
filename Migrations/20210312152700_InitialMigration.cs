using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopsRUs.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerType",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    CUstomerTypeID = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_CustomerType_CUstomerTypeID",
                        column: x => x.CUstomerTypeID,
                        principalTable: "CustomerType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Discount",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CustomerTypeId = table.Column<Guid>(nullable: false),
                    Key = table.Column<string>(nullable: false),
                    Value = table.Column<decimal>(nullable: false),
                    PercentOrFixed = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    CustomerorBIllType = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Discount_CustomerType_CustomerTypeId",
                        column: x => x.CustomerTypeId,
                        principalTable: "CustomerType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ReferenceId = table.Column<string>(nullable: true),
                    CustomerId = table.Column<Guid>(nullable: false),
                    InvoiceDate = table.Column<DateTime>(nullable: false),
                    TotalAmount = table.Column<double>(nullable: false),
                    InvoiceType = table.Column<int>(nullable: false),
                    AmountReceived = table.Column<double>(nullable: false),
                    BalanceDue = table.Column<double>(nullable: false),
                    DateStamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoice_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CustomerType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("42597c90-ad38-42e3-9423-6180735a0895"), "Affiliate" },
                    { new Guid("1c8ac228-5531-44fc-8f32-b3ae9feb2ce6"), "Employee" },
                    { new Guid("a97c408a-7991-412b-b686-8cf2cdfd9b7c"), "Customer" }
                });

            migrationBuilder.InsertData(
                table: "Discount",
                columns: new[] { "Id", "CustomerTypeId", "CustomerorBIllType", "DateCreated", "Description", "Key", "PercentOrFixed", "Value" },
                values: new object[] { new Guid("12858bf9-d0ea-4da8-b0d5-d28e955ac40b"), new Guid("00000000-0000-0000-0000-000000000000"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "For every $100, customer get $5 discount", "100 dollars", false, 5m });

            migrationBuilder.InsertData(
                table: "Discount",
                columns: new[] { "Id", "CustomerTypeId", "CustomerorBIllType", "DateCreated", "Description", "Key", "PercentOrFixed", "Value" },
                values: new object[] { new Guid("e14ad1cb-cd48-433f-96d2-849c30bbd184"), new Guid("42597c90-ad38-42e3-9423-6180735a0895"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Discount for Affiliate", "Affiliate", true, 0.1m });

            migrationBuilder.InsertData(
                table: "Discount",
                columns: new[] { "Id", "CustomerTypeId", "CustomerorBIllType", "DateCreated", "Description", "Key", "PercentOrFixed", "Value" },
                values: new object[] { new Guid("456d0c56-fced-4324-8e10-15c85aa3d5cb"), new Guid("1c8ac228-5531-44fc-8f32-b3ae9feb2ce6"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Discount for Employee", "Employee", true, 0.3m });

            migrationBuilder.InsertData(
                table: "Discount",
                columns: new[] { "Id", "CustomerTypeId", "CustomerorBIllType", "DateCreated", "Description", "Key", "PercentOrFixed", "Value" },
                values: new object[] { new Guid("e92e4be2-7fbd-44f4-b5b6-1006b218fc5d"), new Guid("a97c408a-7991-412b-b686-8cf2cdfd9b7c"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Discount for Customers that has spent over 2 years", "2 years", true, 0.05m });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CUstomerTypeID",
                table: "Customer",
                column: "CUstomerTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Discount_CustomerTypeId",
                table: "Discount",
                column: "CustomerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_CustomerId",
                table: "Invoice",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discount");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "CustomerType");
        }
    }
}
