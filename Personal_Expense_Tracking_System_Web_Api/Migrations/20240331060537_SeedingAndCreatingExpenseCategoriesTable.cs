using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Personal_Expense_Tracking_System_Web_Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedingAndCreatingExpenseCategoriesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "expenseCategories",
                columns: table => new
                {
                    ExpenseCategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_expenseCategories", x => x.ExpenseCategoryID);
                });

            migrationBuilder.InsertData(
                table: "expenseCategories",
                columns: new[] { "ExpenseCategoryID", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Education" },
                    { 2, "Groceries" },
                    { 3, "Health" },
                    { 4, "Subscriptions" },
                    { 5, "Takeaways" },
                    { 6, "Clothing" },
                    { 7, "Travelling" },
                    { 8, "Other" }
                });

            migrationBuilder.UpdateData(
                table: "incomes",
                keyColumn: "IncomeId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 3, 31, 12, 5, 37, 330, DateTimeKind.Local).AddTicks(7129));

            migrationBuilder.UpdateData(
                table: "incomes",
                keyColumn: "IncomeId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 3, 31, 12, 5, 37, 330, DateTimeKind.Local).AddTicks(7146));

            migrationBuilder.UpdateData(
                table: "incomes",
                keyColumn: "IncomeId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 3, 31, 12, 5, 37, 330, DateTimeKind.Local).AddTicks(7148));

            migrationBuilder.UpdateData(
                table: "incomes",
                keyColumn: "IncomeId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 3, 31, 12, 5, 37, 330, DateTimeKind.Local).AddTicks(7149));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "expenseCategories");

            migrationBuilder.UpdateData(
                table: "incomes",
                keyColumn: "IncomeId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 3, 31, 12, 4, 25, 540, DateTimeKind.Local).AddTicks(6177));

            migrationBuilder.UpdateData(
                table: "incomes",
                keyColumn: "IncomeId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 3, 31, 12, 4, 25, 540, DateTimeKind.Local).AddTicks(6191));

            migrationBuilder.UpdateData(
                table: "incomes",
                keyColumn: "IncomeId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 3, 31, 12, 4, 25, 540, DateTimeKind.Local).AddTicks(6192));

            migrationBuilder.UpdateData(
                table: "incomes",
                keyColumn: "IncomeId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 3, 31, 12, 4, 25, 540, DateTimeKind.Local).AddTicks(6193));
        }
    }
}
