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
        private readonly string ImgPath;
        public MedicineController(IWebHostEnvironment _environment,IMedicineService _medicineService)
        {
            this.environment = _environment;
            medicineService = _medicineService;
            ImgPath=$"{environment.WebRootPath}/assets/Images/Medicine";
        }

        public IActionResult Index()
        {
            return View();
        }
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
                }
            }
            return View();
        }
    }
}
