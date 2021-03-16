using AppleAppRequest.Models;
using campus_technology_server.AppleAppRequest;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_playground_project.Controllers
{
    [Route("v1/apple-app-reject-reason")]
    [ApiController]
    public class AppleAppRejectReasonController : ControllerBase
    {
        private readonly AppleAppRequestContext _context;

        public AppleAppRejectReasonController(AppleAppRequestContext context)
        {
            _context = context;
        }

        // GET: api/AppleAppRejectReason
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppleAppRejectReasonModel>>> GetAppleAppRejectReasons()
        {
            return await _context.AppleAppRejectReasons.Where(rejectReason => rejectReason.IsActive == true).ToListAsync();
        }

        // GET: api/AppleAppRejectReason/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppleAppRejectReasonModel>> GetAppleAppRejectReasonModel(long id)
        {
            var appleAppRejectReasonModel = await _context.AppleAppRejectReasons.FindAsync(id);

            if (appleAppRejectReasonModel == null || appleAppRejectReasonModel.IsActive == false)
            {
                return NotFound();
            }

            return appleAppRejectReasonModel;
        }

        // PUT: api/AppleAppRejectReason/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppleAppRejectReasonModel(long id, AppleAppRejectReasonModel appleAppRejectReasonModel)
        {
            if (id != appleAppRejectReasonModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(appleAppRejectReasonModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppleAppRejectReasonModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AppleAppRejectReason
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AppleAppRejectReasonModel>> PostAppleAppRejectReasonModel(AppleAppRejectReasonModel appleAppRejectReasonModel)
        {
            _context.AppleAppRejectReasons.Add(appleAppRejectReasonModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppleAppRejectReasonModel", new { id = appleAppRejectReasonModel.Id }, appleAppRejectReasonModel);
        }

        // DELETE: api/AppleAppRejectReason/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppleAppRejectReasonModel(long id)
        {
            var appleAppRejectReasonModel = await _context.AppleAppRejectReasons.FindAsync(id);
            if (appleAppRejectReasonModel == null)
            {
                return NotFound();
            }

            appleAppRejectReasonModel.IsActive = false;
            _context.AppleAppRejectReasons.Update(appleAppRejectReasonModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AppleAppRejectReasonModelExists(long id)
        {
            return _context.AppleAppRejectReasons.Any(e => e.Id == id);
        }
    }
}
