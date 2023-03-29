using AutoMapper;
using InterviewAPI.Dto;
using InterviewAPI.Services.JobPositionService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterviewAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class JobPositionController : ControllerBase
    {
        private readonly IJobPositionService _jobPositionService;
        private readonly IMapper _mapper;

        public JobPositionController(IJobPositionService jobPositionService, IMapper mapper)
        {
            _jobPositionService = jobPositionService;
            _mapper = mapper;
        }
        [HttpPost("jobPositions")]
        public IActionResult AddJobPosition(JobPosition jobPosition)
        {
            var result = _mapper.Map<List<JobPositionDto>>(_jobPositionService.AddJobPosition(jobPosition));
            return Ok(result);
        }

        [HttpGet("jobPositions")]
        public IActionResult GetJobPositions()
        {
            var result = _mapper.Map<List<JobPositionDto>>(_jobPositionService.GetJobPositions());
            return Ok(result);
        }

        [HttpGet("jobPositions/{id}")]
        public IActionResult GetJobPosition(int id)
        {
            var result = _mapper.Map<JobPositionDto>(_jobPositionService.GetJobPosition(id));
            if (result is null)
                return NotFound("Invalid id, try again.");
            return Ok(result);
        }

        [HttpPut("jobPositions")]
        public IActionResult UpdateJobPosition(JobPosition jobPositionRequest)
        {
            var result = _mapper.Map<List<JobPositionDto>>(_jobPositionService.UpdateJobPosition(jobPositionRequest));
            if (result is null)
                return NotFound("Invalid id, try again.");
            return Ok(result);
        }

        [HttpDelete("jobPositions/{id}")]
        public IActionResult DeleteJobPosition(int id)
        {
            var result = _mapper.Map<List<JobPositionDto>>(_jobPositionService.DeleteJobPosition(id));
            if (result is null)
                return NotFound("Invalid id, try again.");
            return Ok(result);
        }
    }
}
