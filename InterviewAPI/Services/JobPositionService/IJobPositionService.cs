namespace InterviewAPI.Services.JobPositionService
{
    public interface IJobPositionService
    {
        bool AddJobPosition(JobPosition jobPosition);
        ICollection<JobPosition> GetJobPositions();
        JobPosition? GetJobPosition(int id);
        bool UpdateJobPosition(JobPosition jobPosition);
        bool DeleteJobPosition(JobPosition jobPosition);
        bool JobPositionExists(int id);
        bool Save();
    }
}
