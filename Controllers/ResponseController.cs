using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StepIntoHelp.Data;
using StepIntoHelp.Models;

namespace StepIntoHelp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResponsesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ResponsesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Response>> CreateResponse(Response response)
        {
            response.RespondedAt = DateTime.UtcNow;
            _context.Responses.Add(response);

            var helpRequest = await _context.HelpRequests.FindAsync(response.HelpRequestId);
            if (helpRequest != null)
            {
                helpRequest.Status = HelpRequestStatus.Completed;
            }

            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetResponse), new { id = response.Id }, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetResponse(int id)
        {
            var response = await _context.Responses
                .Include(r => r.HelpRequest)
                .Include(r => r.Organization)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (response == null)
            {
                return NotFound();
            }
            return response;
        }
    }
}