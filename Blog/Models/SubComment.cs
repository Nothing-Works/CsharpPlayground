namespace Blog.Models
{
    public class SubComment : Comment
    {
        public int MainCommentId { get; set; }
        public MainComment MainComment { get; set; }
    }
}