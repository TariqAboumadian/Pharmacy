using Pharmacy.Data;
using Pharmacy.DTO.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Application.Services
{
    public interface ICategoryService
    {
        public Task<List<ShowCategory>> GetAll();
        public Task<List<ShowCategoryIndexDTO>> GetAllCategories();
        public Task<bool> CreateAsync(AddCategory category,string imgpath);
    }
}
