namespace InterviewAPI.Services.ApplicationStatusService
{
    public class ApplicationStatusService : IApplicationStatusService
    {
        private readonly ApplicantsInterviewContext _context;

        public ApplicationStatusService(ApplicantsInterviewContext context)
        {
            _context = context;
        }
        public bool AddApplicationStatus(ApplicationStatus applicationStatus)
        {
            _context.Add(applicationStatus);
            return Save();
        }

        public bool ApplicationStatusExists(int id)
        {
            return _context.ApplicationStatuses.Any(a => a.Id == id);  
        }

        public bool DeleteApplicationStatus(ApplicationStatus applicationStatus)
        {
            _context.Remove(applicationStatus);
            return Save();
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

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateApplicationStatus(ApplicationStatus applicationStatus)
        {
            _context.Update(applicationStatus);
            return Save();
        }
    }
}
