using AutoMapper;
using JobAPIS.Data;
using JobAPIS.DTOs;
using JobAPIS.Models;
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
                var name = applicant.FirstName + " " + applicant.LastName;
                var applicants = await _context.Applicants.ToListAsync();
                var emailExist = _context.Applicants.Any(a => a.Email == applicant.Email);
                var phoneExist = _context.Applicants.Any(a => a.Phone == applicant.Phone);

                foreach (char c in name)
                {
                    if (!Char.IsLetter(c) && !Char.IsWhiteSpace(c))
                    {
                        response.Status = false;
                        response.Message = "Name should contain only Letters";
                        return response;
                    }
                }
                if (applicant.Email == null)
                {
                    response.Status = false;
                    response.Message = "Email is required";
                    return response;
                }
                else if (!applicant.Email.Contains('@') || !applicant.Email.Contains('.'))
                {
                    response.Status = false;
                    response.Message = "Email should be valid";
                    return response;
                }
                else if (emailExist == true)
                {
                    response.Status = false;
                    response.Message = "Email exist";
                    return response;
                }
                else if (applicant.FirstName == null)
                {
                    response.Status = false;
                    response.Message = "First name is required";
                    return response;
                }
                else if (applicant.LastName == null)
                {
                    response.Status = false;
                    response.Message = "Last name is required";
                    return response;
                }
              
                else if (applicant.Phone == null)
                {
                    response.Status = false;
                    response.Message = "Phone number is required";
                    return response;
                }
                else if (phoneExist == true)
                {
                    response.Status = false;
                    response.Message = "Phone number exist";
                    return response;
                }
                int count = 0;
                foreach (char c in applicant.Phone)
                {
                    if (!Char.IsDigit(c))
                    {
                        response.Status = false;
                        response.Message = "Phone number should contain numbers only";
                        return response;
                    }
                    count++;
                }
                if (count != 11)
                {
                    response.Status = false;
                    response.Message = "Phone number should contain 11 numbers";
                    return response;
                }
                _context.Applicants.Add(applicant);
                await _context.SaveChangesAsync();
                
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

        public async Task<ServiceResponse<List<GetJobDto>>> GetAllJobs(int id)
        {
            var response = new ServiceResponse<List<GetJobDto>>();
            try
            {
               
                var jobs = await _context.Jobs
                    .Include(j => j.Career)
                    .Where(j => j.Career != null && j.Career.Id == id).ToListAsync();
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
