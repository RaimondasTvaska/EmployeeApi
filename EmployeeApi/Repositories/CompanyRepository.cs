using EmployeeApi.Data;
using EmployeeApi.Entyties;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeApi.Repositories
{
    public class CompanyRepository
    {
        private readonly DataContext _dataContext;

        public CompanyRepository(DataContext context)
        {
            _dataContext = context;
        }
        public async Task CreateAsync(Company company)
        {
            _dataContext.Add(company);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Company> GetByIdAsync(int id)
        {
            return await _dataContext.Companies.Include(p => p.Employees).FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task<List<Company>> GetAllCompaniesAsync()
        {
            return await _dataContext.Companies.ToListAsync();
        }

        public async Task<Company> GetAllEmployeesAsync(int id)
        {
            return await _dataContext.Companies.Include(p => p.Employees).FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Company> GetCountEmployeesAsync(int id)
        {
            return await _dataContext.Companies.Include(p => p.Employees).FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task UpdateCompanyAsync(Company company)
        {
            _dataContext.Update(company);
            await _dataContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Company company)
        {
            _dataContext.Remove(company);
            await _dataContext.SaveChangesAsync();
        }
    }
}
