using Weblog.Domain.Core._common;
using Weblog.Domain.Core.CommentAgg.Contracts;
using Weblog.Domain.Core.CommentAgg.Dtos;
using Weblog.Domain.Core.CommentAgg.Entities;

namespace Weblog.Domain.Service.Services.CommentsAgg
{
    public class CommentService(ICommentRepository commentRepository) : ICommentService
    {
        public Result<bool> CreateComment(CommentInputDto input)
        {
            var comment = new Comment()
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                Email = input.Email,
                PostId = input.PostId,
                Text = input.Text,
                Score = input.Score,
            };
            var result = commentRepository.Create(comment);

            return result ? Result<bool>.Success("نظر شما با موفقیت ایجاد شد.")
                : Result<bool>.Failure("ایجاد نظر شما با مشکل مواجه شده است.");
        }

        public List<CommentForAdminDto> GetCommentsForAdmin(int authorId)
        {
            return commentRepository.GetCommentsForAdmin(authorId);
        }

        public void SetApproved(int commentId) => commentRepository.SetApproved(commentId);

        public void SetRejected(int commentId) => commentRepository.SetRejected(commentId);

        public void DeleteComment(int commentId) => commentRepository.DeleteComment(commentId);
    }
}