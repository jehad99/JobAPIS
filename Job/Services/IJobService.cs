using JobAPIS.DTOs;

namespace JobAPIS.Services
{
    public interface IJobService
    {
        Task<ServiceResponse<List<GetJobDto>>> GetAllJobs();
        Task<ServiceResponse<GetJobDto>> GetJobById(int id);
        Task<ServiceResponse<List<GetCareerDto>>> GetAllCareers();
        Task<ServiceResponse<List<GetApplicantDto>>> AddApplicant(AddApplicantDto newApplicant);
    }
}
