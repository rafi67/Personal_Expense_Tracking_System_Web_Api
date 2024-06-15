using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Personal_Expense_Tracking_System_Web_Api.Migrations
{
    /// <inheritdoc />
    public partial class createAndSeedAllTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    CategoryID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "expenseCategories",
                columns: table => new
                {
                    ExpenseCategoryID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_expenseCategories", x => x.ExpenseCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    UserID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPhoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserRole = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "expenses",
                columns: table => new
                {
                    ExpenseID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpenseAmount = table.Column<double>(type: "float", nullable: false),
                    ExpenseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpenseCategoryID = table.Column<long>(type: "bigint", nullable: false),
                    ExpenseReference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserID = table.Column<long>(type: "bigint", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_expenses_users_UserID",
                        column: x => x.UserID,
                        principalTable: "users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "incomes",
                columns: table => new
                {
                    IncomeId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalaryTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalaryAmount = table.Column<double>(type: "float", nullable: false),
                    CategoryID = table.Column<long>(type: "bigint", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_incomes", x => x.IncomeId);
                    table.ForeignKey(
                        name: "FK_incomes_categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_incomes_users_UserID",
                        column: x => x.UserID,
                        principalTable: "users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[,]
                {
                    { 1L, "Salary" },
                    { 2L, "Freelancing" },
                    { 3L, "Invesments" },
                    { 4L, "Stocks" },
                    { 5L, "Bitcoin" },
                    { 6L, "Bank Transfer" },
                    { 7L, "Youtube" },
                    { 8L, "Other" }
                });

            migrationBuilder.InsertData(
                table: "expenseCategories",
                columns: new[] { "ExpenseCategoryID", "CategoryName" },
                values: new object[,]
                {
                    { 1L, "Education" },
                    { 2L, "Groceries" },
                    { 3L, "Health" },
                    { 4L, "Subscriptions" },
                    { 5L, "Takeaways" },
                    { 6L, "Clothing" },
                    { 7L, "Travelling" },
                    { 8L, "Other" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "UserID", "Email", "FirstName", "Gender", "LastName", "Password", "UserName", "UserPhoto", "UserRole" },
                values: new object[] { 1L, "rafisiddique652@gmail.com", "Rafi", "Male", "Siddique", "admin", "Admin", "rafi.jpg", "Admin" });

            migrationBuilder.InsertData(
                table: "expenses",
                columns: new[] { "ExpenseID", "ExpenseAmount", "ExpenseCategoryID", "ExpenseDate", "ExpenseReference", "ExpenseTitle", "UserID" },
                values: new object[,]
                {
                    { 1L, 120.0, 3L, new DateTime(2024, 6, 13, 10, 3, 14, 500, DateTimeKind.Local).AddTicks(8057), "Tooth removal", "Dentiest Appointment", 1L },
                    { 2L, 3000.0, 7L, new DateTime(2024, 6, 13, 10, 3, 14, 500, DateTimeKind.Local).AddTicks(8060), "Went to Spain", "Travelling", 1L },
                    { 3L, 800.0, 8L, new DateTime(2024, 6, 13, 10, 3, 14, 500, DateTimeKind.Local).AddTicks(8063), "Rent and bills", "Rent", 1L }
                });

            migrationBuilder.InsertData(
                table: "incomes",
                columns: new[] { "IncomeId", "CategoryID", "Date", "Reference", "SalaryAmount", "SalaryTitle", "UserID" },
                values: new object[,]
                {
                    { 1L, 5L, new DateTime(2024, 6, 13, 10, 3, 14, 500, DateTimeKind.Local).AddTicks(7860), "From freelance works.", 1300.0, "From Freelance", 1L },
                    { 2L, 3L, new DateTime(2024, 6, 13, 10, 3, 14, 500, DateTimeKind.Local).AddTicks(7886), "My January Spotify earnings.", 8000.0, "Spotify", 1L },
                    { 3L, 7L, new DateTime(2024, 6, 13, 10, 3, 14, 500, DateTimeKind.Local).AddTicks(7888), "My January youtube earnings.", 1200.0, "Youtube Adsense", 1L },
                    { 4L, 1L, new DateTime(2024, 6, 13, 10, 3, 14, 500, DateTimeKind.Local).AddTicks(7890), "My January developer salary.", 6000.0, "Developer Salary", 1L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_expenses_ExpenseCategoryID",
                table: "expenses",
                column: "ExpenseCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_expenses_UserID",
                table: "expenses",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_incomes_CategoryID",
                table: "incomes",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_incomes_UserID",
                table: "incomes",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "expenses");

            migrationBuilder.DropTable(
                name: "incomes");

            migrationBuilder.DropTable(
                name: "expenseCategories");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
