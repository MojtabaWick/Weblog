using Weblog.Domain.Core._common;
using Weblog.Domain.Core.AuthorAgg.Dtos;
using Weblog.Domain.Core.AuthorAgg.Entities;

namespace Weblog.Domain.Core.AuthorAgg.Contracts
{
    public interface IAuthorService
    {
        public Result<bool> Register(AuthorRegisterDto dto);

        public Result<Author> Login(AuthorLoginInput input);
    }
}