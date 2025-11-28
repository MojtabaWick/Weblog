using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using Weblog.Domain.Core.CategoryAgg.Contracts;
using Weblog.Domain.Core.CategoryAgg.Dtos;
using Weblog.Presentation.RazorPages.DataBase;

namespace Weblog.Presentation.RazorPages.Pages.Admin.Categories
{
    public class CreateModel(ICategoryService categoryService) : PageModel
    {
        [BindProperty]
        public CategoryInputDto Category { get; set; }

        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            Category.AuthorId = InMemoryDatabase.OnlineUser.Id;

            categoryService.Add(Category);

            return RedirectToPage("Index");
        }
    }
}