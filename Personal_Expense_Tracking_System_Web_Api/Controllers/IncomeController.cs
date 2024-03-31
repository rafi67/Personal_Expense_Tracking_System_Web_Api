using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Personal_Expense_Tracking_System_Web_Api.Data;
using Personal_Expense_Tracking_System_Web_Api.Models;
using Personal_Expense_Tracking_System_Web_Api.Repository;
using Personal_Expense_Tracking_System_Web_Api.Repository.IRepository;

namespace Personal_Expense_Tracking_System_Web_Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IncomeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public IncomeController(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IEnumerable<Incomes>> GetAllIncomes()
        {
            return _unitOfWork.Incomes.GetAll(includeProperties:"Categories");
        }

        [HttpGet("/{id:long}")]
        public async Task<Incomes> GetIncome(int id)
        {
            return _unitOfWork.Incomes.Get(u => u.IncomeId == id);
        }

        [HttpPost]
        public async Task<IActionResult> AddIncome(Incomes obj)
        {
            _unitOfWork.Incomes.Add(obj);
            _unitOfWork.Save();
            return Ok(200);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateIncome(Incomes obj)
        {
            _unitOfWork.Incomes.Update(obj);
            _unitOfWork.Save();
            return Ok(200);
        }

        [HttpDelete("/{id:long}")]
        public async Task<IActionResult> DeleteIncome([FromRoute]int id)
        {
            var income = _unitOfWork.Incomes.Get(u => u.IncomeId == id);
            _unitOfWork.Incomes.Remove(income);
            _unitOfWork.Save();
            return Ok(200);
        }
    }
}
