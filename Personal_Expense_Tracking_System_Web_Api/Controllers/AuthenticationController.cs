using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Personal_Expense_Tracking_System_Web_Api.JwtToken;
using Personal_Expense_Tracking_System_Web_Api.Models;
using Personal_Expense_Tracking_System_Web_Api.Repository.IRepository;
using Personal_Expense_Tracking_System_Web_Api.VmModel;

namespace Personal_Expense_Tracking_System_Web_Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IOptionsMonitor<JwtConfig> _optionsMonitor;
        private JwtGenerator tokenGenerator;

        public AuthenticationController(IUnitOfWork unitOfWork, IOptionsMonitor<JwtConfig> optionsMonitor) 
        {
            _unitOfWork = unitOfWork;
            
            _optionsMonitor = optionsMonitor;
            tokenGenerator = new JwtGenerator(_optionsMonitor);
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserCredentials obj)
        {
            User userData = null;
            string email = null;
            string UserName = null;
            for (int i = 0; i < obj.UserNameOrEmail.Length; i++)
            {
                if (obj.UserNameOrEmail[i] == '@')
                {
                    email = obj.UserNameOrEmail;
                    userData = _unitOfWork.Users.Get(u => u.Email == email && u.Password == obj.Password);
                    break;
                }
            }

            if (email == null)
            {
                UserName = obj.UserNameOrEmail;
                userData = _unitOfWork.Users.Get(u => u.UserName == UserName && u.Password == obj.Password);
            }

            if (userData != null) 
                return Ok(new
            {
                token = tokenGenerator.CreateJwt(userData),
                message = "User found"
            });
            return Ok(new
            {
                token = "",
                message = "User not found"
            });
        }
    }
}
