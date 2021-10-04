using AutoMapper;
using EmployeeApi.Dtos;
using EmployeeApi.Entyties;
using EmployeeApi.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeApi.Services
{
    public class CompanyService
    {
        private readonly CompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyService(CompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<List<Company>> GetAllAsync()
        {

            return await _companyRepository.GetAllCompaniesAsync();
        }

        public async Task<Company> GetAllEmployeesAsync(int id)
        {
            return await _companyRepository.GetAllEmployeesAsync(id);
        }

        public async Task<Company> GetCountEmployeesAsync(int id)
        {
            return await _companyRepository.GetCountEmployeesAsync(id);
        }
        public async Task<Company> GetByIdAsync(int id)
        {
            return await _companyRepository.GetByIdAsync(id);
        }
        public async Task AddAsync(CreateCompanyDto createCompanyDto)
        {
            var entity = _mapper.Map<Company>(createCompanyDto);
            await _companyRepository.CreateAsync(entity);
        }

        public async Task UpdateCompanyAsync(int id, UpdateCompanyDto updateCompanyDto)
        {
            var entity = _mapper.Map<Company>(updateCompanyDto);
            if (id != entity.Id)
            {
                throw new ArgumentException("Company not found");
            }
            await _companyRepository.UpdateCompanyAsync(entity); ;
        }

        public async Task DeleteAsync(int id)
        {
            var company = await GetByIdAsync(id);
            await _companyRepository.DeleteAsync(company);
        }
    }
}
