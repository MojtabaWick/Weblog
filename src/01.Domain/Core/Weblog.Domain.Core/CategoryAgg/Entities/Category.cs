using System.ComponentModel.DataAnnotations;
using Weblog.Domain.Core._common;
using Weblog.Domain.Core.AuthorAgg.Entities;
using Weblog.Domain.Core.PostAgg.Entities;

namespace Weblog.Domain.Core.CategoryAgg.Entities
{
    public class Category : BaseEntity
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        public Author Author { get; set; }

        public int AuthorId { get; set; }

        public List<Post> Posts { get; set; } = [];
    }
}