using System.ComponentModel.DataAnnotations;
using Weblog.Domain.Core._common;
using Weblog.Domain.Core.CategoryAgg.Entities;
using Weblog.Domain.Core.PostAgg.Entities;

namespace Weblog.Domain.Core.AuthorAgg.Entities
{
    public class Author : BaseEntity
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        public string Username { get; set; }
        public string Password { get; set; }
        public string? Bio { get; set; } = string.Empty;

        public string? ImageUrl { get; set; }

        public List<Category> Categories { get; set; } = [];
        public List<Post> Posts { get; set; } = [];
    }
}