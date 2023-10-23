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
    }
}
