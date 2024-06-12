﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Personal_Expense_Tracking_System_Web_Api.JwtToken;
using Personal_Expense_Tracking_System_Web_Api.Models;
using Personal_Expense_Tracking_System_Web_Api.Repository.IRepository;
using Personal_Expense_Tracking_System_Web_Api.VmModel;
using static System.Net.Mime.MediaTypeNames;

namespace Personal_Expense_Tracking_System_Web_Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IOptionsMonitor<JwtConfig> _optionsMonitor;
        private JwtGenerator tokenGenerator;
        private IWebHostEnvironment _env;

        public AuthenticationController(IUnitOfWork unitOfWork, IOptionsMonitor<JwtConfig> optionsMonitor, IWebHostEnvironment env) 
        {
            _unitOfWork = unitOfWork;
            
            _optionsMonitor = optionsMonitor;
            tokenGenerator = new JwtGenerator(_optionsMonitor);
            _env = env;
        }

        [HttpPost]
        public async Task<IActionResult> Signup(User obj)
        {
            


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
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UploadImage([FromBody] long id, [FromForm] IFormFile file)
        {
            string filename = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Images", filename);

            var user = _unitOfWork.Users.Get(u => u.UserID == id);
            user.UserPhoto = filename;
            _unitOfWork.Users.Update(user);
            _unitOfWork.Save();

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
                stream.Close();
            }
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
