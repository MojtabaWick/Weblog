using Weblog.Domain.Core._common;
using Weblog.Domain.Core.CategoryAgg.Contracts;
using Weblog.Domain.Core.CategoryAgg.Dtos;
using Weblog.Domain.Core.CategoryAgg.Entities;

namespace Weblog.Domain.Service.Services.CategoryAgg
{
    public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
    {
        public Result<bool> Add(CategoryInputDto input)
        {
            var newCategory = new Category()
            {
                AuthorId = input.AuthorId,
                Name = input.Name,
            };
            var result = categoryRepository.Add(newCategory);

            return result ? Result<bool>.Success("دسته بندی شما با موفقیت ایجاد شد.")
                : Result<bool>.Failure("ایجاد دسته بندی با مشکل مواجه شده است.");
        }

        public void DeleteCategory(int categoryId) => categoryRepository.DeleteCategory(categoryId);

        public List<CategoryDto> GetAllCategories()
        {
            return categoryRepository.GetAllCategories();
        }

        public List<CategoryDto> GetAuthorCategory(int AuthorId)
        {
            return categoryRepository.GetAuthorCategory(AuthorId);
        }

        public CategoryDto? GetCategoryById(int id)
        {
            return categoryRepository.GetCategoryById(id);
        }

        public void UpdateCategory(int id, CategoryDto input)
        {
            categoryRepository.UpdateCategory(id, input);
        }
    }
}