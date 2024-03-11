using Microsoft.EntityFrameworkCore;

namespace Personal_Expense_Tracking_System_Web_Api.Data
{
    public class ApplicationDB : DbContext
    {
        public ApplicationDB(DbContextOptions options) : base(options) { }
    }
}
