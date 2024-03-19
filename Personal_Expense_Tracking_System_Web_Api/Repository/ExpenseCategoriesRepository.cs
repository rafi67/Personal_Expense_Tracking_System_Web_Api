using Personal_Expense_Tracking_System_Web_Api.Data;
using Personal_Expense_Tracking_System_Web_Api.Models;
using Personal_Expense_Tracking_System_Web_Api.Repository.IRepository;

namespace Personal_Expense_Tracking_System_Web_Api.Repository
{
    public class ExpenseCategoriesRepository : Repository<ExpenseCategories>, IExpenseCategoriesRepository
    {

        private ApplicationDB _db;

        public ExpenseCategoriesRepository(ApplicationDB db) : base(db)
        {
            _db = db;
        }

        public void Update(ExpenseCategories obj)
        {
            _db.expenseCategories.Update(obj);
        }
    }
}
