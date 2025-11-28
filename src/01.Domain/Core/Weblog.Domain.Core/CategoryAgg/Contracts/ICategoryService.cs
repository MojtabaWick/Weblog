using Weblog.Domain.Core._common;
using Weblog.Domain.Core.CategoryAgg.Dtos;

namespace Weblog.Domain.Core.CategoryAgg.Contracts
{
    public interface ICategoryService
    {
        public Result<bool> Add(CategoryInputDto input);

        public void DeleteCategory(int categoryId);

        public List<CategoryDto> GetAuthorCategory(int AuthorId);

        public CategoryDto? GetCategoryById(int id);

        public void UpdateCategory(int id, CategoryDto input);
    }
}