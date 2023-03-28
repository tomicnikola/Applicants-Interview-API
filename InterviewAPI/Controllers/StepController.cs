using InterviewAPI.Services.StepService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterviewAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class StepController : ControllerBase
    {
        private readonly IStepService _stepService;

        public StepController(IStepService stepService)
        {
            _stepService = stepService;
        }

        [HttpPost]
        [Route("steps")]
        public async Task<ActionResult<List<Step>>> AddStep(Step step)
        {
            var result = await _stepService.AddStep(step);
            return Ok(result);
        }

        [HttpGet]
        [Route("steps")]
        public async Task<ActionResult<List<Step>>> GetSteps()
        {
            return await _stepService.GetSteps();
        }
    }
}
