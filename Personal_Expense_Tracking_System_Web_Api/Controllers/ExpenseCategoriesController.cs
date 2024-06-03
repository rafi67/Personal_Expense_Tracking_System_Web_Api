using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Personal_Expense_Tracking_System_Web_Api.Models;
using Personal_Expense_Tracking_System_Web_Api.Repository.IRepository;

namespace Personal_Expense_Tracking_System_Web_Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ExpenseCategoriesController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        public ExpenseCategoriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IEnumerable<ExpenseCategories>> GetAllExpenseCategory()
        {
            return _unitOfWork.ExpenseCategories.GetAll();
        }

    }
}
