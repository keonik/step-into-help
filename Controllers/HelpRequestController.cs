using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StepIntoHelp.Data;
using StepIntoHelp.Models;

namespace StepIntoHelp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelpRequestsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HelpRequestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<HelpRequest>> CreateHelpRequest(HelpRequest helpRequest)
        {
            helpRequest.CreatedAt = DateTime.UtcNow;
            helpRequest.Status = HelpRequestStatus.Pending;
            _context.HelpRequests.Add(helpRequest);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetHelpRequest), new { id = helpRequest.Id }, helpRequest);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HelpRequest>> GetHelpRequest(int id)
        {
            var helpRequest = await _context.HelpRequests
                .Include(hr => hr.User)
                .FirstOrDefaultAsync(hr => hr.Id == id);

            if (helpRequest == null)
            {
                return NotFound();
            }
            return helpRequest;
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<HelpRequest>>> GetUserHelpRequests(int userId)
        {
            return await _context.HelpRequests
                .Where(hr => hr.UserId == userId)
                .ToListAsync();
        }
    }
}