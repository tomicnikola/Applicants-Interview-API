namespace InterviewAPI.Services.RecruiterService
{
    public interface IRecruiterService
    {
        bool AddRecruiter(Recruiter test);
        ICollection<Recruiter> GetRecruiters();
        Recruiter? GetRecruiter(int id);
        bool UpdateRecruiter(Recruiter test);
        bool DeleteRecruiter(Recruiter test);
        bool RecruiterExists(int id);
        bool Save();
    }
}
