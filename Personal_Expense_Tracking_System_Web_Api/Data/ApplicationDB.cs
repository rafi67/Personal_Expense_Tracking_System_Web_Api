using Microsoft.EntityFrameworkCore;
using Personal_Expense_Tracking_System_Web_Api.Models;

namespace Personal_Expense_Tracking_System_Web_Api.Data
{
    public class ApplicationDB : DbContext
    {
        public ApplicationDB(DbContextOptions options) : base(options) { }

        public DbSet<Categories> categories { get; set; }
        public DbSet<Incomes> incomes { get; set; }
        public DbSet<ExpenseCategories> expenseCategories { get; set; }
        public DbSet<Expenses> expenses { get; set; }

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

            modelBuilder.Entity<ExpenseCategories>().HasData(
                new ExpenseCategories { ExpenseCategoryID = 1, CategoryName = "Education" },
                new ExpenseCategories { ExpenseCategoryID = 2, CategoryName = "Groceries" },
                new ExpenseCategories { ExpenseCategoryID = 3, CategoryName = "Health" },
                new ExpenseCategories { ExpenseCategoryID = 4, CategoryName = "Subscriptions" },
                new ExpenseCategories { ExpenseCategoryID = 5, CategoryName = "Takeaways" },
                new ExpenseCategories { ExpenseCategoryID = 6, CategoryName = "Clothing" },
                new ExpenseCategories { ExpenseCategoryID = 7, CategoryName = "Travelling" },
                new ExpenseCategories { ExpenseCategoryID = 8, CategoryName = "Other" }
                );

            modelBuilder.Entity<Expenses>().HasData(
                new Expenses { ExpenseID = 1, ExpenseTitle = "Dentiest Appointment", ExpenseAmount = 120, ExpenseDate = DateTime.Now, ExpenseCategoryID = 3, ExpenseReference = "Tooth removal"},
                new Expenses { ExpenseID = 2, ExpenseTitle = "Travelling", ExpenseAmount = 3000, ExpenseDate = DateTime.Now, ExpenseCategoryID = 7, ExpenseReference = "Went to Spain" },
                new Expenses { ExpenseID = 3, ExpenseTitle = "Rent", ExpenseAmount = 800, ExpenseDate = DateTime.Now, ExpenseCategoryID = 8, ExpenseReference = "Rent and bills" }
                );
        }
    }
}
