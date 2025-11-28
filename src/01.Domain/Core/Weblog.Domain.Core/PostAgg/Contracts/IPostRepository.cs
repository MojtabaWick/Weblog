using Weblog.Domain.Core.PostAgg.Dtos;
using Weblog.Domain.Core.PostAgg.Entities;

namespace Weblog.Domain.Core.PostAgg.Contracts
{
    public interface IPostRepository
    {
        public bool Add(Post post);

        public PostShowDto? GetPostById(int id);

        public List<AuthorPostDtos> GetAuthorPosts(int authorsId);

        public HomePagePostsDto GetHomePagePosts(int page, int pageSize);

        public PostShowDto? GetPostDetails(int postId);

        public void UpdatePost(int postId, PostInputDto input);
    }
}