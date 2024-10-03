using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StepIntoHelp.Data;
using StepIntoHelp.Models;

namespace StepIntoHelp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrganizationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrganizationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Organization>> CreateOrganization(Organization organization)
        {
            _context.Organizations.Add(organization);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetOrganization), new { id = organization.Id }, organization);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Organization>> GetOrganization(int id)
        {
            var organization = await _context.Organizations.FindAsync(id);
            if (organization == null)
            {
                return NotFound();
            }
            return organization;
        }

        [HttpGet("helprequests")]
        public async Task<ActionResult<IEnumerable<HelpRequest>>> GetPendingHelpRequests()
        {
            return await _context.HelpRequests
                .Where(hr => hr.Status == HelpRequestStatus.Pending)
                .ToListAsync();
        }
    }
}