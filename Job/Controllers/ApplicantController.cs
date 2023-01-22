using JobAPIS.DTOs;
using JobAPIS.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobAPIS.Controllers
{
    public class ApplicantController:ControllerBase
    {
        private readonly IJobService _jobService;

        public ApplicantController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpPost("Applicant")]
        public async Task<ActionResult<ServiceResponse<List<GetApplicantDto>>>> AddApplicant(AddApplicantDto newApplicant)
        {
            return Ok(await _jobService.AddApplicant(newApplicant));
        }
    }
}
