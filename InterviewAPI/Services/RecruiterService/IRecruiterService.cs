namespace InterviewAPI.Services.RecruiterService
{
    public interface IRecruiterService
    {
        ICollection<Recruiter> AddRecruiter(Recruiter recruiter);
        ICollection<Recruiter> GetRecruiters();
        Recruiter? GetRecruiter(int id);
        ICollection<Recruiter>? UpdateRecruiter(Recruiter recruiterRequest);
        ICollection<Recruiter>? DeleteRecruiter(int id);
    }
}
