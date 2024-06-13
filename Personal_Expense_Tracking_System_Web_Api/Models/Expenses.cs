using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Personal_Expense_Tracking_System_Web_Api.Models
{
    public class Expenses
    {
        [Key]
        public long ExpenseID { get; set; }
        public string ExpenseTitle { get; set; }
        public double ExpenseAmount { get; set; }
        public DateTime ExpenseDate { get; set; }
        public long ExpenseCategoryID { get; set; }
        public string ExpenseReference { get; set; }
        public long UserID { get; set; }
        [ValidateNever]
        [ForeignKey("ExpenseCategoryID")]
        public ExpenseCategories ExpenseCategories { get; set; }
        [ValidateNever]
        [ForeignKey("UserID")]
        public User Users { get; set; }
    }
}
