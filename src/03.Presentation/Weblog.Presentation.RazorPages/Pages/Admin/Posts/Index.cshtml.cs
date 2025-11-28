using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Weblog.Domain.Core.PostAgg.Contracts;
using Weblog.Domain.Core.PostAgg.Dtos;
using Weblog.Presentation.RazorPages.DataBase;

namespace Weblog.Presentation.RazorPages.Pages.Admin.Posts
{
    public class IndexModel(IPostService postService) : PageModel
    {
        public List<AuthorPostDtos> Posts { get; set; }

        public void OnGet()
        {
            Posts = postService.GetAuthorPosts(InMemoryDatabase.OnlineUser.Id);
        }

        public IActionResult OnPostDelete(int id)
        {
            postService.DeletePost(id);
            return RedirectToPage();
        }
    }
}