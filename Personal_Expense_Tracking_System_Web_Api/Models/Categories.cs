using System.ComponentModel.DataAnnotations;

namespace Personal_Expense_Tracking_System_Web_Api.Models
{
    public class Categories
    {
        [Key]
        public long CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
