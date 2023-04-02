using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace InterviewAPI.Services.StepService
{
    public class StepService : IStepService
    {
        private readonly ApplicantsInterviewContext _context;

        public StepService(ApplicantsInterviewContext context)
        {
            _context = context;
        }
        public bool AddStep(Step step)
        {
            _context.Add(step);
            return Save();
        }

        public bool DeleteStep(Step step)
        {
            _context.Remove(step);
            return Save();
        }

        public Step? GetStep(int id)
        {
            var step = _context.Steps.Find(id);
            if (step is null)
                return null;
            return step;
        }

        public Step? GetStep(string code)
        {
            var step = _context.Steps.Where(s => s.Code == code).FirstOrDefault();
            if (step is null)
                return null;
            return step;
        }

        public ICollection<Step> GetSteps()
        {
            var steps = _context.Steps.ToList();
            return steps;
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool StepExists(int id)
        {
            return _context.Steps.Any(s => s.Id == id);
        }

        public bool UpdateStep(Step stepRequest)
        {
            _context.Update(stepRequest);
            return Save();
        }
    }
}
