using Microsoft.AspNetCore.Mvc;
using Pharmacy.App.Models;
using Pharmacy.Application.Services;
using System.Diagnostics;

namespace Pharmacy.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMedicineService medicineService;
        private readonly ICategoryService categoryService;
        public HomeController(ILogger<HomeController> logger,IMedicineService _medicineService, ICategoryService categoryService)
        {
            _logger = logger;
            medicineService = _medicineService;
            this.categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await categoryService.GetAllCategories());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
