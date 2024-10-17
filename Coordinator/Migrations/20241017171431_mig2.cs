using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Coordinator.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Nodes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1bae95e2-ee98-47bf-bd02-74c5c3edeee6"), "Order.API" },
                    { new Guid("604d36ae-05ba-48ab-b844-ce90cb10f71a"), "Stock.API" },
                    { new Guid("f057a96f-969d-4f23-a2e7-4e6dffca0202"), "Payment.API" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: new Guid("1bae95e2-ee98-47bf-bd02-74c5c3edeee6"));

            migrationBuilder.DeleteData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: new Guid("604d36ae-05ba-48ab-b844-ce90cb10f71a"));

            migrationBuilder.DeleteData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: new Guid("f057a96f-969d-4f23-a2e7-4e6dffca0202"));
        }
    }
}
