using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Weblog.Domain.Core.AuthorAgg.Contracts;
using Weblog.Domain.Core.AuthorAgg.Dtos;
using Weblog.Framework.Contracts;
using Weblog.Presentation.RazorPages.DataBase;

namespace Weblog.Presentation.RazorPages.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly IAuthorService _authorService;
        private readonly IFileService _fileService;

        public RegisterModel(IAuthorService authorService, IFileService fileService)
        {
            _authorService = authorService;
            _fileService = fileService;
        }

        [BindProperty]
        public AuthorRegisterDto Input { get; set; } = new AuthorRegisterDto();

        [BindProperty]
        public IFormFile ImageFile { get; set; }

        public string ResultMessage { get; set; }

        public void OnGet(string message)
        {
            ResultMessage = message;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            // آپلود تصویر و تبدیل به URL
            if (ImageFile != null)
            {
                Input.ImageUrl = _fileService.Upload(ImageFile, InMemoryDatabase.OnlineUser?.Id.ToString() ?? "0");
            }

            var result = _authorService.Register(Input);

            if (result.IsSuccess)
            {
                return RedirectToPage("/Account/Login", new { message = result.Message });
            }

            ResultMessage = result.Message;
            return Page();
        }
    }
}