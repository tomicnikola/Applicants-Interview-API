using AutoMapper;
using InterviewAPI.Dto;
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
        public IActionResult AddJobCategory(JobCategory jobCategory)
        {
            var result = _mapper.Map<List<JobCategoryDto>>(_jobCategoryService.AddJobCategory(jobCategory));
            return Ok(result);
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
        public IActionResult UpdateJobCategory(JobCategory jobCategoryRequest)
        {
            var result = _mapper.Map<List<JobCategoryDto>>(_jobCategoryService.UpdateJobCategory(jobCategoryRequest));
            if (result is null)
                return NotFound("Invalid id, try again.");
            return Ok(result);
        }

        [HttpDelete("jobCategories/{id}")]
        public IActionResult DeleteJobCategory(int id)
        {
            var result = _mapper.Map<List<JobCategoryDto>>(_jobCategoryService.DeleteJobCategory(id));
            if (result is null)
                return NotFound("Invalid id, try again.");
            return Ok(result);
        }
    }
}
