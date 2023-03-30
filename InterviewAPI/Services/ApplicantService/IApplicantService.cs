namespace InterviewAPI.Services.ApplicantService
{
    public interface IApplicantService
    {
        ICollection<Applicant> AddApplicant(Applicant applicant);
        ICollection<Applicant> GetApplicants();
        Applicant? GetApplicant(int id);
        ICollection<Applicant>? UpdateApplicant(Applicant applicantRequest);
        ICollection<Applicant>? DeleteApplicant(int id);
    }
}
