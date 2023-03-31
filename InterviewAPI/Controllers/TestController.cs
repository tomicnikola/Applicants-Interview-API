using AutoMapper;
using InterviewAPI.Dto;
using InterviewAPI.Services.TestService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterviewAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;
        private readonly IMapper _mapper;

        public TestController(ITestService testService, IMapper mapper)
        {
            _testService = testService;
            _mapper = mapper;
        }

        [HttpPost("tests")]
        public IActionResult AddTest(Test test)
        {
            var result = _mapper.Map<List<TestDto>>(_testService.AddTest(test));
            return Ok(result);
        }

        [HttpGet("tests")]
        public IActionResult GetTests()
        {
            var result = _mapper.Map<List<TestDto>>(_testService.GetTests());
            return Ok(result);
        }

        [HttpGet("tests/{id}")]
        public IActionResult GetTest(int id)
        {
            var result = _mapper.Map<TestDto>(_testService.GetTest(id));
            if (result is null)
                return NotFound("Invalid id, try again.");
            return Ok(result);
        }

        [HttpPut("tests")]
        public IActionResult UpdateTest(Test test)
        {
            var result = _mapper.Map<List<TestDto>>(_testService.UpdateTest(test));
            if (result is null)
                return NotFound("Invalid id, try again.");
            return Ok(result);  
        }

        [HttpDelete("tests/{id}")]
        public IActionResult DeleteTest(int id)
        {
            var result = _mapper.Map<List<TestDto>>(_testService.DeleteTest(id));
            if (result is null)
                return NotFound("Invalid id, try again.");
            return Ok(result);
        }
    }
}
