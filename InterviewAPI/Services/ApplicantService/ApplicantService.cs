using Microsoft.EntityFrameworkCore.Internal;

namespace InterviewAPI.Services.ApplicantService
{
    public class ApplicantService : IApplicantService
    {
        private readonly ApplicantsInterviewContext _context;

        public ApplicantService(ApplicantsInterviewContext context)
        {
            _context = context;
        }
        public bool AddApplicant(Applicant applicant)
        {
            _context.Add(applicant);
            return Save();
        }

        public bool ApplicantExists(int id)
        {
            return _context.Applicants.Any(a => a.Id == id);
        }

        public bool DeleteApplicant(Applicant applicant)
        {
            _context.Remove(applicant);
            return Save();
        }

        public Applicant? GetApplicant(int id)
        {
            var applicant = _context.Applicants.Find(id);
            if (applicant is null)
                return null;
            return applicant;
        }

        public ICollection<Applicant> GetApplicants()
        {
            var applicants = _context.Applicants.ToList();
            return applicants;
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateApplicant(Applicant applicant)
        {
            _context.Update(applicant);
            return Save();
        }
    }
}
