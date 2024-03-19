using Personal_Expense_Tracking_System_Web_Api.Models;

namespace Personal_Expense_Tracking_System_Web_Api.Repository.IRepository
{
    public interface IExpensesRepository : IRepository<Expenses>
    {
        void Update(Expenses obj);
    }
}
