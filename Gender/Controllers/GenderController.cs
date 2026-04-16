using Gender.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Gender.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenderController : ControllerBase
    {
        private readonly IGenderService _genderService;

        public GenderController(IGenderService genderService)
        {
            _genderService = genderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetGender([FromQuery] string? name)
        {
            var response = await _genderService.GetGenderAsync(name);

            return StatusCode(response.StatusCode, response.Response);

        }
    }
}
