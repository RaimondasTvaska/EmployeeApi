using EmployeeApi.Entyties;
using EmployeeApi.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeApi.Services
{
    public class CompanyService
    {
        private CompanyRepository _companyRepository;

        public CompanyService(CompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
        public async Task<List<Company>> GetAllAsync()
        {
            return await _companyRepository.GetAllCompaniesAsync();
        }
        public async Task<Company> GetByIdAsync(int id)
        {
            return await _companyRepository.GetByIdAsync(id);
        }
        public async Task AddAsync(Company company)
        {
            await _companyRepository.CreateAsync(company);
        }

        public async Task DeleteAsync(int id)
        {
            var company = await GetByIdAsync(id);
            await _companyRepository.DeleteAsync(company);
        }
    }
}
