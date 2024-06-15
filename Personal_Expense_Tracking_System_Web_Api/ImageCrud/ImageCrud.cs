using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Personal_Expense_Tracking_System_Web_Api.VmModel;
using System.IO;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Xml;

namespace Personal_Expense_Tracking_System_Web_Api.ImageCrud
{
    public class ImageCrud : IImageCrud.IImageCrud
    {

        public string StoreImage(IFormFile image)
        {
            string filename = $"{Guid.NewGuid()}{Path.GetExtension(image.FileName)}";
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Images", filename);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                image.CopyTo(stream);
                stream.Close();
            }

            return filename;
        }

        public UserImage ReadImage(string imageName)
        {
            var userImage = new UserImage();
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Images", imageName);
            byte[] imageBytes = File.ReadAllBytes(filePath);
            string contentType = GetContentType(filePath);
            userImage.ContentType = contentType;
            userImage.Image = imageBytes;
            return userImage;
        }

        public void DeleteImage(string imageName)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Images", imageName);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public string GetContentType(string path)
        {
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return ext switch
            {
                ".jpg" or ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".gif" => "image/gif",
                ".bmp" => "image/bmp",
                _ => "application/octet-stream",
            };
        }

    }
}
