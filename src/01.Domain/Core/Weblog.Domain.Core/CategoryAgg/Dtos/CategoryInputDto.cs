using System.ComponentModel.DataAnnotations;
using Weblog.Domain.Core.AuthorAgg.Entities;

namespace Weblog.Domain.Core.CategoryAgg.Dtos
{
    public class CategoryInputDto
    {
        [Required]
        public string Name { get; set; }

        public int AuthorId { get; set; }
    }
}