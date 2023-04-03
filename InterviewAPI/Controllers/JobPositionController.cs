using AutoMapper;
using InterviewAPI.Dto;
using InterviewAPI.Models;
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
        public IActionResult AddJobPosition([FromBody] JobPositionDto jobPositionAdd)
        {
            if (jobPositionAdd is null)
                return BadRequest(ModelState);

            var jobPosition = _jobPositionService.GetJobPosition(jobPositionAdd.Id);

            if (jobPosition is not null)
            {
                ModelState.AddModelError("", "Job position already exists.");
                return StatusCode(403, ModelState);
            }

            var jobPositionMap = _mapper.Map<JobPosition>(jobPositionAdd);

            if (!_jobPositionService.AddJobPosition(jobPositionMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving.");
                return StatusCode(500, ModelState);
            }

            return Ok("Succesfully added a job position.");
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
        public IActionResult UpdateJobPosition([FromBody] JobPositionDto jobPosition)
        {
            if (jobPosition is null)
                return BadRequest(ModelState);

            if (!_jobPositionService.JobPositionExists(jobPosition.Id))
                return NotFound("Job position doesn't exist.");

            var jobPositionMap = _mapper.Map<JobPosition>(jobPosition);

            if (!_jobPositionService.UpdateJobPosition(jobPositionMap))
            {
                ModelState.AddModelError("", "Something went wrong updating job position");
                return StatusCode(500, ModelState);
            }

            return Ok("Job position succesfully updated.");
        }

        [HttpDelete("jobPositions/{id}")]
        public IActionResult DeleteJobPosition(int id)
        {
            if (!_jobPositionService.JobPositionExists(id))
                return NotFound("Job position doesn't exist.");

            var jobPositionToDelete = _jobPositionService.GetJobPosition(id);

            if (!_jobPositionService.DeleteJobPosition(jobPositionToDelete))
            {
                ModelState.AddModelError("", "Something went wront deleting job position");
                return StatusCode(500, ModelState);
            }

            return Ok("Job position succesfully deleted.");
        }
    }
}
