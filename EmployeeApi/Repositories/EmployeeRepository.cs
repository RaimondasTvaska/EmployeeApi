using EmployeeApi.Data;
using EmployeeApi.Entyties;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeApi.Repositories
{
    public class EmployeeRepository
    {
        private readonly DataContext _dataContext;

        public EmployeeRepository(DataContext context)
        {
            _dataContext = context;
        }
        public async Task CreateAsync(Employee employee)
        {
            _dataContext.Add(employee);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _dataContext.Employees.FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await _dataContext.Employees.ToListAsync();
        }

        public async Task DeleteAsync(Employee employee)
        {
            _dataContext.Remove(employee);
            await _dataContext.SaveChangesAsync();
        }

    }
}
