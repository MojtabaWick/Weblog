using System;
using System.Collections.Generic;
using System.Text;
using Weblog.Domain.Core._common;
using Weblog.Domain.Core.CommentAgg.Dtos;

namespace Weblog.Domain.Core.CommentAgg.Contracts
{
    public interface ICommentService
    {
        public Result<bool> CreateComment(CommentInputDto input);

        public List<CommentForAdminDto> GetCommentsForAdmin(int authorId);

        public void SetApproved(int commentId);

        public void SetRejected(int commentId);

        public void DeleteComment(int commentId);
    }
}