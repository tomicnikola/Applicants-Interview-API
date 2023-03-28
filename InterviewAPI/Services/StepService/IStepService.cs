namespace InterviewAPI.Services.StepService
{
    public interface IStepService
    {
        Task<List<Step>> AddStep(Step step);
        Task<List<Step>> GetSteps();
        Task<Step?> GetStep(Step step);
        Task<List<Step>?> UpdateStep(Step step);
        Task<List<Step>?> DeleteStep(int id);
    }
}
