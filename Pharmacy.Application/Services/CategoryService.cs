using AutoMapper;
using Microsoft.AspNetCore.Http;
using Pharmacy.Application.Contracts;
using Pharmacy.Data;
using Pharmacy.DTO.Category;
using Pharmacy.DTO.Medicine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository CategoryRepository;
        private readonly IMapper _map;
        public CategoryService(ICategoryRepository _categoryRepository,IMapper mapper)
        {
            CategoryRepository = _categoryRepository;
            _map = mapper;
        }

        public async Task<bool> CreateAsync(AddCategory category, string imgpath)
        {
            var Cat = _map.Map<Category>(category);
            Cat.Image=await SaveCover(category.Image, imgpath);
            var res=await CategoryRepository.CreateAsync(Cat);
            if(res is not null)
            {
              var ok= await CategoryRepository.SaveChangesAsync();
                if(ok != 0) { return true; }
            }
            return false;
        }

        public async Task<List<ShowCategory>> GetAll()
        {
            var categorirs = await CategoryRepository.GetAllAsync();
            var res = categorirs.Select(c => new ShowCategory() { Id = c.Id, Name = c.Name }).
                ToList();
            return res;
        }

        public async Task<List<ShowCategoryIndexDTO>> GetAllCategories()
        {
            var categories = _map.Map<List<ShowCategoryIndexDTO>>(await CategoryRepository.GetAllAsync());
            return categories;
        }

        private async Task<string> SaveCover(IFormFile Cover, string imagesPath)
        {
            var coverName = $"{Guid.NewGuid()}{Path.GetExtension(Cover.FileName)}";
            var path = Path.Combine(imagesPath, coverName);
            using var stream = File.Create(path);
            await Cover.CopyToAsync(stream);
            return coverName;
        }
    }
}
