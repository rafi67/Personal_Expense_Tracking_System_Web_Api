using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Personal_Expense_Tracking_System_Web_Api.Migrations
{
    /// <inheritdoc />
    public partial class seedingExpenseCategoriesAndExpensesTable : Migration
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
                value: new DateTime(2024, 3, 12, 21, 31, 44, 800, DateTimeKind.Local).AddTicks(6694));

            migrationBuilder.UpdateData(
                table: "incomes",
                keyColumn: "IncomeId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 3, 12, 21, 31, 44, 800, DateTimeKind.Local).AddTicks(6710));

            migrationBuilder.UpdateData(
                table: "incomes",
                keyColumn: "IncomeId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 3, 12, 21, 31, 44, 800, DateTimeKind.Local).AddTicks(6711));

            migrationBuilder.UpdateData(
                table: "incomes",
                keyColumn: "IncomeId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 3, 12, 21, 31, 44, 800, DateTimeKind.Local).AddTicks(6713));

            migrationBuilder.InsertData(
                table: "expenses",
                columns: new[] { "ExpenseID", "ExpenseAmount", "ExpenseCategoryID", "ExpenseDate", "ExpenseReference", "ExpenseTitle" },
                values: new object[,]
                {
                    { 1, 120.0, 3, new DateTime(2024, 3, 12, 21, 31, 44, 800, DateTimeKind.Local).AddTicks(6781), "Tooth removal", "Dentiest Appointment" },
                    { 2, 3000.0, 7, new DateTime(2024, 3, 12, 21, 31, 44, 800, DateTimeKind.Local).AddTicks(6783), "Went to Spain", "Travelling" },
                    { 3, 800.0, 8, new DateTime(2024, 3, 12, 21, 31, 44, 800, DateTimeKind.Local).AddTicks(6785), "Rent and bills", "Rent" }
                });

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

            migrationBuilder.DropTable(
                name: "expenseCategories");

            migrationBuilder.UpdateData(
                table: "incomes",
                keyColumn: "IncomeId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 3, 12, 15, 13, 57, 855, DateTimeKind.Local).AddTicks(2916));

            migrationBuilder.UpdateData(
                table: "incomes",
                keyColumn: "IncomeId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 3, 12, 15, 13, 57, 855, DateTimeKind.Local).AddTicks(2931));

            migrationBuilder.UpdateData(
                table: "incomes",
                keyColumn: "IncomeId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 3, 12, 15, 13, 57, 855, DateTimeKind.Local).AddTicks(2933));

            migrationBuilder.UpdateData(
                table: "incomes",
                keyColumn: "IncomeId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 3, 12, 15, 13, 57, 855, DateTimeKind.Local).AddTicks(2934));
        }
    }
}
