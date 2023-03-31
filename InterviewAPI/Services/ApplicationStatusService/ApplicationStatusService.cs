namespace InterviewAPI.Services.ApplicationStatusService
{
    public class ApplicationStatusService : IApplicationStatusService
    {
        private readonly ApplicantsInterviewContext _context;

        public ApplicationStatusService(ApplicantsInterviewContext context)
        {
            _context = context;
        }
        public ICollection<ApplicationStatus> AddApplicationStatus(ApplicationStatus applicationStatus)
        {
            _context.ApplicationStatuses.Add(applicationStatus);
            _context.SaveChanges();

            return _context.ApplicationStatuses.ToList();
        }

        public ICollection<ApplicationStatus>? DeleteApplicationStatus(int id)
        {
            var applicationStatus = _context.ApplicationStatuses.Find(id);
            if (applicationStatus is null)
                return null;
            
            _context.ApplicationStatuses.Remove(applicationStatus);
            _context.SaveChanges();

            return _context.ApplicationStatuses.ToList();
        }

        public ApplicationStatus? GetApplicationStatus(int id)
        {
            var applicationStatus = _context.ApplicationStatuses.Find(id);
            if (applicationStatus is null)
                return null;
            return applicationStatus;
        }

        public ICollection<ApplicationStatus> GetApplicationStatuses()
        {
            var applicationStatuses = _context.ApplicationStatuses.ToList();
            return applicationStatuses;
        }

        public ICollection<ApplicationStatus>? UpdateApplicationStatus(ApplicationStatus applicationStatusRequest)
        {
            var applicationStatus = _context.ApplicationStatuses.Find(applicationStatusRequest.Id);
            if (applicationStatus is null)
                return null;

            applicationStatus.Status = applicationStatusRequest.Status;

            _context.SaveChanges();
            return _context.ApplicationStatuses.ToList();
        }
    }
}
