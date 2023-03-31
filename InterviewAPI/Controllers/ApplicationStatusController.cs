using AutoMapper;
using InterviewAPI.Dto;
using InterviewAPI.Services.ApplicationStatusService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterviewAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ApplicationStatusController : ControllerBase
    {
        private readonly IApplicationStatusService _applicationStatusService;
        private readonly IMapper _mapper;

        public ApplicationStatusController(IApplicationStatusService applicationStatusService, IMapper mapper)
        {
            _applicationStatusService = applicationStatusService;
            _mapper = mapper;
        }

        [HttpPost("applicationStatuses")]
        public IActionResult AddApplicationStatus(ApplicationStatus applicationStatus)
        {
            var result = _mapper.Map<List<ApplicationStatusDto>>(_applicationStatusService.AddApplicationStatus(applicationStatus));
            return Ok(result);
        }

        [HttpGet("applicationStatuses")]
        public IActionResult GetApplicationStatuses()
        {
            var result = _mapper.Map<List<ApplicationStatusDto>>(_applicationStatusService.GetApplicationStatuses());
            return Ok(result);
        }

        [HttpGet("applicationStatuses/{id}")]
        public IActionResult GetApplicationStatus(int id)
        {
            var result = _mapper.Map<ApplicationStatusDto>(_applicationStatusService.GetApplicationStatus(id));
            if (result is null)
                return NotFound("Invalid id, try again.");
            return Ok(result);
        }

        [HttpPut("applicationStatuses")]
        public IActionResult UpdateApplicationStatus(ApplicationStatus applicationStatus)
        {
            var result = _mapper.Map<List<ApplicationStatusDto>>(_applicationStatusService.UpdateApplicationStatus(applicationStatus));
            if (result is null)
                return NotFound("Invalid id, try again.");
            return Ok(result);
        }

        [HttpDelete("applicationStatuses/{id}")]
        public IActionResult DeleteApplicationStatus(int id)
        {
            var result = _mapper.Map<List<ApplicationStatusDto>>(_applicationStatusService.DeleteApplicationStatus(id));
            if (result is null)
                return NotFound("Invalid id, try again.");
            return Ok(result);
        }
    }
}
