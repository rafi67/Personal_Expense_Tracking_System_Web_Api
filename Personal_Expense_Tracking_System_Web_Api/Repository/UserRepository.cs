using Personal_Expense_Tracking_System_Web_Api.Data;
using Personal_Expense_Tracking_System_Web_Api.Models;
using Personal_Expense_Tracking_System_Web_Api.Repository.IRepository;

namespace Personal_Expense_Tracking_System_Web_Api.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {

        private ApplicationDB _db;

        public UserRepository(ApplicationDB db) : base(db)
        {
            _db = db;
        }

        public void  Update(User obj)
        {
            _db.users.Update(obj);
        }

    }
}
