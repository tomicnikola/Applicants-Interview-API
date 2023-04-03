using AutoMapper;
using InterviewAPI.Dto;
using InterviewAPI.Models;
using InterviewAPI.Services.ApplicantService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterviewAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantService _applicantService;
        private readonly IMapper _mapper;

        public ApplicantController(IApplicantService applicantService, IMapper mapper)
        {
            _applicantService = applicantService;
            _mapper = mapper;
        }

        [HttpPost("applicants")]
        public IActionResult AddApplicant([FromBody] ApplicantDto applicantAdd)
        {
            if (applicantAdd is null)
                return BadRequest(ModelState);

            if (_applicantService.ApplicantExists(applicantAdd.Id))
                return NotFound("Applicant already exists by that id.");

            var applicantMap = _mapper.Map<Applicant>(applicantAdd);

            if (!_applicantService.AddApplicant(applicantMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving.");
                return StatusCode(500, ModelState);
            }

            return Ok("Succesfully added an applicant.");
        }

        [HttpGet("applicants")]
        public IActionResult GetApplicants()
        {
            var result = _mapper.Map<List<ApplicantDto>>(_applicantService.GetApplicants());
            return Ok(result);
        }

        [HttpGet("applicants/{id}")]
        public IActionResult GetApplicant(int id)
        {
            var result = _mapper.Map<ApplicantDto>(_applicantService.GetApplicant(id));
            if (result is null)
                return NotFound("Invalid id, try again.");
            return Ok(result);
        }

        [HttpPut("applicants")]
        public IActionResult UpdateApplicant([FromBody] ApplicantDto applicant)
        {
            if (applicant is null)
                return BadRequest(ModelState);

            if (!_applicantService.ApplicantExists(applicant.Id))
                return NotFound("Applicant doesn't exist.");

            var applicantMap = _mapper.Map<Applicant>(applicant);

            if (!_applicantService.UpdateApplicant(applicantMap))
            {
                ModelState.AddModelError("", "Something went wrong updating applicant");
                return StatusCode(500, ModelState);
            }

            return Ok("Applicant succesfully updated.");
        }

        [HttpDelete("applicants/{id}")]
        public IActionResult DeleteApplicant(int id)
        {
            if (!_applicantService.ApplicantExists(id))
                return NotFound("Applicant doesn't exist.");

            var applicantToDelete = _applicantService.GetApplicant(id);

            if (!_applicantService.DeleteApplicant(applicantToDelete))
            {
                ModelState.AddModelError("", "Something went wront deleting applicant");
                return StatusCode(500, ModelState);
            }

            return Ok("Applicant succesfully deleted.");
        }
    }
}
