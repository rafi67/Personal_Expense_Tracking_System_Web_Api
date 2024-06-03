using Personal_Expense_Tracking_System_Web_Api.Data;
using Personal_Expense_Tracking_System_Web_Api.Repository.IRepository;

namespace Personal_Expense_Tracking_System_Web_Api.Repository
{
    public class UniteOfWork : IUnitOfWork
    {
        private ApplicationDB _db;
        public ICategoriesRepository Categories { get; private set; }

        public IIncomesRepository Incomes { get; private set; }

        public IExpenseCategoriesRepository ExpenseCategories { get; private set; }

        public IExpensesRepository Expenses {  get; private set; }

        public IUserRepository Users { get; private set; }

        public UniteOfWork(ApplicationDB db)
        {
            _db = db;
            Categories = new CategoriesRepository(_db);
            Incomes = new IncomesRepository(_db);
            ExpenseCategories = new ExpenseCategoriesRepository(_db);
            Expenses = new ExpensesRepository(_db);
            Users = new UserRepository(_db);
        }


        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
