using Personal_Expense_Tracking_System_Web_Api.Models;

namespace Personal_Expense_Tracking_System_Web_Api.Repository.IRepository
{
    public interface ICategoriesRepository : IRepository<Categories>
    {
        void Update(Categories obj);
    }
}
