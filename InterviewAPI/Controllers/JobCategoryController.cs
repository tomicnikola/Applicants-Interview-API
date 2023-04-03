using AutoMapper;
using InterviewAPI.Dto;
using InterviewAPI.Models;
using InterviewAPI.Services.JobCategoryService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterviewAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class JobCategoryController : ControllerBase
    {
        private readonly IJobCategoryService _jobCategoryService;
        private readonly IMapper _mapper;

        public JobCategoryController(IJobCategoryService jobCategoryService, IMapper mapper)
        {
            _jobCategoryService = jobCategoryService;
            _mapper = mapper;
        }

        [HttpPost("jobCategories")]
        public IActionResult AddJobCategory([FromBody] JobCategoryDto jobCategoryAdd)
        {
            if (jobCategoryAdd is null)
                return BadRequest(ModelState);

            if (_jobCategoryService.JobCategoryExists(jobCategoryAdd.Id))
                return NotFound("Job category already exists by that id.");

            var jobCategoryMap = _mapper.Map<JobCategory>(jobCategoryAdd);

            if (!_jobCategoryService.AddJobCategory(jobCategoryMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving.");
                return StatusCode(500, ModelState);
            }

            return Ok("Succesfully added a job category.");
        }

        [HttpGet("jobCategories")]
        public IActionResult GetJobCategories()
        {
            var result = _mapper.Map<List<JobCategoryDto>>(_jobCategoryService.GetJobCategories());
            return Ok(result);
        }

        [HttpGet("jobCategories/{id}")]
        public IActionResult GetJobCategory(int id)
        {
            var result = _mapper.Map<JobCategoryDto>(_jobCategoryService.GetJobCategory(id));
            if (result is null)
                return NotFound("Invalid id, try again.");
            return Ok(result);
        }

        [HttpPut("jobCategories")]
        public IActionResult UpdateJobCategory([FromBody] JobCategoryDto jobCategory)
        {
            if (jobCategory is null)
                return BadRequest(ModelState);

            if (!_jobCategoryService.JobCategoryExists(jobCategory.Id))
                return NotFound("Job category doesn't exist.");

            var jobCategoryMap = _mapper.Map<JobCategory>(jobCategory);

            if (!_jobCategoryService.UpdateJobCategory(jobCategoryMap))
            {
                ModelState.AddModelError("", "Something went wrong updating job category");
                return StatusCode(500, ModelState);
            }

            return Ok("Job category succesfully updated.");
        }

        [HttpDelete("jobCategories/{id}")]
        public IActionResult DeleteJobCategory(int id)
        {
            if (!_jobCategoryService.JobCategoryExists(id))
                return NotFound("Job category doesn't exist.");

            var jobCategoryToDelete = _jobCategoryService.GetJobCategory(id);

            if (!_jobCategoryService.DeleteJobCategory(jobCategoryToDelete))
            {
                ModelState.AddModelError("", "Something went wront deleting job category");
                return StatusCode(500, ModelState);
            }

            return Ok("Job category succesfully deleted.");
        }
    }
}
