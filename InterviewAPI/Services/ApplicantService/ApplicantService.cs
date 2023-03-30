namespace InterviewAPI.Services.ApplicantService
{
    public class ApplicantService : IApplicantService
    {
        private readonly ApplicantsInterviewContext _context;

        public ApplicantService(ApplicantsInterviewContext context)
        {
            _context = context;
        }
        public ICollection<Applicant> AddApplicant(Applicant applicant)
        {
            _context.Applicants.Add(applicant);
            _context.SaveChanges();

            return _context.Applicants.ToList();
        }

        public ICollection<Applicant>? DeleteApplicant(int id)
        {
            var applicant = _context.Applicants.Find(id);
            if (applicant is null)
                return null;

            _context.Applicants.Remove(applicant);
            _context.SaveChanges();

            return _context.Applicants.ToList();
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
            var applicant = _context.Applicants.ToList();
            return applicant;
        }

        public ICollection<Applicant>? UpdateApplicant(Applicant applicantRequest)
        {
            var applicant = _context.Applicants.Find(applicantRequest.Id);
            if (applicant is null)
                return null;

            applicant.FirstName = applicantRequest.FirstName;
            applicant.LastName = applicantRequest.LastName;
            applicant.Email = applicantRequest.Email;
            applicant.Phone = applicantRequest.Phone;
            applicant.Summary = applicantRequest.Summary;

            _context.SaveChanges();
            return _context.Applicants.ToList();
        }
    }
}
