using Blog.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Data.Repositories
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public Post GetPost(int id)
        {
            return _context.Posts.SingleOrDefault(c => c.Id == id);
        }

        public List<Post> GetAllPosts()
        {
            return _context.Posts.ToList();
        }

        public List<Post> GetAllPosts(string category)
        {
            return _context.Posts.Where(c => c.Category == category).ToList();
        }

        public void AddPost(Post post)
        {
            _context.Posts.Add(post);
        }

        public void UpdatePost(Post post)
        {
            _context.Posts.Update(post);
        }

        public void RemovePost(int id)
        {
            _context.Posts.Remove(GetPost(id));
        }

        public async Task<bool> SaveChangesAsync()
        {
            var result = await _context.SaveChangesAsync();

            return result > 0;
        }
    }
}