using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Weblog.Domain.Core.CommentAgg.Contracts;
using Weblog.Domain.Core.CommentAgg.Dtos;

namespace Weblog.Presentation.RazorPages.Pages.Post
{
    public class AddCommentModel : PageModel
    {
        private readonly ICommentService commentService;

        public AddCommentModel(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        [BindProperty]
        public CommentInputDto Input { get; set; }

        public IActionResult OnGet(int postId)
        {
            Input = new CommentInputDto
            {
                PostId = postId
            };

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            commentService.CreateComment(Input);

            return RedirectToPage("Details", new { id = Input.PostId });
        }
    }
}