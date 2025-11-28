using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Weblog.Domain.Core.PostAgg.Contracts;
using Weblog.Domain.Core.PostAgg.Dtos;

namespace Weblog.Presentation.RazorPages.Pages.Post
{
    public class DetailsModel : PageModel
    {
        private readonly IPostService postService;

        public DetailsModel(IPostService postService)
        {
            this.postService = postService;
        }

        public PostShowDto Post { get; set; }

        public IActionResult OnGet(int id)
        {
            Post = postService.GetPostDetails(id);

            if (Post == null)
                return NotFound(); // اگه پست پیدا نشد

            return Page();
        }
    }
}