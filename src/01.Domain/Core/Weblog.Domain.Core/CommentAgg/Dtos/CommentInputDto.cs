namespace Weblog.Domain.Core.CommentAgg.Dtos
{
    public class CommentInputDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Text { get; set; }
        public int Score { get; set; }
        public int PostId { get; set; }
    }
}