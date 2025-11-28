using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Weblog.Domain.Core.CategoryAgg.Contracts;
using Weblog.Domain.Core.CategoryAgg.Dtos;
using Weblog.Domain.Core.PostAgg.Contracts;
using Weblog.Domain.Core.PostAgg.Dtos;

namespace Weblog.Presentation.RazorPages.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;

        public IndexModel(IPostService postService, ICategoryService categoryService)
        {
            _postService = postService;
            _categoryService = categoryService;
        }

        public HomePagePostsDto HomePage { get; set; }
        public List<CategoryDto> Categories { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? CategoryId { get; set; }

        public void OnGet([FromQuery] int page = 1)
        {
            Categories = _categoryService.GetAllCategories();
            HomePage = _postService.GetHomePagePosts(page, 5, CategoryId);
        }
    }
}