using JobAPIS.DTOs;
using JobAPIS.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobAPIS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CareersController:ControllerBase
    {
        private readonly IJobService _jobService;

        public CareersController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetCareerDto>>>> GetAllCareers()
        {
            return Ok(await _jobService.GetAllCareers());
        }
        [HttpGet("{id}/JobsName")]
        public async Task<ActionResult<ServiceResponse<List<GetJobNameDto>>>> GetCareerJobs(int id)
        {
            return Ok(await _jobService.GetAllJobs(id));
        }
    }
}
