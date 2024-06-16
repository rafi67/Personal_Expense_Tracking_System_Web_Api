using Microsoft.EntityFrameworkCore;
using Personal_Expense_Tracking_System_Web_Api.Data;

namespace Personal_Expense_Tracking_System_Web_Api.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {

        private readonly ApplicationDB _db;

        public DbInitializer(ApplicationDB db)
        {
            _db = db;
        }

        public void Initializer()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception ex)
            {

            }
        }

    }
}
