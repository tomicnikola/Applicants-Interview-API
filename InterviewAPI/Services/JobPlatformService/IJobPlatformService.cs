namespace InterviewAPI.Services.JobPlatformService
{
    public interface IJobPlatformService
    {
        ICollection<JobPlatform> AddJobPlatform(JobPlatform jobPlatform);
        ICollection<JobPlatform> GetJobPlatforms();
        JobPlatform? GetJobPlatform(int id);
        ICollection<JobPlatform>? UpdateJobPlatform(JobPlatform jobPlatformRequest);
        ICollection<JobPlatform>? DeleteJobPlatform(int id);
    }
}
