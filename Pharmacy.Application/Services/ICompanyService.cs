using Pharmacy.Data;
using Pharmacy.DTO.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Application.Services
{
    public interface ICompanyService
    {
        public Task<List<ShowCompany>> GetAll();
        public Task<List<ShowIndexCompanyDTO>> GetAllCompanies();
        public Task<bool> Create(CreateCompanyDTO createCompanyDTO);
    }
}
