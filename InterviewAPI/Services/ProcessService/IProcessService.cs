namespace InterviewAPI.Services.ProcessService
{
    public interface IProcessService
    {
        bool AddProcess(Process process);
        ICollection<Process> GetProcesses();
        Process? GetProcess(int id);
        Process? GetProcess(string code);
        bool UpdateProcess(Process process);
        bool DeleteProcess(Process process);
        bool ProcessExists(int id);
        bool Save();
    }
}
