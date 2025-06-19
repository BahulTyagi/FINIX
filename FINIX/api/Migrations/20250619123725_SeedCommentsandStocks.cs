using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class SeedCommentsandStocks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "CompanyName", "Description", "Industry", "LastDiv", "MarketCap", "Purchase", "Symbol" },
                values: new object[,]
                {
                    { 10, "Apple Inc.", "Consumer electronics and software company", "Technology", 0.82m, 2500000000000L, 150.00m, "AAPL" },
                    { 20, "Microsoft Corporation", "Software and cloud computing", "Technology", 0.75m, 2300000000000L, 280.00m, "MSFT" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedOn", "StockId", "Title" },
                values: new object[,]
                {
                    { 1, "Apple launches new iPhone.", new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "Apple News" },
                    { 3, "Stocks fluctuate after Fed announcement.", new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, "Market Overview" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "CompanyName", "Description", "Industry", "LastDiv", "MarketCap", "Purchase", "Symbol" },
                values: new object[,]
                {
                    { 1, "Apple Inc.", "Consumer electronics and software company", "Technology", 0.82m, 2500000000000L, 150.00m, "AAPL" },
                    { 2, "Microsoft Corporation", "Software and cloud computing", "Technology", 0.75m, 2300000000000L, 280.00m, "MSFT" }
                });
        }
    }
}
