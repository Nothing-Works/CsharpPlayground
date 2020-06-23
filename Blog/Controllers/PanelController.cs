using Blog.Data.FileManager;
using Blog.Data.Repositories;
using Blog.Models;
using Blog.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PanelController : Controller
    {
        private readonly IRepository _repository;
        private readonly IFileManager _fileManager;

        public PanelController(IRepository repository, IFileManager fileManager)
        {
            _repository = repository;
            _fileManager = fileManager;
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


            return View(new PostViewModel
            {
                Id = post.Id,
                Title = post.Title,
                Body = post.Body
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PostViewModel vm)
        {
            var fileName = await _fileManager.SaveImage(vm.Image);

            var post = new Post
            {
                Id = vm.Id,
                Title = vm.Title,
                Body = vm.Body,
                Image = fileName
            };


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