using VernyiCode.Web.Entities;

namespace VernyiCode.Web.Repositories
{
    public class PostRepository
    {
        private PostRepository()
        {
        }

        private static readonly PostRepository _instance = new PostRepository();

        private readonly IList<Post> _list = new List<Post>()
        {
            new Post() { ID = 1, Message = "Post1", PublishedDate = DateTime.Now, UserID = 1 },
            new Post() { ID = 2, Message = "Post2", PublishedDate = DateTime.Now.AddDays(-1), UserID = 2 },
            new Post() { ID = 3, Message = "Post3", PublishedDate = DateTime.Now.AddDays(-2), UserID = 1 },
            new Post() { ID = 4, Message = "Post4", PublishedDate = DateTime.Now.AddDays(-3), UserID = 2 },
            new Post() { ID = 5, Message = "Post5", PublishedDate = DateTime.Now.AddDays(-4), UserID = 3 }
        };

        public static PostRepository Instance => _instance;

        public IList<Post> List()
        {
            return _list;
        }

        public bool Create(Post post)
        {
            if (post == null) throw new ArgumentNullException(nameof(post));
            if (string.IsNullOrWhiteSpace(post.Message) || post.UserID < 1) return false;

            post.ID = _list.Any() ? _list.Max(x => x.ID) + 1 : 1;
            _list.Add(post);
            return true;
        }

        public void Delete(int id)
        {
            var post = _list.FirstOrDefault(x => x.ID == id);
            if (post == null) throw new Exception("Post doesn't exist!");
            _list.Remove(post);
        }

        public bool Update(Post post)
        {
            if (post == null)
                throw new ArgumentNullException(nameof(post));

            var storedPost = _list.FirstOrDefault(n => n.ID == post.ID);
            if (storedPost == null) return false;

            storedPost.User = post.User;
            storedPost.UserID = post.UserID;
            storedPost.Message = post.Message;
            storedPost.PublishedDate = post.PublishedDate;
            return true;
        }
    }
}
