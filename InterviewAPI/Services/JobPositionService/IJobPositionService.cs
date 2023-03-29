namespace InterviewAPI.Services.JobPositionService
{
    public interface IJobPositionService
    {
        ICollection<JobPosition> AddJobPosition(JobPosition jobPosition);
        ICollection<JobPosition> GetJobPositions();
        JobPosition? GetJobPosition(int id);
        ICollection<JobPosition>? UpdateJobPosition(JobPosition jobPositionRequest);
        ICollection<JobPosition>? DeleteJobPosition(int id);
    }
}
