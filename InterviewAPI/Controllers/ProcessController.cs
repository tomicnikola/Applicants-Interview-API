using AutoMapper;
using InterviewAPI.Dto;
using InterviewAPI.Services.ProcessService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterviewAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ProcessController : ControllerBase
    {
        private readonly IProcessService _processService;
        private readonly IMapper _mapper;

        public ProcessController(IProcessService processService, IMapper mapper)
        {
            _processService = processService;
            _mapper = mapper;
        }

        [HttpPost("processes")]
        public IActionResult AddProcess(Process process)
        {
            var result = _mapper.Map<List<ProcessDto>>(_processService.AddProcess(process));
            return Ok(result);
        }

        [HttpGet("processes")]
        public IActionResult GetProcesses()
        {
            var result = _mapper.Map<List<ProcessDto>>(_processService.GetProcesses());
            return Ok(result);
        }

        [HttpGet("processes/{id}")]
        public IActionResult GetProcess(int id)
        {
            var result = _mapper.Map<ProcessDto>(_processService.GetProcess(id));
            if (result is null)
                return NotFound("Invalid id, try again.");
            return Ok(result);
        }

        [HttpPut("processes")]
        public IActionResult UpdateProcess(Process process)
        {
            var result = _mapper.Map<List<ProcessDto>>(_processService.UpdateProcess(process));
            if (result is null)
                return NotFound("Invalid id, try again.");
            return Ok(result);
        }

        [HttpDelete("processes/{id}")]
        public IActionResult DeleteProcess(Process process)
        {
            var result = _mapper.Map<List<ProcessDto>>(_processService.DeleteProcess(process));
            if (result is null)
                return NotFound("Invalid id, try again.");
            return Ok(result);
        }
    }
}
