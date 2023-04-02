namespace InterviewAPI.Services.StepService
{
    public interface IStepService
    {
        bool AddStep(Step step);
        ICollection<Step> GetSteps();
        Step? GetStep(int id);
        Step? GetStep(string code);
        bool UpdateStep(Step step);
        bool DeleteStep(Step step);
        bool StepExists(int id);
        bool Save();
    }
}
