namespace InterviewAPI.Services.ProcessService
{
    public class ProcessService : IProcessService
    {
        private readonly ApplicantsInterviewContext _context;

        public ProcessService(ApplicantsInterviewContext context)
        {
            _context = context;
        }
        public bool AddProcess(Process process)
        {
            _context.Add(process);
            return Save();
        }

        public bool DeleteProcess(Process process)
        {
            _context.Remove(process);
            return Save();
        }

        public Process? GetProcess(int id)
        {
            var process = _context.Processes.Find(id);
            if (process is null)
                return null;
            return process;
        }

        public Process? GetProcess(string code)
        {
            var process = _context.Processes.Where(p => p.Code == code).FirstOrDefault();
            if (process is null)
                return null;
            return process; 
        }

        public ICollection<Process> GetProcesses()
        {
            var processes = _context.Processes.ToList();
            return processes;
        }

        public bool ProcessExists(int id)
        {
            return _context.Processes.Any(p => p.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateProcess(Process processRequest)
        {
            _context.Update(processRequest);
            return Save();
        }

    }
}
