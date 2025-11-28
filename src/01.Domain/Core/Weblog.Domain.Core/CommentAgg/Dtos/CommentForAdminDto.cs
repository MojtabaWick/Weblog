namespace Weblog.Domain.Core.CommentAgg.Dtos
{
    public class CommentForAdminDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Text { get; set; }
        public string PostTitle { get; set; }
        public int Score { get; set; }
        public bool IsApproved { get; set; }
    }
}