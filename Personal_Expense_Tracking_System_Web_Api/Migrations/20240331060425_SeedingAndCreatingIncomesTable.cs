using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Personal_Expense_Tracking_System_Web_Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedingAndCreatingIncomesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "incomes",
                columns: table => new
                {
                    IncomeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalaryTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                table: "incomes",
                columns: new[] { "IncomeId", "CategoryID", "Date", "Reference", "SalaryAmount", "SalaryTitle" },
                values: new object[,]
                {
                    { 1, 5, new DateTime(2024, 3, 31, 12, 4, 25, 540, DateTimeKind.Local).AddTicks(6177), "From freelance works.", 1300.0, "From Freelance" },
                    { 2, 3, new DateTime(2024, 3, 31, 12, 4, 25, 540, DateTimeKind.Local).AddTicks(6191), "My January Spotify earnings.", 8000.0, "Spotify" },
                    { 3, 7, new DateTime(2024, 3, 31, 12, 4, 25, 540, DateTimeKind.Local).AddTicks(6192), "My January youtube earnings.", 1200.0, "Youtube Adsense" },
                    { 4, 1, new DateTime(2024, 3, 31, 12, 4, 25, 540, DateTimeKind.Local).AddTicks(6193), "My January developer salary.", 6000.0, "Developer Salary" }
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
        }
    }
}
