using AutoMapper;
using JobAPIS.DTOs;

namespace JobAPIS
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Work, GetJobDto>().ReverseMap();
            CreateMap<Work, GetJobNameDto>().ReverseMap();
            CreateMap<Work, AddJobDto>().ReverseMap();
            CreateMap<Career, GetCareerDto>().ReverseMap();
            CreateMap<Applicant, GetApplicantDto>().ReverseMap();
            CreateMap<Applicant, AddApplicantDto>().ReverseMap();
        }
    }
}
