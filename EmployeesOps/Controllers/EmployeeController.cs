using EmployeesOps.BLL.Dtos;
using EmployeesOps.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EmployeesOps.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _employeeService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _employeeService.GetByIdAsync(id);
            return result switch
            {
                { IsSuccess: true } => Ok(result),
                { StatusCode: HttpStatusCode.NotFound } => NotFound(result),
                _ => BadRequest(result),
            };
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmployeeInsertDto employeeInsert)
        {
            var result = await _employeeService.InsertAsync(employeeInsert);
            return result switch
            {
                { IsSuccess: true } => Ok(result),
                _ => BadRequest(result)
            };
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(Guid id, [FromBody] EmployeeUpdateDto employeeUpdate)
        {
            var result = await _employeeService.UpdateAsync(id, employeeUpdate);
            return result switch
            {
                { IsSuccess: true } => Ok(result),
                { StatusCode: HttpStatusCode.NotFound } => NotFound(result),
                _ => BadRequest(result)
            };
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _employeeService.DeleteAsync(id);
            return result switch
            {
                { IsSuccess: true } => Ok(result),
                { StatusCode: HttpStatusCode.NotFound } => NotFound(result),
                _ => BadRequest(result)
            };
        }
    }
}
