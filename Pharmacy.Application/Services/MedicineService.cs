using Microsoft.AspNetCore.Http;
using Pharmacy.Application.Contracts;
using Pharmacy.Data;
using Pharmacy.DTO.Medicine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Application.Services
{
    public class MedicineService : IMedicineService
    {
        private readonly IMedicineRepository _medicineRepository;
        private readonly IMedicineExpDateRepository _medicineExpDateService;
        public MedicineService(IMedicineRepository medicineRepository, IMedicineExpDateRepository medicineExpDateService)
        {
            _medicineRepository = medicineRepository;
            _medicineExpDateService = medicineExpDateService;
        }
        public async Task<bool> CreateAsync(AddMedicineDTO addMedicineDTO, string ImgPath)
        {
            Medicine medicine = new Medicine();
            medicine.Name=addMedicineDTO.Name;
            medicine.Description = addMedicineDTO.Description;
            medicine.Price=addMedicineDTO.Price;
            medicine.CompanyId=addMedicineDTO.CompanyId;
            medicine.CategoryId=addMedicineDTO.CategoryId;
            medicine.Image = await SaveCover(addMedicineDTO.Image, ImgPath);
            var res = await _medicineRepository.CreateAsync(medicine);
            if(res is not null)
            {
                MedicineExpDate medicineExpDate = new MedicineExpDate()
                {
                    Quantity = addMedicineDTO.Quantity,
                    ExpireDate = addMedicineDTO.ExpireDate,
                    MedicineId = res.Id,
                };
                var dateres = await _medicineExpDateService.CreateAsync(medicineExpDate);
                if(dateres is not null)
                {
                    var ok1 = await _medicineRepository.SaveChangesAsync();
                    var  ok2 = await _medicineExpDateService.SaveChangesAsync();
                    return (ok1 != 0 && ok2!= 0) ? true : false;
                }
            }
            return false;
        }

        private async Task<string> SaveCover(IFormFile Cover,string imagesPath)
        {
            var coverName = $"{Guid.NewGuid()}{Path.GetExtension(Cover.FileName)}";
            var path = Path.Combine(imagesPath, coverName);
            using var stream = File.Create(path);
            await Cover.CopyToAsync(stream);
            return coverName;
        }
    }
}
