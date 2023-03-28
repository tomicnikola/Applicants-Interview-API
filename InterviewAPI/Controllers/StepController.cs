using AutoMapper;
using InterviewAPI.Dto;
using InterviewAPI.Services.StepService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;

namespace InterviewAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class StepController : ControllerBase
    {
        private readonly IStepService _stepService;
        private readonly IMapper _mapper;

        public StepController(IStepService stepService, IMapper mapper)
        {
            _stepService = stepService;
            _mapper = mapper;
        }

        [HttpPost("steps")]
        public IActionResult AddStep(Step step)
        {
            var result = _mapper.Map<List<StepDto>>(_stepService.AddStep(step));
            return Ok(result);
        }

        [HttpGet("steps")]
        public IActionResult GetSteps()
        {
            var result = _mapper.Map<List<StepDto>>(_stepService.GetSteps());
            return Ok(result);
        }
        [HttpGet("steps/{id}")]
        public IActionResult GetStep(int id)
        {
            var result = _mapper.Map<StepDto>(_stepService.GetStep(id));
            if (result is null)
                return NotFound("Invalid id, try again");
            return Ok(result);
        }
        [HttpDelete("steps/{id}")]
        public IActionResult DeleteStep(int id)
        {
            var result = _mapper.Map<List<StepDto>>(_stepService.DeleteStep(id));
            if (result is null)
                return NotFound("Invalid id, try again.");
            return Ok(result);
        }

        [HttpPut("steps")]
        public IActionResult UpdateStep(Step step)
        {
            var result = _mapper.Map<List<StepDto>>(_stepService.UpdateStep(step));
            if(result is null)
                return NotFound("Invalid id, try again.");
            return Ok(result);  
        }
    }
}
