using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Personal_Expense_Tracking_System_Web_Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedingAndCreatingExpensesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "expenses",
                columns: table => new
                {
                    ExpenseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpenseAmount = table.Column<double>(type: "float", nullable: false),
                    ExpenseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpenseCategoryID = table.Column<int>(type: "int", nullable: false),
                    ExpenseReference = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_expenses", x => x.ExpenseID);
                    table.ForeignKey(
                        name: "FK_expenses_expenseCategories_ExpenseCategoryID",
                        column: x => x.ExpenseCategoryID,
                        principalTable: "expenseCategories",
                        principalColumn: "ExpenseCategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "expenses",
                columns: new[] { "ExpenseID", "ExpenseAmount", "ExpenseCategoryID", "ExpenseDate", "ExpenseReference", "ExpenseTitle" },
                values: new object[,]
                {
                    { 1, 120.0, 3, new DateTime(2024, 3, 31, 12, 6, 33, 999, DateTimeKind.Local).AddTicks(2075), "Tooth removal", "Dentiest Appointment" },
                    { 2, 3000.0, 7, new DateTime(2024, 3, 31, 12, 6, 33, 999, DateTimeKind.Local).AddTicks(2077), "Went to Spain", "Travelling" },
                    { 3, 800.0, 8, new DateTime(2024, 3, 31, 12, 6, 33, 999, DateTimeKind.Local).AddTicks(2078), "Rent and bills", "Rent" }
                });

            migrationBuilder.UpdateData(
                table: "incomes",
                keyColumn: "IncomeId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 3, 31, 12, 6, 33, 999, DateTimeKind.Local).AddTicks(1991));

            migrationBuilder.UpdateData(
                table: "incomes",
                keyColumn: "IncomeId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 3, 31, 12, 6, 33, 999, DateTimeKind.Local).AddTicks(2006));

            migrationBuilder.UpdateData(
                table: "incomes",
                keyColumn: "IncomeId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 3, 31, 12, 6, 33, 999, DateTimeKind.Local).AddTicks(2007));

            migrationBuilder.UpdateData(
                table: "incomes",
                keyColumn: "IncomeId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 3, 31, 12, 6, 33, 999, DateTimeKind.Local).AddTicks(2008));

            migrationBuilder.CreateIndex(
                name: "IX_expenses_ExpenseCategoryID",
                table: "expenses",
                column: "ExpenseCategoryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "expenses");

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
    }
}
