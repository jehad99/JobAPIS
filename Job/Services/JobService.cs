using AutoMapper;
using JobAPIS.Data;
using JobAPIS.DTOs;
using Microsoft.EntityFrameworkCore;

namespace JobAPIS.Services
{
    public class JobService : IJobService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public JobService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetApplicantDto>>> AddApplicant(AddApplicantDto newApplicant)
        {
            var response = new ServiceResponse<List<GetApplicantDto>>();
            try
            {
                Applicant applicant = _mapper.Map<Applicant>(newApplicant);
                var applicants = await _context.Applicants.ToListAsync();
                _context.Applicants.Add(applicant);
                await _context.SaveChangesAsync();
                foreach (char c in applicant.Name)
                {
                    if (!Char.IsLetter(c))
                    {
                        response.Status = false;
                        response.Message = "Name should contain only Letters";
                        return response;
                    }
                }
                response.Data = await _context.Applicants
                    .Select(c => _mapper.Map<GetApplicantDto>(c)).ToListAsync();
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetCareerDto>>> GetAllCareers()
        {
            var response = new ServiceResponse<List<GetCareerDto>>();
            try
            {
                var careers = await _context.Careers.ToListAsync();
                await _context.SaveChangesAsync();
                response.Data = careers.Select(c => _mapper.Map<GetCareerDto>(c)).ToList();
            }
            catch(Exception ex) 
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetJobDto>>> GetAllJobs()
        {
            var response = new ServiceResponse<List<GetJobDto>>();
            try
            {
                var jobs = await _context.Jobs.ToListAsync();
                await _context.SaveChangesAsync();
                response.Data = jobs.Select(j => _mapper.Map<GetJobDto>(j)).ToList();
            }
            catch(Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<GetJobDto>> GetJobById(int id)
        {
            var response = new ServiceResponse<GetJobDto>();
            try
            {
                var job = await _context.Jobs
                    .Include(j => j.Career)
                    .FirstOrDefaultAsync(j => j.Id == id);
                await _context.SaveChangesAsync();
                response.Data = _mapper.Map<GetJobDto>(job);
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }

      
    }
}
