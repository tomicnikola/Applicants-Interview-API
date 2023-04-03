using AutoMapper;
using InterviewAPI.Dto;
using InterviewAPI.Models;
using InterviewAPI.Services.JobPlatformService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterviewAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class JobPlatformController : ControllerBase
    {
        private readonly IJobPlatformService _jobPlatformService;
        private readonly IMapper _mapper;

        public JobPlatformController(IJobPlatformService jobPlatformService, IMapper mapper)
        {
            _jobPlatformService = jobPlatformService;
            _mapper = mapper;
        }

        [HttpPost("jobPlatforms")]
        public IActionResult AddJobPlatform([FromBody] JobPlatformDto jobPlatformAdd)
        {
            if (jobPlatformAdd is null)
                return BadRequest(ModelState);

            if (_jobPlatformService.JobPlatformExists(jobPlatformAdd.Id))
                return NotFound("Job platform already exists by that id.");

            var jobPlatformMap = _mapper.Map<JobPlatform>(jobPlatformAdd);

            if (!_jobPlatformService.AddJobPlatform(jobPlatformMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving.");
                return StatusCode(500, ModelState);
            }

            return Ok("Succesfully added a job platform.");
        }

        [HttpGet("jobPlatforms")]
        public IActionResult GetJobPlatforms()
        {
            var result = _mapper.Map<List<JobPlatformDto>>(_jobPlatformService.GetJobPlatforms());
            return Ok(result);
        }

        [HttpGet("jobPlatforms/{id}")]
        public IActionResult GetJobPlatform(int id)
        {
            var result = _mapper.Map<JobPlatformDto>(_jobPlatformService.GetJobPlatform(id));
            if (result is null)
                return NotFound("Invalid id, try again.");
            return Ok(result);
        }

        [HttpPut("jobPlatforms")]
        public IActionResult UpdateJobPlatform([FromBody] JobPlatformDto jobPlatform)
        {
            if (jobPlatform is null)
                return BadRequest(ModelState);

            if (!_jobPlatformService.JobPlatformExists(jobPlatform.Id))
                return NotFound("Job platform doesn't exist.");

            var jobPlatformMap = _mapper.Map<JobPlatform>(jobPlatform);

            if (!_jobPlatformService.UpdateJobPlatform(jobPlatformMap))
            {
                ModelState.AddModelError("", "Something went wrong updating job platform");
                return StatusCode(500, ModelState);
            }

            return Ok("Job platform succesfully updated.");
        }

        [HttpDelete("jobPlatforms/{id}")]
        public IActionResult DeleteJobPlatform(int id)
        {
            if (!_jobPlatformService.JobPlatformExists(id))
                return NotFound("Job platform doesn't exist.");

            var jobPlatformToDelete = _jobPlatformService.GetJobPlatform(id);

            if (!_jobPlatformService.DeleteJobPlatform(jobPlatformToDelete))
            {
                ModelState.AddModelError("", "Something went wront deleting job platform");
                return StatusCode(500, ModelState);
            }

            return Ok("Job platform succesfully deleted.");
        }
    }
}
