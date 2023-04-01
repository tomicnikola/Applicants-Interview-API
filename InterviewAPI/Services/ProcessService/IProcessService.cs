namespace InterviewAPI.Services.ProcessService
{
    public interface IProcessService
    {
        ICollection<Process> AddProcess(Process process);
        ICollection<Process> GetProcesses();
        Process? GetProcess(int id);
        ICollection<Process>? UpdateProcess(Process processRequest);
        ICollection<Process>? DeleteProcess(int id);
    }
}
