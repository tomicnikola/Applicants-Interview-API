using AutoMapper;
using InterviewAPI.Dto;
using InterviewAPI.Models;
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
        public IActionResult AddApplicationStatus([FromBody] ApplicationStatusDto applicationStatusAdd)
        {
            if (applicationStatusAdd is null)
                return BadRequest(ModelState);

            if (_applicationStatusService.ApplicationStatusExists(applicationStatusAdd.Id))
                return NotFound("Application status already exists by that id.");

            var applicationStatusMap = _mapper.Map<ApplicationStatus>(applicationStatusAdd);

            if (!_applicationStatusService.AddApplicationStatus(applicationStatusMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving.");
                return StatusCode(500, ModelState);
            }

            return Ok("Succesfully added a application status.");
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
        public IActionResult UpdateApplicationStatus([FromBody] ApplicationStatusDto applicationStatus)
        {
            if (applicationStatus is null)
                return BadRequest(ModelState);

            if (!_applicationStatusService.ApplicationStatusExists(applicationStatus.Id))
                return NotFound("Application status doesn't exist.");

            var applicationStatusMap = _mapper.Map<ApplicationStatus>(applicationStatus);

            if (!_applicationStatusService.UpdateApplicationStatus(applicationStatusMap))
            {
                ModelState.AddModelError("", "Something went wrong updating application status");
                return StatusCode(500, ModelState);
            }

            return Ok("Application status succesfully updated.");
        }

        [HttpDelete("applicationStatuses/{id}")]
        public IActionResult DeleteApplicationStatus(int id)
        {
            if (!_applicationStatusService.ApplicationStatusExists(id))
                return NotFound("Application status doesn't exist.");

            var applicationStatusToDelete = _applicationStatusService.GetApplicationStatus(id);

            if (!_applicationStatusService.DeleteApplicationStatus(applicationStatusToDelete))
            {
                ModelState.AddModelError("", "Something went wront deleting applicaiton status");
                return StatusCode(500, ModelState);
            }

            return Ok("Application status succesfully deleted.");
        }
    }
}
