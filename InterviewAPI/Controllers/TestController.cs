using AutoMapper;
using InterviewAPI.Dto;
using InterviewAPI.Models;
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
        public IActionResult AddTest([FromBody] TestDto testAdd)
        {
            if (testAdd is null)
                return BadRequest(ModelState);

            var test = _testService.GetTest(testAdd.Id);

            if (test is not null)
            {
                ModelState.AddModelError("", "Test already exists.");
                return StatusCode(403, ModelState);
            }

            var testMap = _mapper.Map<Test>(testAdd);

            if (!_testService.AddTest(testMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving.");
                return StatusCode(500, ModelState);
            }

            return Ok("Succesfully added a test.");
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

        [HttpGet("tests/code/{code}")]
        public IActionResult GetTest(string code)
        {
            var result = _mapper.Map<TestDto>(_testService.GetTest(code));
            if (result is null)
                return NotFound("Invalid code, try again.");
            return Ok(result);
        }

        [HttpPut("tests")]
        public IActionResult UpdateTest([FromBody]TestDto test)
        {
            if (test is null)
                return BadRequest(ModelState);

            if (!_testService.TestExists(test.Id))
                return NotFound("Test doesn't exist.");

            var testMap = _mapper.Map<Test>(test);

            if (!_testService.UpdateTest(testMap))
            {
                ModelState.AddModelError("", "Something went wrong updating test");
                return StatusCode(500, ModelState);
            }

            return Ok("Test succesfully updated.");
        }

        [HttpDelete("tests/{id}")]
        public IActionResult DeleteTest(int id)
        {
            if (!_testService.TestExists(id))
                return NotFound("Test doesn't exist.");

            var testToDelete = _testService.GetTest(id);

            if (!_testService.DeleteTest(testToDelete))
            {
                ModelState.AddModelError("", "Something went wront deleting step");
                return StatusCode(500, ModelState);
            }

            return Ok("Test succesfully deleted.");
        }
    }
}
