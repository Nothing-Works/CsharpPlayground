using Blog.Data.FileManager;
using Blog.Data.Repositories;
using Blog.Models;
using Blog.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository _repository;
        private readonly IFileManager _fileManager;

        public HomeController(IRepository repository, IFileManager fileManager)
        {
            _repository = repository;
            _fileManager = fileManager;
        }

        public IActionResult Index(string category)
        {
            var posts = category is null ? _repository.GetAllPosts() : _repository.GetAllPosts(category);

            return View(posts);
        }

        [HttpPost]
        public async Task<IActionResult> Comment(CommentViewModel vm)
        {
            var post = _repository.GetPost(vm.PostId);

            if (vm.MainCommentId == 0)
            {
                post.MainComments ??= new List<MainComment>();
                post.MainComments.Add(new MainComment { Message = vm.Message });

                _repository.UpdatePost(post);
            }
            else
            {
                _repository.AddSbuComment(new SubComment
                {
                    MainCommentId = vm.MainCommentId,
                    Message = vm.Message
                });
            }

            await _repository.SaveChangesAsync();

            return RedirectToAction("Post", new { id = vm.PostId });
        }

        public IActionResult Post(int id)
        {
            var post = _repository.GetPost(id);

            return View(post);
        }

        [Route("/Image/{image}")]
        public IActionResult Image(string image)
        {
            var mime = image.Substring(image.LastIndexOf('.') + 1);

            return new FileStreamResult(_fileManager.ImageStream(image), $"image/{mime}");
        }
    }
}