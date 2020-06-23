﻿using Blog.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository _repository;

        public HomeController(IRepository repository)
        {
            _repository = repository;
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
    }
}