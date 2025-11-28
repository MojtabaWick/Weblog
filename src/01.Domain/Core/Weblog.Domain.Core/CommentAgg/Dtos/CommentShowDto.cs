namespace Weblog.Domain.Core.CommentAgg.Dtos
{
    public class CommentShowDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Text { get; set; }
        public int Score { get; set; }
    }
}