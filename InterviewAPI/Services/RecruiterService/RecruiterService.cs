namespace InterviewAPI.Services.RecruiterService
{
    public class RecruiterService : IRecruiterService
    {
        private readonly ApplicantsInterviewContext _context;

        public RecruiterService(ApplicantsInterviewContext context)
        {
            _context = context;
        }
        public ICollection<Recruiter> AddRecruiter(Recruiter recruiter)
        {
            _context.Recruiters.Add(recruiter);
            _context.SaveChanges();

            return _context.Recruiters.ToList();
        }

        public ICollection<Recruiter>? DeleteRecruiter(int id)
        {
            var recruiter = _context.Recruiters.Find(id);
            if (recruiter is null)
                return null; 
        
            _context.Recruiters.Remove(recruiter);
            _context.SaveChanges();

            return _context.Recruiters.ToList();
        }

        public Recruiter? GetRecruiter(int id)
        {
            var recruiter = _context.Recruiters.Find(id);
            if (recruiter is null)
                return null;
            return recruiter;
        }

        public ICollection<Recruiter> GetRecruiters()
        {
            var recruiters = _context.Recruiters.ToList();
            return recruiters;
        }

        public ICollection<Recruiter>? UpdateRecruiter(Recruiter recruiterRequest)
        {
            var recruiter = _context.Recruiters.Find(recruiterRequest.Id);
            if (recruiter is null)
                return null;

            recruiter.FirstName = recruiterRequest.FirstName;
            recruiter.LastName = recruiterRequest.LastName;

            _context.SaveChanges();
            return _context.Recruiters.ToList();
        }
    }
}
