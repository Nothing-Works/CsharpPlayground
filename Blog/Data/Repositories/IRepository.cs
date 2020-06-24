using Blog.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Data.Repositories
{
    public interface IRepository
    {
        public Post GetPost(int id);
        public List<Post> GetAllPosts();
        public List<Post> GetAllPosts(string category);
        public void AddPost(Post post);
        public void UpdatePost(Post post);
        public void RemovePost(int id);
        public void AddSbuComment(SubComment c);
        public Task<bool> SaveChangesAsync();
    }
}