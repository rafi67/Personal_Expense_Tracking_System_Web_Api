using Microsoft.AspNetCore.Mvc;
using Personal_Expense_Tracking_System_Web_Api.VmModel;

namespace Personal_Expense_Tracking_System_Web_Api.ImageCrud.IImageCrud
{
    public interface IImageCrud
    {
        string StoreImage(IFormFile image);
        UserImage ReadImage(string  imageName);
        void DeleteImage(string imageName);
        string GetContentType(string path);
    }
}
