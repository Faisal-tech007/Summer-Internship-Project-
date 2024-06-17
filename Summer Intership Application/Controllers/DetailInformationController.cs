using Microsoft.AspNetCore.Mvc;
using Summer_Intership_Application.Implementations.Interface;
using Summer_Intership_Application.Models;

namespace Summer_Intership_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailInformationController : ControllerBase
    {
        private readonly IPersonalInformation _personalInformationService;

        public DetailInformationController(IPersonalInformation personalInformationService)
        {
            _personalInformationService = personalInformationService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DetailInformation detailInformation)
        {
            if (detailInformation == null || detailInformation.AddtionalQuestions == null)
            {
                return BadRequest("Invalid request. DetailInformation and AdditionalQuestions are required.");
            }

            var createdEntity = await _personalInformationService.CreateAsync(detailInformation);

            if (createdEntity == null)
            {
                return StatusCode(500, "Failed to create DetailInformation.");
            }

            return Ok(createdEntity);
        }
    }
}
