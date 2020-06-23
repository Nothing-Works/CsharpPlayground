using Blog.Data.Repositories;
using Blog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PanelController : Controller
    {
        private readonly IRepository _repository;

        public PanelController(IRepository repository)
        {
            _repository = repository;
        }


        public IActionResult Index()
        {
            var posts = _repository.GetAllPosts();

            return View(posts);
        }


        public IActionResult Edit(int? id)
        {
            if (id is null)
            {
                return View();
            }

            var post = _repository.GetPost((int) id);

            return View(post);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Post post)
        {
            if (post.Id == 0)
            {
                _repository.AddPost(post);
            }
            else
            {
                _repository.UpdatePost(post);
            }


            await _repository.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int id)
        {
            _repository.RemovePost(id);

            await _repository.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}