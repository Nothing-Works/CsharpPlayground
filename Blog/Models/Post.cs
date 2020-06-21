using System;

namespace Blog.Models
{
    public class Post
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}