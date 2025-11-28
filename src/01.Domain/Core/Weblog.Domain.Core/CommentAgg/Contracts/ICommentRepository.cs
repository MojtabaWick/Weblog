using Weblog.Domain.Core.CommentAgg.Dtos;
using Weblog.Domain.Core.CommentAgg.Entities;

namespace Weblog.Domain.Core.CommentAgg.Contracts
{
    public interface ICommentRepository
    {
        public bool Create(Comment inputComment);

        public List<CommentForAdminDto> GetCommentsForAdmin(int authorId);

        public void SetApproved(int commentId);

        public void SetRejected(int commentId);

        public void DeleteComment(int commentId);
    }
}