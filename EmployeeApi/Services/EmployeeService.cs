using EmployeeApi.Entyties;
using EmployeeApi.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeApi.Services
{
    public class EmployeeService
    {
        private EmployeeRepository _employeeRepository;

        public EmployeeService(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<List<Employee>> GetAllAsync()
        {
            return await _employeeRepository.GetAllEmployeesAsync();
        }
        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _employeeRepository.GetByIdAsync(id);
        }
        public async Task AddAsync(Employee employee)
        {
            //if (point.PointListId.HasValue)
            //{
            //    var pointList = await _pointListRepository.GetByIdAsync(point.PointListId.Value);
            //    if (pointList == null)
            //    {
            //        throw new ArgumentException("PointList does not exist");
            //    }
            //}

            await _employeeRepository.CreateAsync(employee);
        }

        public async Task DeleteAsync(int id)
        {
            var employee = await GetByIdAsync(id);
            await _employeeRepository.DeleteAsync(employee);
        }
    }
}
