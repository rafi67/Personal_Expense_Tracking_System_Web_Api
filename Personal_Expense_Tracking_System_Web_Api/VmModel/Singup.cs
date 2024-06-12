using Personal_Expense_Tracking_System_Web_Api.Models;

namespace Personal_Expense_Tracking_System_Web_Api.VmModel
{
    public class Singup
    {
        public User UserData {  get; set; }
        public IFormFile FormData { get; set; }
    }
}
