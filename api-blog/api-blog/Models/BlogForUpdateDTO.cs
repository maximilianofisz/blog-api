namespace api_blog.Models
{
    public class BlogForUpdateDTO
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public int? DeletedBy { get; set; }
    }
}
