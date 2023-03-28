using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InterviewAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly ApplicantsInterviewContext _context;

        public AnswerController(ApplicantsInterviewContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("answers")]
        public async Task<ActionResult<List<Answer>>> GetAnswers()
        {
            return Ok(await _context.Answers.ToListAsync());
        }
    }
}
