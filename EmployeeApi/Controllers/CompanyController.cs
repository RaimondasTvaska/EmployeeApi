using EmployeeApi.Dtos;
using EmployeeApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmployeeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : Controller
    {
        private readonly CompanyService _companyService;

        public CompanyController(CompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _companyService.GetAllAsync());
        }

        [HttpGet("{id}/Employees")]
        public async Task<IActionResult> GetAllCompanyEmployees(int id)
        {
            return Ok(await _companyService.GetAllEmployeesAsync(id));
        }

        [HttpGet("{id}/EmployeeCount")]
        public async Task<IActionResult> GetCountEmployeesAsync(int id)
        {
            var company = await _companyService.GetCountEmployeesAsync(id);
            return Ok(new { Count = company.Employees.Count });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _companyService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCompanyDto company)
        {
            await _companyService.AddAsync(company);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateCompanyDto companyUpdateDto)
        {
            //if (id != company.Id)
            //{
            //    return BadRequest();
            //}
            await _companyService.UpdateCompanyAsync(id, companyUpdateDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _companyService.DeleteAsync(id);
            return NoContent();
        }
    }
}
