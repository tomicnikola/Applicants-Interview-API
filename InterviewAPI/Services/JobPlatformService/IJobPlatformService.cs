namespace InterviewAPI.Services.JobPlatformService
{
    public interface IJobPlatformService
    {
        bool AddJobPlatform(JobPlatform jobPlatform);
        ICollection<JobPlatform> GetJobPlatforms();
        JobPlatform? GetJobPlatform(int id);
        bool UpdateJobPlatform(JobPlatform jobPlatform);
        bool DeleteJobPlatform(JobPlatform jobPlatform);
        bool JobPlatformExists(int id);
        bool Save();
    }
}
