using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopsRUs.Migrations
{
    public partial class SeeddMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Discount",
                keyColumn: "Id",
                keyValue: new Guid("12858bf9-d0ea-4da8-b0d5-d28e955ac40b"),
                column: "CustomerTypeId",
                value: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Discount",
                keyColumn: "Id",
                keyValue: new Guid("12858bf9-d0ea-4da8-b0d5-d28e955ac40b"),
                column: "CustomerTypeId",
                value: null);
        }
    }
}
