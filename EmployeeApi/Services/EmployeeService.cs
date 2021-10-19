using EmployeeApi.Dtos;
using EmployeeApi.Entyties;
using EmployeeApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<EmployeeDto>> GetAllAsync()
        {
            var employeeEntities = await _employeeRepository.GetAllEmployeesAsync();
            var dtos = employeeEntities.Select(e => new EmployeeDto()
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                CompanyListId = e.CompanyListId,
                GenderType = e.GenderType.ToString()

            });

            return dtos.ToList();
        }
        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _employeeRepository.GetByIdAsync(id);
        }
        public async Task<int> AddAsync(CreateEmployeeDto createEmployeeDto)
        {
            var genderType = Enum.Parse<GenderType>(createEmployeeDto.Gender ?? "Unspecified");
            var entity = new Employee()
            {
                FirstName = createEmployeeDto.FirstName,
                LastName = createEmployeeDto.LastName,
                GenderType = genderType,
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
            return entity.Id;

        }


        public async Task UpdateEmployeeAsync(EmployeeDto employee)
        {
            var genderType = Enum.Parse<GenderType>(employee.GenderType ?? "Unspecified");
            var entity = new Employee()
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                GenderType = genderType,
                CompanyListId = employee.CompanyListId
            };

            await _employeeRepository.UpdateEmployee(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var employee = await GetByIdAsync(id);
            await _employeeRepository.DeleteAsync(employee);
        }
    }
}
