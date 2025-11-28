using Weblog.Domain.Core.AuthorAgg.Contracts;
using Weblog.Domain.Core.AuthorAgg.Entities;
using Weblog.Infrastructure.EFCore.Persistence;

namespace Weblog.Infrastructure.EFCore.Repositories.AuthorAgg
{
    public class AuthorRepository(AppDbContext dbContext) : IAuthorRepository
    {
        public bool UserNameExist(string username)
        {
            return dbContext.Authors.Any(a => a.Username == username);
        }

        public bool RegisterAuthor(Author input)
        {
            dbContext.Authors.Add(input);
            return dbContext.SaveChanges() > 0;
        }

        public Author? Login(string username, string password)
        {
            return dbContext.Authors.FirstOrDefault(a => a.Username == username && a.Password == password);
        }
    }
}