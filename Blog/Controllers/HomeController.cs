﻿using Blog.Data.FileManager;
using Blog.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult Index()
        {
            var posts = _repository.GetAllPosts();

            return View(posts);
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