using Microsoft.AspNetCore.Mvc;
using Pharmacy.Application.Services;
using Pharmacy.DTO.Category;
using System;

namespace Pharmacy.App.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryservice;
        private readonly IWebHostEnvironment webHost;
        private readonly string imgpath;
        public CategoryController(ICategoryService categoryservice, IWebHostEnvironment webHost)
        {
            _categoryservice = categoryservice;
            this.webHost = webHost;
            this.imgpath = $"{webHost.WebRootPath}{FileSetings.imagespath}";
        }

        public async Task<IActionResult> Index()
        {
            return View(await _categoryservice.GetAllCategories());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddCategory addCategory)
        {
            if (ModelState.IsValid)
            {
                var res =await _categoryservice.CreateAsync(addCategory, imgpath);
                if (res)
                {
                    return RedirectToAction("Index", "Category");
                }
                else
                {
                    ModelState.AddModelError("Error", "Cannot Add Category");
                }
            }
            return View(addCategory);
        }
    }
}
