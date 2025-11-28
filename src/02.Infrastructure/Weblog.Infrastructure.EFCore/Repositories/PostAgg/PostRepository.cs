using Microsoft.EntityFrameworkCore;
using Weblog.Domain.Core.CommentAgg.Dtos;
using Weblog.Domain.Core.PostAgg.Contracts;
using Weblog.Domain.Core.PostAgg.Dtos;
using Weblog.Domain.Core.PostAgg.Entities;
using Weblog.Infrastructure.EFCore.Persistence;

namespace Weblog.Infrastructure.EFCore.Repositories.PostAgg
{
    public class PostRepository(AppDbContext dbContext) : IPostRepository
    {
        public bool Add(Post post)
        {
            dbContext.Posts.Add(post);

            return dbContext.SaveChanges() > 0;
        }

        public PostShowDto? GetPostById(int id)
        {
            return dbContext.Posts
                .Where(p => p.Id == id)
                .Select(p => new PostShowDto()
                {
                    Id = p.Id,
                    AuthorName = p.Author.FirstName + " " + p.Author.LastName,
                    CategoryName = p.Category.Name,
                    CategoryId = p.CategoryId,
                    Content = p.Content,
                    Title = p.Title,
                    ImageUrl = p.ImageUrl,
                    PublishedAt = p.CreatedAt,
                })
                .FirstOrDefault();
        }

        public List<AuthorPostDtos> GetAuthorPosts(int authorsId)
        {
            return dbContext.Posts
                .Where(p => p.AuthorId == authorsId)
                .OrderByDescending(p => p.Id)
                .Select(p => new AuthorPostDtos
                {
                    Id = p.Id,
                    Title = p.Title,
                    AuthorName = p.Author.FirstName + " " + p.Author.LastName,
                    CategoryName = p.Category.Name,
                    Content = p.Content,
                    ImageUrl = p.ImageUrl,
                    PublishedAt = p.CreatedAt,
                    Comments = p.Comments
                        .Select(c => new CommentForAdminDto
                        {
                            Id = c.Id,
                            PostTitle = p.Title,
                            FirstName = c.FirstName,
                            LastName = c.LastName,
                            Email = c.Email,
                            Text = c.Text,
                            Score = c.Score,
                            IsApproved = c.IsApproved
                        }).ToList()
                }).ToList();
        }

        public HomePagePostsDto GetHomePagePosts(int page, int pageSize)
        {
            var query = dbContext.Posts
                .OrderByDescending(p => p.CreatedAt)
                .ThenByDescending(p => p.Id)
                .Select(p => new PostShowDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content,
                    ImageUrl = p.ImageUrl,
                    AuthorName = p.Author.FirstName + " " + p.Author.LastName,
                    CategoryName = p.Category.Name,
                    CategoryId = p.CategoryId,
                    PublishedAt = p.CreatedAt,
                });

            int totalPosts = query.Count();
            int totalPages = (int)Math.Ceiling(totalPosts / (double)pageSize);
            if (totalPages == 0) totalPages = 1;

            if (page < 1) page = 1;
            if (page > totalPages) page = totalPages;

            int skip = (page - 1) * pageSize;

            var posts = query
                .Skip(skip)
                .Take(pageSize)
                .ToList();

            return new HomePagePostsDto()
            {
                Posts = posts,
                CurrentPage = page,
                TotalPages = totalPages
            };
        }

        public PostShowDto? GetPostDetails(int postId)
        {
            return dbContext.Posts
                .Where(p => p.Id == postId)
                .Select(p => new PostShowDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content,
                    ImageUrl = p.ImageUrl,
                    AuthorName = p.Author.FirstName + " " + p.Author.LastName,
                    CategoryName = p.Category.Name,
                    CategoryId = p.CategoryId,
                    Comments = p.Comments
                        .Where(c => c.IsApproved)
                        .Select(c => new CommentShowDto
                        {
                            Id = c.Id,
                            FirstName = c.FirstName,
                            LastName = c.LastName,
                            Text = c.Text,
                            Score = c.Score
                        }).ToList()
                }).FirstOrDefault();
        }

        public void UpdatePost(int postId, PostInputDto input)
        {
            dbContext.Posts
               .Where(p => p.Id == postId)
               .ExecuteUpdate(setters => setters
                       .SetProperty(p => p.Title, input.Title)
                       .SetProperty(p => p.Content, input.Content)
                       .SetProperty(p => p.ImageUrl, input.ImageUrl)
                       .SetProperty(p => p.CategoryId, input.CategoryId)
                       .SetProperty(p => p.AuthorId, input.AuthorId)
               );
        }

        public void DeletePost(int postId)
        {
            dbContext.Posts
                .Where(p => p.Id == postId)
                .ExecuteUpdate(setters => setters
                    .SetProperty(p => p.IsDeleted, true)
                );
        }
    }
}