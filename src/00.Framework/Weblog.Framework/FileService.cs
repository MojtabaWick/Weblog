using Microsoft.AspNetCore.Http;
using Weblog.Framework.Contracts;

namespace Weblog.Framework
{
    public class FileService : IFileService
    {
        public string Upload(IFormFile file, string folder)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("فایل معتبر نیست.");

            // مسیر فیزیکی فولدر uploads
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", folder);

            // ایجاد فولدر در صورت عدم وجود
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            // ایجاد نام یکتا برای فایل
            var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            // مسیر کامل فایل
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            // ذخیره فایل روی دیسک
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            // مسیر مناسب برای URL (/Files/folder/filename.ext)
            var urlPath = $"/Files/{folder}/{uniqueFileName}";

            return urlPath;
        }
    }
}