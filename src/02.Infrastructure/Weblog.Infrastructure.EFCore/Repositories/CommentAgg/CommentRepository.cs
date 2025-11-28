using Microsoft.EntityFrameworkCore;
using Weblog.Domain.Core.CommentAgg.Contracts;
using Weblog.Domain.Core.CommentAgg.Dtos;
using Weblog.Domain.Core.CommentAgg.Entities;
using Weblog.Infrastructure.EFCore.Persistence;

namespace Weblog.Infrastructure.EFCore.Repositories.CommentAgg
{
    public class CommentRepository(AppDbContext dbContext) : ICommentRepository
    {
        public bool Create(Comment inputComment)
        {
            dbContext.Comments.Add(inputComment);
            return dbContext.SaveChanges() > 0;
        }

        public List<CommentForAdminDto> GetCommentsForAdmin(int authorId)
        {
            return dbContext.Comments
                .Include(c => c.Post)
                .Where(c => c.Post.AuthorId == authorId)
                .Select(c => new CommentForAdminDto()
                {
                    Id = c.Id,
                    PostTitle = c.Post.Title,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Email = c.Email,
                    Text = c.Text,
                    Score = c.Score,
                    IsApproved = c.IsApproved,
                }).ToList();
        }

        public void SetApproved(int commentId)
        {
            dbContext.Comments
                .Where(c => c.Id == commentId)
                .ExecuteUpdate(setter => setter
                    .SetProperty(c => c.IsApproved, true)
                );
        }

        public void SetRejected(int commentId)
        {
            dbContext.Comments
                .Where(c => c.Id == commentId)
                .ExecuteUpdate(setter => setter
                    .SetProperty(c => c.IsApproved, false)
                );
        }

        public void DeleteComment(int commentId)
        {
            dbContext.Comments
                .Where(c => c.Id == commentId)
                .ExecuteUpdate(setter => setter
                    .SetProperty(c => c.IsDeleted, true)
                );
        }
    }
}