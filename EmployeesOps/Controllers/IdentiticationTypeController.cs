using EmployeesOps.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesOps.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentiticationTypeController : ControllerBase
    {
        private readonly IIdentificationTypeService _identificationTypeService;

        public IdentiticationTypeController(IIdentificationTypeService identificationTypeService)
        {
            _identificationTypeService = identificationTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _identificationTypeService.GetAllAsync();
            return Ok(result);
        }
    }
}
