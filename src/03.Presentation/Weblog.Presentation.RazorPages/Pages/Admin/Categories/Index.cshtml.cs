using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Weblog.Domain.Core.CategoryAgg.Contracts;
using Weblog.Domain.Core.CategoryAgg.Dtos;

namespace Weblog.Presentation.RazorPages.Pages.Admin.Categories
{
    public class IndexModel(ICategoryService categoryService) : PageModel
    {
        public List<CategoryDto> Categories { get; set; }

        public void OnGet()
        {
            Categories = categoryService.GetAuthorCategory(1);
        }

        public IActionResult OnPostDelete(int id)
        {
            categoryService.DeleteCategory(id);
            return RedirectToPage();
        }
    }
}