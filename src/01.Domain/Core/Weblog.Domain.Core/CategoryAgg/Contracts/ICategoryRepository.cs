using Weblog.Domain.Core.CategoryAgg.Dtos;
using Weblog.Domain.Core.CategoryAgg.Entities;

namespace Weblog.Domain.Core.CategoryAgg.Contracts
{
    public interface ICategoryRepository
    {
        public bool Add(Category newCategory);

        public List<CategoryDto> GetAllCategories();

        public void DeleteCategory(int categoryId);

        public List<CategoryDto> GetAuthorCategory(int AuthorId);

        public CategoryDto? GetCategoryById(int id);

        public void UpdateCategory(int id, CategoryDto input);
    }
}