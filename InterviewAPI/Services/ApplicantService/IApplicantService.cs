namespace InterviewAPI.Services.ApplicantService
{
    public interface IApplicantService
    {
        bool AddApplicant(Applicant applicant);
        ICollection<Applicant> GetApplicants();
        Applicant? GetApplicant(int id);
        bool UpdateApplicant(Applicant applicant);
        bool DeleteApplicant(Applicant applicant);
        bool ApplicantExists(int id);
        bool Save();
    }
}
