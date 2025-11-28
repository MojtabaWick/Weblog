using Weblog.Domain.Core._common;
using Weblog.Domain.Core.AuthorAgg.Contracts;
using Weblog.Domain.Core.AuthorAgg.Dtos;
using Weblog.Domain.Core.AuthorAgg.Entities;

namespace Weblog.Domain.Service.Services.AuthorAgg
{
    public class AuthorService(IAuthorRepository authorRepository) : IAuthorService
    {
        public Result<bool> Register(AuthorRegisterDto dto)
        {
            var existing = authorRepository.UserNameExist(dto.Username);
            if (existing)
            {
                return Result<bool>.Failure("نام کاربری وارد شده قبلا ثبت شده است.");
            }

            var author = new Author
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Username = dto.Username,
                Password = dto.Password,
                Bio = dto.Bio,
                ImageUrl = dto.ImageUrl
            };

            var result = authorRepository.RegisterAuthor(author);

            return result ? Result<bool>.Success("کاربر با موفقیت ثبت نام شد.")
                : Result<bool>.Failure("ایجاد کاربر با مشکل مواجه شده است.");
        }

        public Result<Author> Login(AuthorLoginInput input)
        {
            var result = authorRepository.Login(input.Username, input.Password);
            if (result is null)
            {
                return Result<Author>.Failure("نام کاربری یا رمز عبور اشتباه است.");
            }
            else
            {
                return Result<Author>.Success("کاربر با موفقیت ثبت نام شد.", result);
            }
        }
    }
}