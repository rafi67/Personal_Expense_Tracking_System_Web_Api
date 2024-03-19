using Personal_Expense_Tracking_System_Web_Api.Data;
using Personal_Expense_Tracking_System_Web_Api.Models;
using Personal_Expense_Tracking_System_Web_Api.Repository.IRepository;

namespace Personal_Expense_Tracking_System_Web_Api.Repository
{
    public class IncomesRepository : Repository<Incomes>, IIncomesRepository
    {
        private ApplicationDB _db;

        public IncomesRepository(ApplicationDB db) : base(db)
        {
            _db = db;
        }

        public void Update(Incomes obj)
        {
            _db.incomes.Update(obj);
        }
    }
}
