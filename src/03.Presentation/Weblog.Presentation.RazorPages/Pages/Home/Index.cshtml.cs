using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Weblog.Domain.Core.PostAgg.Contracts;
using Weblog.Domain.Core.PostAgg.Dtos;

namespace Weblog.Presentation.RazorPages.Pages.Home
{
    public class IndexModel(IPostService postService) : PageModel
    {
        public HomePagePostsDto HomePage { get; set; }

        public void OnGet(int page = 1)
        {
            HomePage = postService.GetHomePagePosts(page, 5);
        }
    }
}