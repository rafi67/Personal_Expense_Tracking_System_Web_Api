using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Personal_Expense_Tracking_System_Web_Api.Models
{
    public class Incomes
    {
        [Key]
        public int IncomeId { get; set; }
        public double SalaryAmount { get; set; }
        public int CategoryID { get; set; }
        public DateTime Date { get; set; }
        public string Reference { get; set; }
        [ForeignKey("CategoryID")]
        [ValidateNever]
        public Categories Categories { get; set; }
    }
}
