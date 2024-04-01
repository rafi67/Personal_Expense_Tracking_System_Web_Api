using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Personal_Expense_Tracking_System_Web_Api.Models;
using Personal_Expense_Tracking_System_Web_Api.Repository.IRepository;
using System.Collections.Generic;

namespace Personal_Expense_Tracking_System_Web_Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        public ExpenseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IEnumerable<Expenses>> GetAllExpenses()
        {
            return _unitOfWork.Expenses.GetAll(includeProperties: "ExpenseCategories");
        }

        [HttpGet("{id:long}")]
        public async Task<Expenses> GetExpense([FromRoute] int id)
        {
            return _unitOfWork.Expenses.Get(u => u.ExpenseID == id);
        }

        [HttpPost]
        public async Task<IActionResult> AddExpense(Expenses obj)
        {
            _unitOfWork.Expenses.Add(obj);
            _unitOfWork.Save();
            return Ok(200);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateExpense(Expenses obj)
        {
            _unitOfWork.Expenses.Update(obj);
            _unitOfWork.Save();
            return Ok(200);
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteExpense([FromRoute] int id)
        {
            var expense = _unitOfWork.Expenses.Get(u => u.ExpenseID == id);
            _unitOfWork.Expenses.Remove(expense);
            _unitOfWork.Save();
            return Ok(200);
        }

    }
}
