using Weblog.Domain.Core._common;
using Weblog.Domain.Core.PostAgg.Contracts;
using Weblog.Domain.Core.PostAgg.Dtos;
using Weblog.Domain.Core.PostAgg.Entities;

namespace Weblog.Domain.Service.Services.PostAgg
{
    public class PostService(IPostRepository postRepository) : IPostService
    {
        public PostShowDto? GetPostById(int id)
        {
            return postRepository.GetPostById(id);
        }

        public Result<bool> Add(PostInputDto postDto)
        {
            var newPost = new Post()
            {
                AuthorId = postDto.AuthorId,
                CategoryId = postDto.CategoryId,
                Content = postDto.Content,
                Title = postDto.Title,
                ImageUrl = postDto.ImageUrl,
            };
            var result = postRepository.Add(newPost);

            return result ? Result<bool>.Success("پست شما با موفقیت ایجاد شد.")
                : Result<bool>.Failure("ایجاد پست با مشکل مواجه شده است.");
        }

        public List<AuthorPostDtos> GetAuthorPosts(int authorsId)
        {
            return postRepository.GetAuthorPosts(authorsId);
        }

        public HomePagePostsDto GetHomePagePosts(int page, int pageSize, int? categoryId)
        {
            return postRepository.GetHomePagePosts(page, pageSize, categoryId);
        }

        public PostShowDto? GetPostDetails(int postId)
        {
            return postRepository.GetPostDetails(postId);
        }

        public void UpdatePost(int postId, PostInputDto input)
        {
            postRepository.UpdatePost(postId, input);
        }

        public void DeletePost(int postId)
        {
            postRepository.DeletePost(postId);
        }
    }
}