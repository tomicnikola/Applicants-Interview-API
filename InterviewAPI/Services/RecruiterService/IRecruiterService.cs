namespace InterviewAPI.Services.RecruiterService
{
    public interface IRecruiterService
    {
        bool AddRecruiter(Recruiter recruiter);
        ICollection<Recruiter> GetRecruiters();
        Recruiter? GetRecruiter(int id);
        bool UpdateRecruiter(Recruiter recruiter);
        bool DeleteRecruiter(Recruiter recruiter);
        bool RecruiterExists(int id);
        bool Save();
    }
}
