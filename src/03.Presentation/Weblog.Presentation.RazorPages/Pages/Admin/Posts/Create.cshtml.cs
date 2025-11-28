using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Weblog.Domain.Core.CategoryAgg.Contracts;
using Weblog.Domain.Core.CategoryAgg.Dtos;
using Weblog.Domain.Core.PostAgg.Contracts;
using Weblog.Domain.Core.PostAgg.Dtos;
using Weblog.Framework.Contracts;
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
            if (!ModelState.IsValid)
                return Page();

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