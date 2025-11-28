using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Weblog.Domain.Core.CommentAgg.Contracts;
using Weblog.Domain.Core.CommentAgg.Dtos;
using Weblog.Presentation.RazorPages.DataBase;

namespace Weblog.Presentation.RazorPages.Pages.Admin.Comments
{
    public class IndexModel(ICommentService commentService) : PageModel
    {
        public List<CommentForAdminDto> Comments { get; set; }

        public IActionResult OnGet()
        {
            Comments = commentService.GetCommentsForAdmin(InMemoryDatabase.OnlineUser.Id);
            return Page();
        }

        public IActionResult OnGetApprove(int id)
        {
            commentService.SetApproved(id);

            return RedirectToPage();
        }

        public IActionResult OnGetReject(int id)
        {
            commentService.SetRejected(id);

            return RedirectToPage();
        }
    }
}