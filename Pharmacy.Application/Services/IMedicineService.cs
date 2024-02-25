using Pharmacy.DTO.Medicine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Application.Services
{
    public interface IMedicineService
    {
        Task<bool> CreateAsync(AddMedicineDTO addMedicineDTO,string ImgPath);
        Task<List<ShowMedicineDTO>> GetAll();
    }
}
