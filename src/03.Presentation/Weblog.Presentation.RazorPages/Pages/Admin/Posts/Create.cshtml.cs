using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Weblog.Domain.Core.CategoryAgg.Contracts;
using Weblog.Domain.Core.CategoryAgg.Dtos;
using Weblog.Domain.Core.PostAgg.Contracts;
using Weblog.Domain.Core.PostAgg.Dtos;
using Weblog.Framework.Contracts;
using Weblog.Infrastructure.EFCore.Migrations;
using Weblog.Presentation.RazorPages.DataBase;

namespace Weblog.Presentation.RazorPages.Pages.Admin.Posts
{
    public class CreateModel(IFileService fileService, IPostService postService, ICategoryService categoryService) : PageModel
    {
        [BindProperty]
        public PostInputDto Post { get; set; }

        [BindProperty]
        public IFormFile ImageFile { get; set; }

        public List<CategoryDto> Categories { get; set; }

        public void OnGet()
        {
            Categories = categoryService.GetAuthorCategory(InMemoryDatabase.OnlineUser.Id);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ImageFile != null)
            {
                // 1) محدودیت حجم – 2 مگابایت
                long maxSize = 2 * 1024 * 1024; // 2MB
                if (ImageFile.Length > maxSize)
                {
                    ModelState.AddModelError("Input.ImageFile", "حجم فایل نباید بیشتر از 2 مگابایت باشد.");
                }

                // 2) محدودیت فرمت فایل
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
                var extension = Path.GetExtension(ImageFile.FileName).ToLower();

                if (!allowedExtensions.Contains(extension))
                {
                    ModelState.AddModelError("Input.ImageFile", "فقط فرمت‌های jpg و png مجاز هستند.");
                }
            }

            if (!ModelState.IsValid)
            {
                Categories = categoryService.GetAuthorCategory(InMemoryDatabase.OnlineUser.Id);
                return Page();
            }

            // آپلود تصویر
            if (ImageFile != null)
            {
                Post.ImageUrl = fileService.Upload(ImageFile, InMemoryDatabase.OnlineUser.Id.ToString());
            }

            // نویسنده پست
            Post.AuthorId = InMemoryDatabase.OnlineUser.Id;

            var result = postService.Add(Post);

            if (result.IsSuccess)
            {
                TempData["Message"] = result.Message;
                return RedirectToPage("Index");
            }

            ModelState.AddModelError("", result.Message);
            return Page();
        }
    }
}