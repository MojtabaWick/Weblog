using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Weblog.Domain.Core.AuthorAgg.Contracts;
using Weblog.Domain.Core.AuthorAgg.Dtos;
using Weblog.Presentation.RazorPages.DataBase;
using Weblog.Presentation.RazorPages.Models;

namespace Weblog.Presentation.RazorPages.Pages.Account
{
    public class LoginModel(IAuthorService authorService) : PageModel
    {
        public string ResultMessage { get; set; }

        [BindProperty]
        public AuthorLoginInput Author { get; set; } = new AuthorLoginInput();

        public void OnGet(string message)
        {
            ResultMessage = message;
        }

        public IActionResult OnPost()
        {
            var loginResult = authorService.Login(Author);

            if (loginResult.IsSuccess)
            {
                InMemoryDatabase.OnlineUser = new OnlineUser
                {
                    Id = loginResult.Data.Id,
                    FirstName = loginResult.Data.FirstName,
                    LastName = loginResult.Data.LastName,
                    ImageUrl = loginResult.Data.ImageUrl,
                    Bio = loginResult.Data.Bio,
                };

                return RedirectToPage("/Admin/Posts/Index");
            }

            return RedirectToPage("/Account/Login", new { message = loginResult.Message });
        }
    }
}