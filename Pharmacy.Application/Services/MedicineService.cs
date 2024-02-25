using AutoMapper;
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
        private readonly IMapper _map;
        public MedicineService(IMedicineRepository medicineRepository,IMapper mapper,IMedicineExpDateRepository medicineExpDateService)
        {
            _medicineRepository = medicineRepository;
            _medicineExpDateService = medicineExpDateService;
            _map=mapper;
        }
        public async Task<bool> CreateAsync(AddMedicineDTO addMedicineDTO, string ImgPath)
        {
            Medicine medicine = _map.Map<Medicine>(addMedicineDTO);
            medicine.Image = await SaveCover(addMedicineDTO.Image, ImgPath);
            var res = await _medicineRepository.CreateAsync(medicine);
            var ok1 = await _medicineRepository.SaveChangesAsync();
            if (res is not null)
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
                    var  ok2 = await _medicineExpDateService.SaveChangesAsync();
                    return (ok1 != 0 && ok2!= 0) ? true : false;
                }
            }
            return false;
        }

        public async Task<List<ShowMedicineDTO>> GetAll()
        {
            var medicines = _map.Map<List<ShowMedicineDTO>>(await _medicineRepository.GetAllAsync());
            return medicines;
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
