using EmployeeApi.Dtos;
using EmployeeApi.Entyties;
using EmployeeApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetAll()
        {
            return Ok(await _employeeService.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Employee>>> GetById(int id)
        {
            var employee = await _employeeService.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateEmployeeDto employee)
        {
            await _employeeService.AddAsync(employee);
            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
            await _employeeService.UpdateEmployeeAsync(employee);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeService.DeleteAsync(id);
            return NoContent();
        }
    }
}
