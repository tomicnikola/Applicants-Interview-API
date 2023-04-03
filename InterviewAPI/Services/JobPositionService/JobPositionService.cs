using InterviewAPI.Models;

namespace InterviewAPI.Services.JobPositionService
{
    public class JobPositionService : IJobPositionService
    {
        private readonly ApplicantsInterviewContext _context;

        public JobPositionService(ApplicantsInterviewContext context)
        {
            _context = context;
        }

        public bool AddJobPosition(JobPosition jobPosition)
        {
            _context.Add(jobPosition);
            return Save();
        }

        public bool DeleteJobPosition(JobPosition jobPosition)
        {
            _context.Remove(jobPosition);
            return Save();
        }

        public JobPosition? GetJobPosition(int id)
        {
            var jobPosition = _context.JobPositions.Find(id);
            if (jobPosition is null)
                return null;
            return jobPosition;
        }

        public ICollection<JobPosition> GetJobPositions()
        {
            var jobPositions = _context.JobPositions.ToList();
            return jobPositions;
        }

        public bool JobPositionExists(int id)
        {
            return _context.JobPositions.Any(j => j.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateJobPosition(JobPosition jobPosition)
        {
            _context.Update(jobPosition);
            return Save();
        }
    }
}
