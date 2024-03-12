using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Personal_Expense_Tracking_System_Web_Api.Models
{
    public class Expenses
    {
        [Key]
        public int ExpenseID { get; set; }
        public string ExpenseTitle { get; set; }
        public double ExpenseAmount { get; set; }
        public DateTime ExpenseDate { get; set; }
        public int ExpenseCategoryID { get; set; }
        public string ExpenseReference { get; set; }
        [ValidateNever]
        [ForeignKey(nameof(ExpenseCategoryID))]
        public ExpenseCategories ExpenseCategories { get; set; }
    }
}
