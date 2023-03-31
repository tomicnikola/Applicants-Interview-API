using AutoMapper;
using InterviewAPI.Dto;

namespace InterviewAPI.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Step, StepDto>();
            CreateMap<JobCategory, JobCategoryDto>();
            CreateMap<JobPlatform, JobPlatformDto>();
            CreateMap<JobPosition, JobPositionDto>();
            CreateMap<Organization, OrganizationDto>();
            CreateMap<Applicant, ApplicantDto>();
            CreateMap<Document, DocumentDto>();
            CreateMap<Test, TestDto>();
            CreateMap<ApplicationStatus, ApplicationStatusDto>();
        }
    }
}
