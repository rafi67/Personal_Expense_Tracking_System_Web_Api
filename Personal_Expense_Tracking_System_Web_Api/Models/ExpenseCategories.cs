using System.ComponentModel.DataAnnotations;

namespace Personal_Expense_Tracking_System_Web_Api.Models
{
    public class ExpenseCategories
    {
        [Key]
        public int ExpenseCategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
