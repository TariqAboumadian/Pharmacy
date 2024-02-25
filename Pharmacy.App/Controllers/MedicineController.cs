using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Application.Services;
using Pharmacy.DTO.Medicine;
using System.Security.AccessControl;
namespace Pharmacy.App.Controllers
{
    public class MedicineController : Controller
    {
        private readonly IWebHostEnvironment environment;
        private readonly IMedicineService medicineService;
        private readonly ICompanyService companyService;
        private readonly ICategoryService categoryService;
        private readonly string ImgPath;
        public MedicineController(IWebHostEnvironment _environment,IMedicineService _medicineService,
            ICompanyService _companyService, ICategoryService _categoryService)
        {
            this.environment = _environment;
            medicineService = _medicineService;
            companyService = _companyService;
            categoryService= _categoryService;
            ImgPath=$"{environment.WebRootPath}{FileSetings.imagespath}";
        }

        public async Task<IActionResult> Index()
        {
            return View(await medicineService.GetAll());
        }
        public async Task<IActionResult> Create()
        {
            AddMedicineDTO addMedicineDTO = new AddMedicineDTO()
            {
                companies = await companyService.GetAll(),
                categories = await categoryService.GetAll()
            };
            return View(addMedicineDTO);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddMedicineDTO medicineDTO)
        {
            if (ModelState.IsValid)
            {
               var res=await medicineService.CreateAsync(medicineDTO, ImgPath);
                if (res)
                {
                    return RedirectToAction("Index","Home");
                }
                else {
                    ModelState.AddModelError("Err", "Error On Adding Medicine");
                    medicineDTO.companies = await companyService.GetAll();
                    medicineDTO.categories = await categoryService.GetAll();
                }
            }
            return View(medicineDTO);
        }
    }
}
