using AutoMapper;
using InterviewAPI.Dto;

namespace InterviewAPI.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Step, StepDto>();
            CreateMap<StepDto, Step>();
            CreateMap<JobCategory, JobCategoryDto>();
            CreateMap<JobPlatform, JobPlatformDto>();
            CreateMap<JobPlatformDto, JobPlatform>();
            CreateMap<JobPosition, JobPositionDto>();
            CreateMap<JobPositionDto, JobPosition>();
            CreateMap<Organization, OrganizationDto>();
            CreateMap<OrganizationDto, Organization>();
            CreateMap<Applicant, ApplicantDto>();
            CreateMap<Document, DocumentDto>();
            CreateMap<Test, TestDto>();
            CreateMap<TestDto, Test>();
            CreateMap<ApplicationStatus, ApplicationStatusDto>();
            CreateMap<Recruiter, RecruiterDto>();
            CreateMap<RecruiterDto, Recruiter>();
            CreateMap<Process, ProcessDto>();
        }
    }
}
