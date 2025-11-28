using Microsoft.EntityFrameworkCore;
using System;
using Weblog.Domain.Core.CategoryAgg.Contracts;
using Weblog.Domain.Core.CategoryAgg.Dtos;
using Weblog.Domain.Core.CategoryAgg.Entities;
using Weblog.Infrastructure.EFCore.Persistence;

namespace Weblog.Infrastructure.EFCore.Repositories.CategoryAgg
{
    public class CategoryRepository(AppDbContext dbContext) : ICategoryRepository
    {
        public bool Add(Category newCategory)
        {
            dbContext.Categories.Add(newCategory);
            return dbContext.SaveChanges() > 0;
        }

        public List<CategoryDto> GetAuthorCategory(int AuthorId)
        {
            return dbContext.Categories
                .Where(c => c.AuthorId == AuthorId)
                .Include(c => c.Author)
                .OrderByDescending(c => c.CreatedAt)
                .Select(c => new CategoryDto()
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToList();
        }

        public List<CategoryDto> GetAllCategories()
        {
            return dbContext.Categories.Select(c => new CategoryDto()
            {
                Id = c.Id,
                Name = c.Name,
            }).ToList();
        }

        public CategoryDto? GetCategoryById(int id)
        {
            return dbContext.Categories.Where(c => c.Id == id)
                .Select(c => new CategoryDto()
                {
                    Id = c.Id,
                    Name = c.Name,
                }).FirstOrDefault();
        }

        public void UpdateCategory(int id, CategoryDto input)
        {
            dbContext.Categories
                .Where(c => c.Id == id)
                .ExecuteUpdate(s => s
                    .SetProperty(c => c.Name, input.Name)
                );
        }

        public void DeleteCategory(int categoryId)
        {
            dbContext.Categories
                           .Where(c => c.Id == categoryId)
                           .ExecuteUpdate(setter => setter
                               .SetProperty(c => c.IsDeleted, true)
                           );
        }
    }
}