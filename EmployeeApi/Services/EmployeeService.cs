using EmployeeApi.Dtos;
using EmployeeApi.Entyties;
using EmployeeApi.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeApi.Services
{
    public class EmployeeService
    {
        private EmployeeRepository _employeeRepository;
        private CompanyRepository _companyRepository;

        public EmployeeService(EmployeeRepository employeeRepository, CompanyRepository companyRepository)
        {
            _employeeRepository = employeeRepository;
            _companyRepository = companyRepository;
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _employeeRepository.GetAllEmployeesAsync();
        }
        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _employeeRepository.GetByIdAsync(id);
        }
        public async Task AddAsync(CreateEmployeeDto createEmployeeDto)
        {
            var entity = new Employee()
            {
                FirstName = createEmployeeDto.FirstName,
                LastName = createEmployeeDto.LastName,
                GenderType = Enum.Parse<GenderType>(createEmployeeDto.Gender),
                CompanyListId = createEmployeeDto.CompanyListId
            };
            if (createEmployeeDto.CompanyListId.HasValue)
            {
                var company = await _companyRepository.GetByIdAsync(createEmployeeDto.CompanyListId.Value);
                if (company == null)
                {
                    throw new ArgumentException("Freelancer");
                }
            }
            await _employeeRepository.CreateAsync(entity);

        }


        public async Task UpdateEmployeeAsync(Employee employee)
        {
            await _employeeRepository.UpdateEmployee(employee);
        }

        public async Task DeleteAsync(int id)
        {
            var employee = await GetByIdAsync(id);
            await _employeeRepository.DeleteAsync(employee);
        }
    }
}
