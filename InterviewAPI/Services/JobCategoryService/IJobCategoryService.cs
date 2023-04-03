namespace InterviewAPI.Services.JobCategoryService
{
    public interface IJobCategoryService
    {
        bool AddJobCategory(JobCategory jobCategory);
        ICollection<JobCategory> GetJobCategories();
        JobCategory? GetJobCategory(int id);
        bool UpdateJobCategory(JobCategory jobCategory);
        bool DeleteJobCategory(JobCategory jobCategory);
        bool JobCategoryExists(int id);
        bool Save();
    }
}
