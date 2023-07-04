using VernyiCode.Web.Entities;
using VernyiCode.Web.Repositories;

namespace VernyiCode.Web.Services
{
    public static class UserPostService
    {
        /// <summary>
        /// Gets collection of latest N amount posts by the provided user ID
        /// </summary>
        /// <param name="userId">user ID whose posts to get</param>
        /// <param name="n">number of latest posts to get</param>
        /// <returns>List of latest N amount posts by the provided user ID</returns>
        public static List<Post> TakeNLatestPostsByUserId(int userId, int n = 10)
        {
            var posts = PostRepository.Instance.List().Where(post => post.UserID == userId)
                .OrderByDescending(post => post.PublishedDate).Take(n).ToList();
            return posts;
        }

        /// <summary>
        /// Gets collection of latest N amount posts by the provided user ID
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static List<Post> TakeNUsersNLatestPosts(int n)
        {
            var users = UserRepository.Instance.List().ToList();
            var posts = PostRepository.Instance.List().OrderBy(post => post.UserID);

            var nUsersIds = posts.Select(post => post.UserID).Distinct().Take(n).ToList();
            var nUsersNPostsList = users.Take(n).SelectMany(user => posts.Where(post => nUsersIds.Contains(post.UserID))
            .OrderByDescending(post => post.PublishedDate).Select(userPosts => new { User = user, Posts = posts.Take(n) })).ToList();

            var result = new List<Post>();
            foreach (var nUsersNPosts in nUsersNPostsList)
                result.AddRange(nUsersNPosts.Posts);
            return result;
        }
    }
}
