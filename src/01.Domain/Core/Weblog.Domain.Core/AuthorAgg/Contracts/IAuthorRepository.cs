using Weblog.Domain.Core.AuthorAgg.Entities;

namespace Weblog.Domain.Core.AuthorAgg.Contracts
{
    public interface IAuthorRepository
    {
        public bool UserNameExist(string username);

        public bool RegisterAuthor(Author input);

        public Author? Login(string username, string password);
    }
}