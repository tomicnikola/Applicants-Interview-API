using AutoMapper;
using InterviewAPI.Dto;
using InterviewAPI.Services.OrganizationService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterviewAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationService _organizationService;
        private readonly IMapper _mapper;

        public OrganizationController(IOrganizationService organizationService, IMapper mapper)
        {
            _organizationService = organizationService;
            _mapper = mapper;
        }

        [HttpPost("organizations")]
        public IActionResult AddOrganization(Organization organization)
        {
            var result = _mapper.Map<List<OrganizationDto>>(_organizationService.AddOrganization(organization));
            return Ok(result);
        }

        [HttpGet("organizations")]
        public IActionResult GetOrganizations()
        {
            var result = _mapper.Map<List<OrganizationDto>>(_organizationService.GetOrganizations());
            return Ok(result);
        }

        [HttpGet("organizations/{id}")]
        public IActionResult GetOrganization(int id)
        {
            var result = _mapper.Map<OrganizationDto>(_organizationService.GetOrganization(id));
            if (result is null)
                return NotFound("Invalid id, try again.");
            return Ok(result);
        }

        [HttpPut("organizations")]
        public IActionResult UpdateOrganization(Organization organization)
        {
            var result = _mapper.Map<List<OrganizationDto>>(_organizationService.UpdateOrganization(organization));
            if (result is null)
                return NotFound("Invalid id, try again.");
            return Ok(result);
        }

        [HttpDelete("organizations/{id}")]
        public IActionResult DeleteOrganization(int id)
        {
            var result = _mapper.Map<List<OrganizationDto>>(_organizationService.DeleteOrganization(id));
            if (result is null)
                return NotFound("Invalid id, try again.");
            return Ok(result);
        }
    }
}
