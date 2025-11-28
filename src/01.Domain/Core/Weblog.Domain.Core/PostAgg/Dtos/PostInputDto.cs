using Microsoft.AspNetCore.Http;
using Weblog.Domain.Core.AuthorAgg.Entities;
using Weblog.Domain.Core.CategoryAgg.Entities;

namespace Weblog.Domain.Core.PostAgg.Dtos
{
    public class PostInputDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public IFormFile? ImageFile { get; set; }
        public string? ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
    }
}