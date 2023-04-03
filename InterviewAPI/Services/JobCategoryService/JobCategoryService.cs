namespace InterviewAPI.Services.JobCategoryService
{
    public class JobCategoryService : IJobCategoryService
    {
        private readonly ApplicantsInterviewContext _context;

        public JobCategoryService(ApplicantsInterviewContext context)
        {
            _context = context;
        }
        public bool AddJobCategory(JobCategory jobCategory)
        {
            _context.Add(jobCategory);
            return Save();
        }

        public bool DeleteJobCategory(JobCategory jobCategory)
        {
            _context.Remove(jobCategory);
            return Save();
        }

        public ICollection<JobCategory> GetJobCategories()
        {
            var jobCategories = _context.JobCategories.ToList();
            return jobCategories;
        }

        public JobCategory? GetJobCategory(int id)
        {
            var jobCategory = _context.JobCategories.Find(id);
            if (jobCategory is null)
                return null;
            return jobCategory;
        }

        public bool JobCategoryExists(int id)
        {
            return _context.JobCategories.Any(j => j.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateJobCategory(JobCategory jobCategory)
        {
            _context.Update(jobCategory);
            return Save();
        }

    }
}
