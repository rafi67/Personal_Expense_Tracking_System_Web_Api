using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Personal_Expense_Tracking_System_Web_Api.ImageCrud.IImageCrud;
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
        private readonly IImageCrud _imageCrud;
        private JwtGenerator tokenGenerator;
        private readonly PasswordHasher<object> _passwordHasher;

        public AuthenticationController(IUnitOfWork unitOfWork, IOptionsMonitor<JwtConfig> optionsMonitor, IImageCrud imageCrud) 
        {
            _unitOfWork = unitOfWork;    
            _optionsMonitor = optionsMonitor;
            tokenGenerator = new JwtGenerator(_optionsMonitor);
            _imageCrud = imageCrud;
            _passwordHasher = new PasswordHasher<object>();
        }

        [HttpPost]
        public async Task<IActionResult> Signup(User obj)
        {
            var hashedPassword = _passwordHasher.HashPassword(null, obj.Password);
            obj.Password = hashedPassword;
            _unitOfWork.Users.Add(obj);
            _unitOfWork.Save();

            var userData = _unitOfWork.Users.Get(u => u.UserName == obj.UserName && u.Password == obj.Password);

            return Ok(new
            {
                message = "Singup Successfully",
                token = tokenGenerator.CreateJwt(userData),
            });
        }

        [HttpPost("{id:long}")]
        [Authorize]
        public async Task<IActionResult> UploadImage(long id, IFormFile image)
        {
            var user = _unitOfWork.Users.Get(u => u.UserID == id);
            user.UserPhoto = _imageCrud.StoreImage(image);

            _unitOfWork.Users.Update(user);
            _unitOfWork.Save();

            return Ok(200);
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
                    userData = _unitOfWork.Users.Get(u => u.Email == email);
                    break;
                }
            }

            if (email == null)
            {
                UserName = obj.UserNameOrEmail;
                userData = _unitOfWork.Users.Get(u => u.UserName == UserName);
            }

            var passwordVarify = _passwordHasher.VerifyHashedPassword(null, userData.Password, obj.Password);

            if (passwordVarify==PasswordVerificationResult.Success) 
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
