using AutoMapper;
using InterviewAPI.Dto;
using InterviewAPI.Services.JobPlatformService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterviewAPI.Controllers
{
    [Route("api/[controller]")]
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
        public IActionResult AddJobPlatform(JobPlatform jobPlatform)
        {
            var result = _mapper.Map<List<JobPlatformDto>>(_jobPlatformService.AddJobPlatform(jobPlatform));
            return Ok(result);
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
        public IActionResult UpdateJobPlatform(JobPlatform jobPlatformRequest)
        {
            var result = _mapper.Map<List<JobPlatformDto>>(_jobPlatformService.UpdateJobPlatform(jobPlatformRequest));
            if (result is null)
                return NotFound("Invalid id, try again.");
            return Ok(result);
        }

        [HttpDelete("jobPlatforms/{id}")]
        public IActionResult DeleteJobPlatform(int id)
        {
            var result = _mapper.Map<List<JobPlatformDto>>(_jobPlatformService.DeleteJobPlatform(id));
            if (result is null)
                return NotFound("Invalid id, try again.");
            return Ok(result);
        }
    }
}
