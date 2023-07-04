using VernyiCode.Web.Entities;

namespace VernyiCode.Web.Extensions
{
    public static class PostsExtension
    {
        public static string ToJSON(this IList<Post> posts)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(posts);
        }
    }
}
