using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Weblog.Domain.Core.CategoryAgg.Contracts;
using Weblog.Domain.Core.CategoryAgg.Dtos;

namespace Weblog.Presentation.RazorPages.Pages.Admin.Categories
{
    public class EditModel(ICategoryService categoryService) : PageModel
    {
        [BindProperty]
        public CategoryDto Input { get; set; }

        public IActionResult OnGet(int id)
        {
            var category = categoryService.GetCategoryById(id);

            if (category == null)
                return NotFound();

            Input = category;
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            if (!ModelState.IsValid)
                return Page();

            categoryService.UpdateCategory(id, Input);

            return RedirectToPage("Index");
        }
    }
}