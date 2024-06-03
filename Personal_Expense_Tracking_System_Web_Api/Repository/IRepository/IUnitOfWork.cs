namespace Personal_Expense_Tracking_System_Web_Api.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoriesRepository Categories { get; }
        IIncomesRepository Incomes { get; }
        IExpenseCategoriesRepository ExpenseCategories { get; }
        IExpensesRepository Expenses { get; }
        IUserRepository Users { get; }

        void Save();
    }
}
