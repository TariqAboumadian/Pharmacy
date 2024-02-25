using AutoMapper;
using Pharmacy.Data;
using Pharmacy.DTO.Category;
using Pharmacy.DTO.Company;
using Pharmacy.DTO.Medicine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Application.Mapper
{
    public class MyMapp: Profile
    {
        public MyMapp() 
        {
            CreateMap<Category, AddCategory>().ReverseMap();
            CreateMap<Category, ShowCategory>().ReverseMap();
            CreateMap<Company,ShowCompany>().ReverseMap();
            CreateMap<Medicine,AddMedicineDTO>().ReverseMap();
            CreateMap<Category,ShowCategoryIndexDTO>().ReverseMap();
            CreateMap<Company,CreateCompanyDTO>().ReverseMap();
            CreateMap<Company, ShowCompany>().ReverseMap();
            CreateMap<Company, ShowIndexCompanyDTO>().ReverseMap();
            CreateMap<Medicine, ShowMedicineDTO>().ReverseMap();
        }
    }
}
