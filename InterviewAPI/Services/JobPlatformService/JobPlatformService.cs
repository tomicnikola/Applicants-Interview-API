namespace InterviewAPI.Services.JobPlatformService
{
    public class JobPlatformService : IJobPlatformService
    {
        private readonly ApplicantsInterviewContext _context;

        public JobPlatformService(ApplicantsInterviewContext context)
        {
            _context = context;
        }
        public ICollection<JobPlatform> AddJobPlatform(JobPlatform jobPlatform)
        {
            _context.JobPlatforms.Add(jobPlatform);
            _context.SaveChanges();

            return _context.JobPlatforms.ToList();
        }

        public ICollection<JobPlatform>? DeleteJobPlatform(int id)
        {
            var jobPlatform = _context.JobPlatforms.Find(id);
            if (jobPlatform is null)
                return null;
            
            _context.JobPlatforms.Remove(jobPlatform);
            _context.SaveChanges();

            return _context.JobPlatforms.ToList();
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

        public ICollection<JobPlatform>? UpdateJobPlatform(JobPlatform jobPlatformRequest)
        {
            var jobPlatform = _context.JobPlatforms.Find(jobPlatformRequest.Id);
            if (jobPlatform is null)
                return null;

            jobPlatform.Code = jobPlatformRequest.Code;
            jobPlatform.Name = jobPlatformRequest.Name;
            jobPlatform.Description = jobPlatformRequest.Description;

            _context.SaveChanges();
            return _context.JobPlatforms.ToList();
        }
    }
}
