namespace InterviewAPI.Services.JobCategoryService
{
    public interface IJobCategoryService
    {
        ICollection<JobCategory> AddJobCategory(JobCategory jobCategory);
        ICollection<JobCategory> GetJobCategories();
        JobCategory? GetJobCategory(int id);
        ICollection<JobCategory>? UpdateJobCategory(JobCategory jobCategoryRequest);
        ICollection<JobCategory>? DeleteJobCategory(int id);
    }
}
