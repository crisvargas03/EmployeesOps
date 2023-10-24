using EmployeesOps.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesOps.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDeparmentService _deparmentService;

        public DepartmentController(IDeparmentService deparmentService)
        {
            _deparmentService = deparmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _deparmentService.GetAllAsync();
            return Ok(result);
        }
    }
}
