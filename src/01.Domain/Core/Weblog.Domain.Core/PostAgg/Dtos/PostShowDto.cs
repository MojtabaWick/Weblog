using Weblog.Domain.Core.CommentAgg.Dtos;

namespace Weblog.Domain.Core.PostAgg.Dtos
{
    public class PostShowDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string? ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string AuthorName { get; set; }
        public DateTime PublishedAt { get; set; }
        public List<CommentShowDto> Comments { get; set; } = [];
    }
}