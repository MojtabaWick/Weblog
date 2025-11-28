using Weblog.Domain.Core._common;
using Weblog.Domain.Core.PostAgg.Dtos;

namespace Weblog.Domain.Core.PostAgg.Contracts
{
    public interface IPostService
    {
        public PostShowDto? GetPostById(int id);

        public Result<bool> Add(PostInputDto postDto);

        public List<AuthorPostDtos> GetAuthorPosts(int authorsId);

        public HomePagePostsDto GetHomePagePosts(int page, int pageSize);

        public PostShowDto? GetPostDetails(int postId);

        public void UpdatePost(int postId, PostInputDto input);
    }
}