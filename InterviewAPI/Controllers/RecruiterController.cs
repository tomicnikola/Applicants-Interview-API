using AutoMapper;
using InterviewAPI.Dto;
using InterviewAPI.Services.RecruiterService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterviewAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class RecruiterController : ControllerBase
    {
        private readonly IRecruiterService _recruiterService;
        private readonly IMapper _mapper;

        public RecruiterController(IRecruiterService recruiterService, IMapper mapper)
        {
            _recruiterService = recruiterService;
            _mapper = mapper;
        }

        [HttpPost("recruiters")]
        public IActionResult AddRecruiter(Recruiter recruiter)
        {
            var result = _mapper.Map<List<RecruiterDto>>(_recruiterService.AddRecruiter(recruiter));
            return Ok(result);
        }

        [HttpGet("recruiters")]
        public IActionResult GetRecruiters()
        {
            var result = _mapper.Map<List<RecruiterDto>>(_recruiterService.GetRecruiters());
            return Ok(result);
        }
        [HttpGet("recruiters/{id}")]
        public IActionResult GetRecruiter(int id)
        {
            var result = _mapper.Map<RecruiterDto>(_recruiterService.GetRecruiter(id));
            if (result is null)
                return NotFound("Invalid id, try again.");
            return Ok(result);
        }

        [HttpPut("recruiters")]
        public IActionResult UpdateRecruiter(Recruiter recruiter)
        {
            var result = _mapper.Map<List<RecruiterDto>>(_recruiterService.UpdateRecruiter(recruiter));
            if (result is null)
                return NotFound("Invalid id, try again.");
            return Ok(result);
        }

        [HttpDelete("recruiters/{id}")]
        public IActionResult DeleteRecruiter(int id)
        {
            var result = _mapper.Map<List<RecruiterDto>>(_recruiterService.DeleteRecruiter(id));
            if (result is null)
                return NotFound("Invalid id, try again.");
            return Ok(result);
        }
    }
}
