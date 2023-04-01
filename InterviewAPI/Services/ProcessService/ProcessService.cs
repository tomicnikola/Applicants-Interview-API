namespace InterviewAPI.Services.ProcessService
{
    public class ProcessService : IProcessService
    {
        private readonly ApplicantsInterviewContext _context;

        public ProcessService(ApplicantsInterviewContext context)
        {
            _context = context;
        }
        public ICollection<Process> AddProcess(Process process)
        {
            _context.Processes.Add(process);
            _context.SaveChanges();

            return _context.Processes.ToList();
        }

        public ICollection<Process>? DeleteProcess(int id)
        {
            var process = _context.Processes.Find(id);
            if (process is null)
                return null;

            _context.Processes.Remove(process);
            _context.SaveChanges();

            return _context.Processes.ToList();
        }

        public Process? GetProcess(int id)
        {
            var process = _context.Processes.Find(id);
            if (process is null)
                return null;
            return process;
        }

        public ICollection<Process> GetProcesses()
        {
            var processes = _context.Processes.ToList();
            return processes;
        }

        public ICollection<Process>? UpdateProcess(Process processRequest)
        {
            var process = _context.Processes.Find(processRequest.Id);
            if (process is null)
                return null;

            process.Code = processRequest.Code;
            process.Description = processRequest.Description;
            process.Recruiter = processRequest.Recruiter;

            _context.SaveChanges();
            return _context.Processes.ToList();
        }
    }
}
