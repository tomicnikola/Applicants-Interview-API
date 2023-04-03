using AutoMapper;
using InterviewAPI.Dto;
using InterviewAPI.Models;
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
        public IActionResult AddDocument([FromBody] DocumentDto documentAdd)
        {
            if (documentAdd is null)
                return BadRequest(ModelState);

            if (_documentService.DocumentExists(documentAdd.Id))
                return NotFound("Document already exists by that id.");

            var documentMap = _mapper.Map<Document>(documentAdd);

            if (!_documentService.AddDocument(documentMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving.");
                return StatusCode(500, ModelState);
            }

            return Ok("Succesfully added a document.");
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
        public IActionResult UpdateDocument([FromBody] DocumentDto document)
        {
            if (document is null)
                return BadRequest(ModelState);

            if (!_documentService.DocumentExists(document.Id))
                return NotFound("Document doesn't exist.");

            var documentMap = _mapper.Map<Document>(document);

            if (!_documentService.UpdateDocument(documentMap))
            {
                ModelState.AddModelError("", "Something went wrong updating document");
                return StatusCode(500, ModelState);
            }

            return Ok("Document succesfully updated.");
        }

        [HttpDelete("documents/{id}")]
        public IActionResult DeleteDocument(int id)
        {
            if (!_documentService.DocumentExists(id))
                return NotFound("Document doesn't exist.");

            var documentToDelete = _documentService.GetDocument(id);

            if (!_documentService.DeleteDocument(documentToDelete))
            {
                ModelState.AddModelError("", "Something went wront deleting document");
                return StatusCode(500, ModelState);
            }

            return Ok("Document succesfully deleted.");
        }
    }
}
