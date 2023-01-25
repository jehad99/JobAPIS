using JobAPIS.DTOs;

namespace JobAPIS.Services
{
    public interface IJobService
    {
        Task<ServiceResponse<List<GetJobNameDto>>> GetAllJobs(int id);
        Task<ServiceResponse<GetJobDto>> GetJobById(int id);
        Task<ServiceResponse<List<GetCareerDto>>> GetAllCareers();
        Task<ServiceResponse<GetApplicantDto>> AddApplicant(AddApplicantDto newApplicant);
    }
}
