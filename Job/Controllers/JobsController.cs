using JobAPIS.DTOs;
using JobAPIS.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JobAPIS.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class JobsController:ControllerBase
    {
        private readonly IJobService _jobService;

        public JobsController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetJobDto>>> GetSingleJob(int id)
        {
            return Ok(await _jobService.GetJobById(id));
        }
    }
}
