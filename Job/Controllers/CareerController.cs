using JobAPIS.DTOs;
using JobAPIS.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobAPIS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CareerController:ControllerBase
    {
        private readonly IJobService _jobService;

        public CareerController(IJobService jobService)
        {
            _jobService = jobService;
        }
        [HttpGet("GetAllCareers")]
        public async Task<ActionResult<ServiceResponse<List<GetJobDto>>>> GetAllCareers()
        {
            return Ok(await _jobService.GetAllCareers());
        }
    }
}
