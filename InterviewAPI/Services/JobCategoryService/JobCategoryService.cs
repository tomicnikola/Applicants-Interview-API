namespace InterviewAPI.Services.JobCategoryService
{
    public class JobCategoryService : IJobCategoryService
    {
        private readonly ApplicantsInterviewContext _context;

        public JobCategoryService(ApplicantsInterviewContext context)
        {
            _context = context;
        }
        public ICollection<JobCategory> AddJobCategory(JobCategory jobCategory)
        {
            _context.JobCategories.Add(jobCategory);
            _context.SaveChanges();

            return _context.JobCategories.ToList();

        }

        public ICollection<JobCategory>? DeleteJobCategory(int id)
        {
            var jobCategory = _context.JobCategories.Find(id);
            if (jobCategory == null)
                return null;

            _context.JobCategories.Remove(jobCategory);
            _context.SaveChanges();

            return _context.JobCategories.ToList();
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

        public ICollection<JobCategory>? UpdateJobCategory(JobCategory jobCategoryRequest)
        {
            var jobCategory = _context.JobCategories.Find(jobCategoryRequest.Id);
            if (jobCategory is null) 
                return null;

            jobCategory.Code = jobCategoryRequest.Code;
            jobCategory.Name = jobCategoryRequest.Name;
            jobCategory.Description = jobCategoryRequest.Description;

            _context.SaveChanges();

            return _context.JobCategories.ToList();
        }
    }
}
