namespace Blog.ViewModels
{
    public class CommentViewModel
    {
        public int PostId { get; set; }
        public int MainCommentId { get; set; }
        public string Message { get; set; }
    }
}