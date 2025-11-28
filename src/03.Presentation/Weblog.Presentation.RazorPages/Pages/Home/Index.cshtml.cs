using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Weblog.Domain.Core.PostAgg.Contracts;
using Weblog.Domain.Core.PostAgg.Dtos;

namespace Weblog.Presentation.RazorPages.Pages.Home
{
    public class IndexModel : PageModel
    {
        private readonly IPostService _postService;

        public IndexModel(IPostService postService)
        {
            _postService = postService;
        }

        public HomePagePostsDto HomePage { get; set; }

        public void OnGet([FromQuery] int page = 1)
        {
            HomePage = _postService.GetHomePagePosts(page, 5);
        }
    }
}