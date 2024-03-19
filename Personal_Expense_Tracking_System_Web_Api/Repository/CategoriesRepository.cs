using Personal_Expense_Tracking_System_Web_Api.Data;
using Personal_Expense_Tracking_System_Web_Api.Models;
using Personal_Expense_Tracking_System_Web_Api.Repository.IRepository;

namespace Personal_Expense_Tracking_System_Web_Api.Repository
{
    public class CategoriesRepository : Repository<Categories>, ICategoriesRepository
    {
        private ApplicationDB _db;
        public CategoriesRepository(ApplicationDB db) : base(db)
        {
            _db = db;
        }
        public void Update(Categories obj)
        {
            _db.categories.Update(obj);
        }
    }
}
