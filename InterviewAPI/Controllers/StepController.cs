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
        public IActionResult AddStep([FromBody] StepDto stepAdd)
        {
            if (stepAdd is null)
                return BadRequest(ModelState);

            if (_stepService.StepExists(stepAdd.Id))
                return NotFound("Step already exists by that id.");

            var stepMap = _mapper.Map<Step>(stepAdd);

            if (!_stepService.AddStep(stepMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving.");
                return StatusCode(500, ModelState);
            }

            return Ok("Succesfully added a step.");
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
                return NotFound("Invalid id, try again.");
            return Ok(result);
        }

        [HttpGet("steps/code/{code}")]
        public IActionResult GetStep(string code)
        {
            var result = _mapper.Map<StepDto>(_stepService.GetStep(code));
            if (result is null)
                return NotFound("Invalid code, try again.");
            return Ok(result);
        }

        [HttpDelete("steps/{id}")]
        public IActionResult DeleteStep(int id)
        {
            if (!_stepService.StepExists(id))
                return NotFound("Step doesn't exist.");

            var stepToDelete = _stepService.GetStep(id);

            if (!_stepService.DeleteStep(stepToDelete))
            {
                ModelState.AddModelError("", "Something went wront deleting step");
                return StatusCode(500, ModelState);
            }

            return Ok("Step succesfully deleted.");
        }

        [HttpPut("steps")]
        public IActionResult UpdateStep([FromBody] StepDto step)
        {
            if (step is null)
                return BadRequest(ModelState);
            
            if (!_stepService.StepExists(step.Id))
                return NotFound("Step doesn't exist.");

            var stepMap = _mapper.Map<Step>(step);

            if(!_stepService.UpdateStep(stepMap))
            {
                ModelState.AddModelError("", "Something went wrong updating step");
                return StatusCode(500, ModelState);
            }

            return Ok("Step succesfully updated.");
        }
    }
}
