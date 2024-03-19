using Personal_Expense_Tracking_System_Web_Api.Data;
using Personal_Expense_Tracking_System_Web_Api.Models;
using Personal_Expense_Tracking_System_Web_Api.Repository.IRepository;

namespace Personal_Expense_Tracking_System_Web_Api.Repository
{
    public class ExpensesRepository : Repository<Expenses>, IExpensesRepository
    {
        private ApplicationDB _db;

        public ExpensesRepository(ApplicationDB db) : base(db)
        {
            _db = db;
        }

        public void Update(Expenses obj)
        {
            _db.expenses.Update(obj);
        }
    }
}
