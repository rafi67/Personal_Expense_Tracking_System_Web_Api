using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Personal_Expense_Tracking_System_Web_Api.Models;
using Personal_Expense_Tracking_System_Web_Api.Repository.IRepository;
using Personal_Expense_Tracking_System_Web_Api.VmModel;
using System.IO;
using Microsoft.Extensions.FileProviders;
using Personal_Expense_Tracking_System_Web_Api.ImageCrud.IImageCrud;

namespace Personal_Expense_Tracking_System_Web_Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageCrud _imageCrud;

        public UsersController(IUnitOfWork unitOfWork, IImageCrud imageCrud) 
        {
            _unitOfWork = unitOfWork;
            _imageCrud = imageCrud;
        }

        [HttpGet]
        public async Task<IEnumerable<UserData>> GetAllUser() 
        {
            var data =  _unitOfWork.Users.GetAll();
            List<UserData>userDataList = new List<UserData>();
            foreach(var user in data)
            {
                UserData userData = new UserData();
                userData.UserID = user.UserID;
                userData.FirstName = user.FirstName;
                userData.LastName = user.LastName;
                userData.Email = user.Email;
                userData.UserRole = user.UserRole;
                userData.Gender = user.Gender;
                userData.UserPhoto = user.UserPhoto;
                userDataList.Add(userData);
            }
            return userDataList;
        }

        [HttpGet("{id:long}")]
        public async Task<UserData> GetUser(long id)
        {
            var data = _unitOfWork.Users.Get(u => u.UserID == id);
            UserData userData = new UserData();
            userData.UserID = data.UserID;
            userData.FirstName = data.FirstName;
            userData.LastName = data.LastName;
            userData.Email = data.Email;
            userData.UserRole = data.UserRole;
            userData.Gender = data.Gender;
            userData.UserPhoto = data.UserPhoto;
            return userData;
        }

        [HttpGet("{id:long}")]
        [Authorize]
        public async Task<IActionResult> GetUserImage(long id)
        {
            var user = _unitOfWork.Users.Get(u => u.UserID == id);
            string imageName = user.UserPhoto;
            var imageData = _imageCrud.ReadImage(imageName);
            return File(imageData.Image, imageData.ContentType);
        }

        [HttpGet("{id:long}/{password}")]
        [Authorize]
        public async Task<IActionResult> ChangePassword(long id, string password)
        {
            var data = _unitOfWork.Users.Get(u=>u.UserID == id);
            data.Password = password;
            _unitOfWork.Users.Update(data);
            _unitOfWork.Save();
            return Ok(200);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(User obj)
        {
            _unitOfWork.Users.Add(obj);
            _unitOfWork.Save();
            return Ok(200);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(User obj)
        {
            var userData = _unitOfWork.Users.Get(u => u.UserID == obj.UserID);
            _unitOfWork.Users.Update(obj);
            _unitOfWork.Save();
            return Ok(200);
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> UpdateUserImage(long id, IFormFile file)
        {
            var user = _unitOfWork.Users.Get(u => u.UserID == id);
            _imageCrud.DeleteImage(user.UserPhoto);
            var fileName = _imageCrud.StoreImage(file);
            user.UserPhoto = fileName;
            _unitOfWork.Users.Update(user);
            _unitOfWork.Save();
            return Ok(200);
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            var obj = _unitOfWork.Users.Get(u=>u.UserID==id);
            _imageCrud.DeleteImage(obj.UserPhoto);
            _unitOfWork.Users.Remove(obj);
            _unitOfWork.Save();
            return Ok(200);
        }

    }
}
