using System.ComponentModel.DataAnnotations;

namespace Personal_Expense_Tracking_System_Web_Api.Models
{
    public class User
    {
        [Key]
        public long UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string UserPhoto { get; set; }
        public string UserRole { get; set; }
    }
}
