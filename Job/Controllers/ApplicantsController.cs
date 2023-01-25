using JobAPIS.DTOs;
using JobAPIS.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobAPIS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApplicantsController:ControllerBase
    {
        private readonly IJobService _jobService;

        public ApplicantsController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpPost()]
        public async Task<ActionResult<ServiceResponse<AddApplicantDto>>> AddApplicant(AddApplicantDto newApplicant)
        {
            return Ok(await _jobService.AddApplicant(newApplicant));
        }
    }
}
