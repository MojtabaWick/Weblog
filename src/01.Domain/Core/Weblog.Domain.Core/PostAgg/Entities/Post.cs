using System.ComponentModel;
using Microsoft.AspNetCore.Http;
using Weblog.Domain.Core._common;
using Weblog.Domain.Core.AuthorAgg.Entities;
using Weblog.Domain.Core.CategoryAgg.Entities;
using Weblog.Domain.Core.CommentAgg.Entities;

namespace Weblog.Domain.Core.PostAgg.Entities
{
    public class Post : BaseEntity
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string? ImageUrl { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }

        public Author Author { get; set; }
        public int AuthorId { get; set; }

        public List<Comment> Comments { get; set; } = [];
    }
}