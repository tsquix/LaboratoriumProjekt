using Laboratorium3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Laboratorium3.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        private readonly IDateTimeProvider _dateTimeProvider;

        public PostController(IDateTimeProvider timeProvider, IPostService postService)
        {
            _dateTimeProvider = timeProvider;
            _postService = postService;
        }
     
        public IActionResult Index()
        {
            return View(_postService.FindAll());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Create(Post model)
        {
            if (ModelState.IsValid)
            {
                // zapisanie modelu do bazy lub kolekcji.
                _postService.Add(model);
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(_postService.FindById(id));
        }


        [HttpPost]
        public IActionResult Update(Post model)
        {
            if (ModelState.IsValid)
            {
                // zapisanie modelu do bazy lub kolekcji
                _postService.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_postService.FindById(id));
        }

        [HttpPost]
        public IActionResult Delete(Post model)
        {
            _postService.Delete(model.Id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_postService.FindById(id));
        }
    }
}
