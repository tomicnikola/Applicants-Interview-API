namespace InterviewAPI.Services.StepService
{
    public interface IStepService
    {
        ICollection<Step> AddStep(Step step);
        ICollection<Step> GetSteps();
        Step? GetStep(int id);
        ICollection<Step>? UpdateStep(Step stepRequest);
        ICollection<Step>? DeleteStep(int id);
    }
}
