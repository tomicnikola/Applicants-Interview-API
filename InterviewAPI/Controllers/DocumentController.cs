using AutoMapper;
using InterviewAPI.Dto;
using InterviewAPI.Services.DocumentService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterviewAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _documentService;
        private readonly IMapper _mapper;

        public DocumentController(IDocumentService documentService, IMapper mapper)
        {
            _documentService = documentService;
            _mapper = mapper;
        }

        [HttpPost("documents")]
        public IActionResult AddDocument(Document document)
        {
            var result = _mapper.Map<List<DocumentDto>>(_documentService.AddDocument(document));
            return Ok(result);
        }

        [HttpGet("documents")]
        public IActionResult GetDocuments()
        {
            var result = _mapper.Map<List<DocumentDto>>(_documentService.GetDocuments());
            return Ok(result);
        }

        [HttpGet("documents/{id}")]
        public IActionResult GetDocument(int id)
        {
            var result = _mapper.Map<DocumentDto>(_documentService.GetDocument(id));
            if (result is null)
                return NotFound("Invalid id, try again.");
            return Ok(result);
        }

        [HttpPut("documents")]
        public IActionResult UpdateDocument(Document document)
        {
            var result = _mapper.Map<List<DocumentDto>>(_documentService.UpdateDocument(document));
            if (result is null)
                return NotFound("Invalid id, try again.");
            return Ok(result);
        }

        [HttpDelete("documents/{id}")]
        public IActionResult DeleteDocument(int id)
        {
            var result = _mapper.Map<List<DocumentDto>>(_documentService.DeleteDocument(id));
            if (result is null)
                return NotFound("Invalid id, try again.");
            return Ok(result);
        }
    }
}
