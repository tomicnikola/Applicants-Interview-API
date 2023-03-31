namespace InterviewAPI.Services.ApplicationStatusService
{
    public interface IApplicationStatusService
    {
        ICollection<ApplicationStatus> AddApplicationStatus(ApplicationStatus applicationStatus);
        ICollection<ApplicationStatus> GetApplicationStatuses();
        ApplicationStatus? GetApplicationStatus(int id);
        ICollection<ApplicationStatus>? UpdateApplicationStatus(ApplicationStatus applicationStatusRequest);
        ICollection<ApplicationStatus>? DeleteApplicationStatus(int id);
    }
}
