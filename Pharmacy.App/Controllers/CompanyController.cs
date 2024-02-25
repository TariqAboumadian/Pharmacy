using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Pharmacy.Application.Services;
using Pharmacy.DTO.Company;

namespace Pharmacy.App.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyService companyService;

        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await companyService.GetAllCompanies());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCompanyDTO createCompanyDTO)
        {
            if (ModelState.IsValid)
            {
                var res = await companyService.Create(createCompanyDTO);
                if (res)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Error", "Cannot Add Company");
                }
            }
            return View(createCompanyDTO);
        }
    }
}
