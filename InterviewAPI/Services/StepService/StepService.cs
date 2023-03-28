using Microsoft.EntityFrameworkCore;

namespace InterviewAPI.Services.StepService
{
    public class StepService : IStepService
    {
        private readonly ApplicantsInterviewContext _context;

        public StepService(ApplicantsInterviewContext context)
        {
            _context = context;
        }
        public async Task<List<Step>> AddStep(Step step)
        {
            _context.Steps.Add(step);
            await _context.SaveChangesAsync();

            return await _context.Steps.ToListAsync();
        }

        public Task<List<Step>?> DeleteStep(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Step?> GetStep(Step step)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Step>> GetSteps()
        {
            var steps = await _context.Steps.ToListAsync();
            return steps;
        }

        public Task<List<Step>?> UpdateStep(Step step)
        {
            throw new NotImplementedException();
        }
    }
}
