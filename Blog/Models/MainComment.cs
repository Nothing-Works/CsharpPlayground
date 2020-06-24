using System.Collections.Generic;

namespace Blog.Models
{
    public class MainComment : Comment
    {
        public List<SubComment> SubComments { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}