using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Personal_Expense_Tracking_System_Web_Api.Migrations
{
    /// <inheritdoc />
    public partial class seedingCategoriesAndIncomesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "incomes",
                columns: table => new
                {
                    IncomeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalaryAmount = table.Column<double>(type: "float", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Salary" },
                    { 2, "Freelancing" },
                    { 3, "Invesments" },
                    { 4, "Stocks" },
                    { 5, "Bitcoin" },
                    { 6, "Bank Transfer" },
                    { 7, "Youtube" },
                    { 8, "Other" }
                });

            migrationBuilder.InsertData(
                table: "incomes",
                columns: new[] { "IncomeId", "CategoryID", "Date", "Reference", "SalaryAmount" },
                values: new object[,]
                {
                    { 1, 5, new DateTime(2024, 3, 12, 15, 13, 57, 855, DateTimeKind.Local).AddTicks(2916), "Bitcoin money", 2000.0 },
                    { 2, 3, new DateTime(2024, 3, 12, 15, 13, 57, 855, DateTimeKind.Local).AddTicks(2931), "Spotify", 8000.0 },
                    { 3, 7, new DateTime(2024, 3, 12, 15, 13, 57, 855, DateTimeKind.Local).AddTicks(2933), "Youtube Addsense", 1200.0 },
                    { 4, 1, new DateTime(2024, 3, 12, 15, 13, 57, 855, DateTimeKind.Local).AddTicks(2934), "Developer Salary", 6000.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_incomes_CategoryID",
                table: "incomes",
                column: "CategoryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "incomes");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
