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

        public ICollection<JobPosition> AddJobPosition(JobPosition jobPosition)
        {
            _context.JobPositions.Add(jobPosition);
            _context.SaveChanges();

            return _context.JobPositions.ToList();
        }

        public ICollection<JobPosition>? DeleteJobPosition(int id)
        {
            var jobPosition = _context.JobPositions.Find(id);
            if (jobPosition is null)
                return null;
            
            _context.JobPositions.Remove(jobPosition);
            _context.SaveChanges();

            return _context.JobPositions.ToList();
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

        public ICollection<JobPosition>? UpdateJobPosition(JobPosition jobPositionRequest)
        {
            var jobPosition = _context.JobPositions.Find(jobPositionRequest.Id);
            if (jobPosition is null)
                return null;

            jobPosition.Code = jobPositionRequest.Code;
            jobPosition.Name = jobPositionRequest.Name;
            jobPosition.Description = jobPositionRequest.Description;

            _context.SaveChanges();
            return _context.JobPositions.ToList();
        }
    }
}
