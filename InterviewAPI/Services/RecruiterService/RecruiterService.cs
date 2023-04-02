namespace InterviewAPI.Services.RecruiterService
{
    public class RecruiterService : IRecruiterService
    {
        private readonly ApplicantsInterviewContext _context;

        public RecruiterService(ApplicantsInterviewContext context)
        {
            _context = context;
        }
        public bool AddRecruiter(Recruiter recruiter)
        {
            _context.Add(recruiter);
            return Save();
        }

        public bool DeleteRecruiter(Recruiter recruiter)
        {
            _context.Remove(recruiter);
            return Save();
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

        public bool RecruiterExists(int id)
        {
            return _context.Recruiters.Any(r => r.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateRecruiter(Recruiter recruiterRequest)
        {
            _context.Update(recruiterRequest);
            return Save();
        }
    }
}
