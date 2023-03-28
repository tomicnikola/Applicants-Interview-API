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
        public ICollection<Step> AddStep(Step step)
        {
            _context.Steps.Add(step);
            _context.SaveChanges();

            return  _context.Steps.ToList();
        }

        public ICollection<Step>? DeleteStep(int id)
        {
            var step = _context.Steps.Find(id);
            if (step is null)
                return null;

            _context.Steps.Remove(step);
            _context.SaveChanges();

            return _context.Steps.ToList();
        }

        public Step? GetStep(int id)
        {
            var step = _context.Steps.Find(id);
            if (step is null)
                return null;
            return step;
        }

        public ICollection<Step> GetSteps()
        {
            var steps = _context.Steps.ToList();
            return steps;
        }

        public ICollection<Step>? UpdateStep(Step stepRequest)
        {
            var step = _context.Steps.Find(stepRequest.Id);
            if (step is null)
                return null;

            step.Code = stepRequest.Code;
            step.Name = stepRequest.Name;

            _context.SaveChanges();

            return _context.Steps.ToList();
        }
    }
}
