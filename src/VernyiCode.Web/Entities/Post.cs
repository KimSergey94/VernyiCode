namespace VernyiCode.Web.Entities
{
    public class Post
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Message { get; set; }
    }
}
