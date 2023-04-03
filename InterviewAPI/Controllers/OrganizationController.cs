using AutoMapper;
using InterviewAPI.Dto;
using InterviewAPI.Models;
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
        public IActionResult AddOrganization([FromBody] OrganizationDto organizationAdd)
        {
            if (organizationAdd is null)
                return BadRequest(ModelState);

            if (_organizationService.OrganizationExists(organizationAdd.Id))
                return NotFound("Organization already exists by that id.");

            var organizationMap = _mapper.Map<Organization>(organizationAdd);

            if (!_organizationService.AddOrganization(organizationMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving.");
                return StatusCode(500, ModelState);
            }

            return Ok("Succesfully added a organization.");
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
        public IActionResult UpdateOrganization([FromBody] OrganizationDto organization)
        {
            if (organization is null)
                return BadRequest(ModelState);

            if (!_organizationService.OrganizationExists(organization.Id))
                return NotFound("Organization doesn't exist.");

            var organizationMap = _mapper.Map<Organization>(organization);

            if (!_organizationService.UpdateOrganization(organizationMap))
            {
                ModelState.AddModelError("", "Something went wrong updating organization");
                return StatusCode(500, ModelState);
            }

            return Ok("Organization succesfully updated.");
        }

        [HttpDelete("organizations/{id}")]
        public IActionResult DeleteOrganization(int id)
        {
            if (!_organizationService.OrganizationExists(id))
                return NotFound("Organization doesn't exist.");

            var organizationToDelete = _organizationService.GetOrganization(id);

            if (!_organizationService.DeleteOrganization(organizationToDelete))
            {
                ModelState.AddModelError("", "Something went wront deleting organization");
                return StatusCode(500, ModelState);
            }

            return Ok("Organization succesfully deleted.");
        }
    }
}
