using Microsoft.EntityFrameworkCore;
using Personal_Expense_Tracking_System_Web_Api.Models;

namespace Personal_Expense_Tracking_System_Web_Api.Data
{
    public class ApplicationDB : DbContext
    {
        public ApplicationDB(DbContextOptions options) : base(options) { }

        public DbSet<Categories> categories { get; set; }
        public DbSet<Incomes> incomes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Categories>().HasData(
                new Categories { CategoryID = 1, CategoryName = "Salary" },
                new Categories { CategoryID = 2, CategoryName = "Freelancing" },
                new Categories { CategoryID = 3, CategoryName = "Invesments" },
                new Categories { CategoryID = 4, CategoryName = "Stocks" },
                new Categories { CategoryID = 5, CategoryName = "Bitcoin" },
                new Categories { CategoryID = 6, CategoryName = "Bank Transfer" },
                new Categories { CategoryID = 7, CategoryName = "Youtube" },
                new Categories { CategoryID = 8, CategoryName = "Other" }
                );

            modelBuilder.Entity<Incomes>().HasData(
                new Incomes { IncomeId = 1, SalaryAmount = 2000, Date = DateTime.Now, CategoryID = 5, Reference = "Bitcoin money"},
                new Incomes { IncomeId = 2, SalaryAmount = 8000, Date = DateTime.Now, CategoryID = 3, Reference = "Spotify"},
                new Incomes { IncomeId = 3, SalaryAmount = 1200, Date = DateTime.Now, CategoryID = 7,  Reference = "Youtube Addsense"},
                new Incomes { IncomeId = 4, SalaryAmount = 6000, Date = DateTime.Now, CategoryID = 1, Reference = "Developer Salary" }
                );
        }
    }
}
