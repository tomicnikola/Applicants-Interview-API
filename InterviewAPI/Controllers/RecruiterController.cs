using AutoMapper;
using InterviewAPI.Dto;
using InterviewAPI.Models;
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
        public IActionResult AddRecruiter([FromBody] RecruiterDto recruiterAdd)
        {
            if (recruiterAdd is null)
                return BadRequest(ModelState);

            if (_recruiterService.RecruiterExists(recruiterAdd.Id))
                return NotFound("Recruiter already exists by that id.");

            var recruiterMap = _mapper.Map<Recruiter>(recruiterAdd);

            if (!_recruiterService.AddRecruiter(recruiterMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving.");
                return StatusCode(500, ModelState);
            }

            return Ok("Succesfully added a recruiter.");
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
            if (recruiter is null)
                return BadRequest(ModelState);

            if (!_recruiterService.RecruiterExists(recruiter.Id))
                return NotFound("Recruiter doesn't exist.");

            var recruiterMap = _mapper.Map<Recruiter>(recruiter);

            if (!_recruiterService.UpdateRecruiter(recruiterMap))
            {
                ModelState.AddModelError("", "Something went wrong updating recruiter");
                return StatusCode(500, ModelState);
            }

            return Ok("Recruiter succesfully updated.");
        }

        [HttpDelete("recruiters/{id}")]
        public IActionResult DeleteRecruiter(int id)
        {
            if (!_recruiterService.RecruiterExists(id))
                return NotFound("Recruiter doesn't exist.");

            var recruiterToDelete = _recruiterService.GetRecruiter(id);

            if (!_recruiterService.DeleteRecruiter(recruiterToDelete))
            {
                ModelState.AddModelError("", "Something went wront deleting recruiter");
                return StatusCode(500, ModelState);
            }

            return Ok("Recruiter succesfully deleted.");
        }
    }
}
