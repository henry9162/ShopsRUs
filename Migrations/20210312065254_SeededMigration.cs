using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopsRUs.Migrations
{
    public partial class SeededMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("5540638b-2410-445a-be25-cd2dbe584ad6"),
                column: "CUstomerTypeID",
                value: new Guid("1c8ac228-5531-44fc-8f32-b3ae9feb2ce6"));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("5a3f4b12-3067-4609-aeb2-66dd86ba508e"),
                column: "CUstomerTypeID",
                value: new Guid("a97c408a-7991-412b-b686-8cf2cdfd9b7c"));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("f441f952-0345-43b1-8e0e-6df94d6f2d4a"),
                column: "CUstomerTypeID",
                value: new Guid("42597c90-ad38-42e3-9423-6180735a0895"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("5540638b-2410-445a-be25-cd2dbe584ad6"),
                column: "CUstomerTypeID",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("5a3f4b12-3067-4609-aeb2-66dd86ba508e"),
                column: "CUstomerTypeID",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("f441f952-0345-43b1-8e0e-6df94d6f2d4a"),
                column: "CUstomerTypeID",
                value: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
