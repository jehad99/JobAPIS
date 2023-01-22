using JobAPIS.DTOs;
using JobAPIS.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JobAPIS.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class JobController:ControllerBase
    {
        private readonly IJobService _jobService;

        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }
        [HttpGet("GetAllJobs{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetJobDto>>>> GetAllJobs(int id)
        {
            return Ok(await _jobService.GetAllJobs(id));
        }

        [HttpGet("GetJobByID{id}")]
        public async Task<ActionResult<ServiceResponse<GetJobDto>>> GetSingleJob(int id)
        {
            return Ok(await _jobService.GetJobById(id));
        }
    }
}
