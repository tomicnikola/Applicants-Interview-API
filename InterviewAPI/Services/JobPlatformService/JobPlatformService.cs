namespace InterviewAPI.Services.JobPlatformService
{
    public class JobPlatformService : IJobPlatformService
    {
        private readonly ApplicantsInterviewContext _context;

        public JobPlatformService(ApplicantsInterviewContext context)
        {
            _context = context;
        }
        public bool AddJobPlatform(JobPlatform jobPlatform)
        {
            _context.Add(jobPlatform);
            return Save();
        }

        public bool DeleteJobPlatform(JobPlatform jobPlatform)
        {
            _context.Remove(jobPlatform);
            return Save();
        }

        public JobPlatform? GetJobPlatform(int id)
        {
            var jobPlatform = _context.JobPlatforms.Find(id);
            if (jobPlatform is null)
                return null;
            return jobPlatform;
        }

        public ICollection<JobPlatform> GetJobPlatforms()
        {
            var jobPlatforms = _context.JobPlatforms.ToList();
            return jobPlatforms;
        }

        public bool JobPlatformExists(int id)
        {
            return _context.JobPlatforms.Any(j => j.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateJobPlatform(JobPlatform jobPlatform)
        {
            _context.Update(jobPlatform);
            return Save();
        }

    }
}
