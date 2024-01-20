using Data.Entities;
using Laboratorium3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
        public ActionResult Create()
        {
            var model = new Post();
            InitializeOrganizationsList(model);
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(Post model)
        {
            if (ModelState.IsValid)
            {
                _postService.Add(model);
                return RedirectToAction("Index");
            }

            // Jeśli ModelState nie jest poprawny, ponownie inicjuj listę organizacji
            InitializeOrganizationsList(model);
            return View(model);
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
                _postService.Update(model);
                return RedirectToAction("Index");
            }

            // Jeśli ModelState nie jest poprawny, ponownie inicjuj listę organizacji
            InitializeOrganizationsList(model);
            return View(model);
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

        // Prywatna metoda do inicjowania listy organizacji
        private void InitializeOrganizationsList(Post model)
        {
            model.Organizations = _postService
                .FindAllOrganizations()
                .Select(o => new SelectListItem() { Value = o.Id.ToString(), Text = o.Title })
                .ToList();
        }
    }
}
