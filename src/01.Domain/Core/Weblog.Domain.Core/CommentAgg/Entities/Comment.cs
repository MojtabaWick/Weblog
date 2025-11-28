using System.ComponentModel.DataAnnotations;
using Weblog.Domain.Core._common;
using Weblog.Domain.Core.PostAgg.Entities;

namespace Weblog.Domain.Core.CommentAgg.Entities
{
    public class Comment : BaseEntity
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Text { get; set; }

        public int Score { get; set; }
        public bool IsApproved { get; set; }

        public Post Post { get; set; }
        public int PostId { get; set; }
    }
}