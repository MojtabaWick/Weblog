using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Weblog.Domain.Core.CategoryAgg.Contracts;
using Weblog.Domain.Core.CategoryAgg.Dtos;
using Weblog.Domain.Core.PostAgg.Contracts;
using Weblog.Domain.Core.PostAgg.Dtos;
using Weblog.Framework.Contracts;
using Weblog.Presentation.RazorPages.DataBase;

namespace Weblog.Presentation.RazorPages.Pages.Admin.Posts
{
    public class EditModel(IPostService postService,
        ICategoryService categoryService,
        IFileService fileService) : PageModel
    {
        [BindProperty]
        public PostInputDto Input { get; set; }

        public List<SelectListItem> Categories { get; set; }

        public IActionResult OnGet(int id)
        {
            var post = postService.GetPostById(id);
            if (post == null)
                return NotFound();

            Input = new PostInputDto
            {
                Title = post.Title,
                Content = post.Content,
                ImageUrl = post.ImageUrl,
                CategoryId = post.CategoryId,
                AuthorId = InMemoryDatabase.OnlineUser!.Id,
            };

            var cats = categoryService
                 .GetAuthorCategory(InMemoryDatabase.OnlineUser.Id);

            Categories = cats
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                })
                .ToList();

            return Page();
        }

        public IActionResult OnPost(int id)
        {
            if (!ModelState.IsValid)
                return Page();

            if (Input.ImageFile != null)
            {
                Input.ImageUrl = fileService.Upload(Input.ImageFile, InMemoryDatabase.OnlineUser.Id.ToString());
            }

            Input.AuthorId = InMemoryDatabase.OnlineUser.Id;

            postService.UpdatePost(id, Input);

            return RedirectToPage("Index");
        }
    }
}