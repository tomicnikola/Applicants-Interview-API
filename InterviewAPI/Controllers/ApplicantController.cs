using AutoMapper;
using InterviewAPI.Dto;
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
        public IActionResult AddApplicant(Applicant applicant)
        {
            var result = _mapper.Map<List<ApplicantDto>>(_applicantService.AddApplicant(applicant));
            return Ok(result);
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
        public IActionResult UpdateApplicant(Applicant applicant)
        {
            var result = _mapper.Map<List<ApplicantDto>>(_applicantService.UpdateApplicant(applicant));
            if (result is null)
                return NotFound("Invalid id, try again.");
            return Ok(result);
        }

        [HttpDelete("applicants/{id}")]
        public IActionResult DeleteApplicant(int id)
        {
            var result = _mapper.Map<List<ApplicantDto>>(_applicantService.DeleteApplicant(id));
            if (result is null)
                return NotFound("Invalid id, try again.");
            return Ok(result);
        }
    }
}
