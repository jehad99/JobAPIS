using AutoMapper;
using JobAPIS.Data;
using JobAPIS.DTOs;
using JobAPIS.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

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
        
        public async Task<ServiceResponse<GetApplicantDto>> AddApplicant(AddApplicantDto newApplicant)
        {
            var response = new ServiceResponse<GetApplicantDto>();
            try
            {
                var job = await _context.Jobs
                    .Include(j => j.Applicants)
                    //.Where(j => j.Id == newApplicant.JobId)
                    .FirstOrDefaultAsync(j => j.Id == newApplicant.JobId);
                if (job == null) 
                {
                    response.Status = false;
                    response.Message = "JobId not found";
                    return response;
                }
                Applicant applicant = _mapper.Map<Applicant>(newApplicant);
                var name = applicant.FirstName + " " + applicant.LastName;
                foreach (char c in name)
                {
                    if (!Char.IsLetter(c) && !Char.IsWhiteSpace(c))
                    {
                        response.Status = false;
                        response.Message = "Name should contain only Letters";
                        return response;
                    }
                }
                var emailExist = _context.Applicants.Any(a => a.Email == applicant.Email);
                var phoneExist = _context.Applicants.Any(a => a.Phone == applicant.Phone);
                if (emailExist == true)
                {
                    response.Status = false;
                    response.Message = "Email exist";
                    return response;
                }
                if (phoneExist == true)
                {
                    response.Status = false;
                    response.Message = "Phone number exist";
                    return response;
                }
                job?.Applicants.Add(applicant);
                await _context.SaveChangesAsync();

                response.Data = _mapper.Map<GetApplicantDto>(applicant);
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

        //return Name column from Jobs db with specific career
        public async Task<ServiceResponse<List<GetJobNameDto>>> GetAllJobs(int id)
        {
            var response = new ServiceResponse<List<GetJobNameDto>>();
            try
            {
                var jobs = await _context.Jobs
                    .Where(j => j.Career.Id == id)
                    .ToListAsync();
                response.Data =  _mapper.Map<List<GetJobNameDto>>(jobs);
            }
            catch (Exception ex)
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
