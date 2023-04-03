namespace InterviewAPI.Services.ApplicationStatusService
{
    public interface IApplicationStatusService
    {
        bool AddApplicationStatus(ApplicationStatus applicationStatus);
        ICollection<ApplicationStatus> GetApplicationStatuses();
        ApplicationStatus? GetApplicationStatus(int id);
        bool UpdateApplicationStatus(ApplicationStatus applicationStatus);
        bool DeleteApplicationStatus(ApplicationStatus applicationStatus);
        bool ApplicationStatusExists(int id);
        bool Save();
    }
}
