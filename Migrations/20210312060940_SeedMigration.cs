using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopsRUs.Migrations
{
    public partial class SeedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "Address", "CUstomerTypeID", "DateCreated", "Email", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { new Guid("f441f952-0345-43b1-8e0e-6df94d6f2d4a"), "Lagos", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "henimastic@gmail.com", "Henry", "Ekwonwa", "08125234436" },
                    { new Guid("5540638b-2410-445a-be25-cd2dbe584ad6"), "Lagos", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "danielamoko@gmail.com", "Daniel", "Amoko", "08125234433" },
                    { new Guid("5a3f4b12-3067-4609-aeb2-66dd86ba508e"), "Lagos", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "somto@gmail.com", "Somto", "Amaugo", "08125244436" }
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
                values: new object[] { new Guid("12858bf9-d0ea-4da8-b0d5-d28e955ac40b"), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "For every $100, customer get $5 discount", "100 dollars", false, 5m });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("5540638b-2410-445a-be25-cd2dbe584ad6"));

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("5a3f4b12-3067-4609-aeb2-66dd86ba508e"));

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("f441f952-0345-43b1-8e0e-6df94d6f2d4a"));

            migrationBuilder.DeleteData(
                table: "Discount",
                keyColumn: "Id",
                keyValue: new Guid("12858bf9-d0ea-4da8-b0d5-d28e955ac40b"));

            migrationBuilder.DeleteData(
                table: "Discount",
                keyColumn: "Id",
                keyValue: new Guid("456d0c56-fced-4324-8e10-15c85aa3d5cb"));

            migrationBuilder.DeleteData(
                table: "Discount",
                keyColumn: "Id",
                keyValue: new Guid("e14ad1cb-cd48-433f-96d2-849c30bbd184"));

            migrationBuilder.DeleteData(
                table: "Discount",
                keyColumn: "Id",
                keyValue: new Guid("e92e4be2-7fbd-44f4-b5b6-1006b218fc5d"));

            migrationBuilder.DeleteData(
                table: "CustomerType",
                keyColumn: "Id",
                keyValue: new Guid("1c8ac228-5531-44fc-8f32-b3ae9feb2ce6"));

            migrationBuilder.DeleteData(
                table: "CustomerType",
                keyColumn: "Id",
                keyValue: new Guid("42597c90-ad38-42e3-9423-6180735a0895"));

            migrationBuilder.DeleteData(
                table: "CustomerType",
                keyColumn: "Id",
                keyValue: new Guid("a97c408a-7991-412b-b686-8cf2cdfd9b7c"));
        }
    }
}
