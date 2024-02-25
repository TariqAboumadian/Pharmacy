using AutoMapper;
using Pharmacy.Application.Contracts;
using Pharmacy.Data;
using Pharmacy.DTO.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Application.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository companyRepository;
        private readonly IMapper _map;
        public CompanyService(ICompanyRepository _companyRepository,IMapper mapper)
        {
            companyRepository = _companyRepository;
            _map = mapper;
        }

        public async Task<bool> Create(CreateCompanyDTO createCompanyDTO)
        {
            var comapny = _map.Map<Company>(createCompanyDTO);
            var res = await companyRepository.CreateAsync(comapny);
            if(res is not null)
            {
                var ok = await companyRepository.SaveChangesAsync();
                if (ok !=0)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<List<ShowCompany>> GetAll()
        {
            var companies = await companyRepository.GetAllAsync();
            var res = companies.Select(p => new ShowCompany() { Id = p.Id, Name = p.Name });
            return res.ToList();
        }

        public async Task<List<ShowIndexCompanyDTO>> GetAllCompanies()
        {
            var companies = _map.Map<List<ShowIndexCompanyDTO>>(await companyRepository.GetAllAsync());
            return companies;
        }
    }
}
