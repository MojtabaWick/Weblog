using System.ComponentModel.DataAnnotations;

namespace Weblog.Presentation.RazorPages.Models
{
    public class OnlineUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Bio { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
    }
}