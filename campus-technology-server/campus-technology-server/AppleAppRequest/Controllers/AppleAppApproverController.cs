using AppleAppRequest.Models;
using campus_technology_server.AppleAppRequest;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_playground_project.Controllers
{
    [Route("v1/apple-app-approvers")]
    [ApiController]
    public class AppleAppApproverController : ControllerBase
    {
        private readonly AppleAppRequestContext _context;

        public AppleAppApproverController(AppleAppRequestContext context)
        {
            _context = context;
        }

        // GET: api/AppleAppApproverApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppleAppApproverModel>>> GetAppleAppApprovers()
        {
            return await _context.AppleAppApprovers.Where(approver => approver.IsActive == true).ToListAsync();
        }

        // GET: api/AppleAppApproverApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppleAppApproverModel>> GetAppleAppApproverModel(long id)
        {
            var appleAppApproverModel = await _context.AppleAppApprovers.FindAsync(id);

            if (appleAppApproverModel == null || appleAppApproverModel.IsActive == false)
            {
                return NotFound();
            }

            return appleAppApproverModel;
        }

        // PUT: api/AppleAppApproverApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppleAppApproverModel(long id, AppleAppApproverModel appleAppApproverModel)
        {
            if (id != appleAppApproverModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(appleAppApproverModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppleAppApproverModelExists(id))
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

        // POST: api/AppleAppApproverApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AppleAppApproverModel>> PostAppleAppApproverModel(AppleAppApproverModel appleAppApproverModel)
        {
            _context.AppleAppApprovers.Add(appleAppApproverModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppleAppApproverModel", new { id = appleAppApproverModel.Id }, appleAppApproverModel);
        }

        // DELETE: api/AppleAppApproverApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppleAppApproverModel(long id)
        {
            var appleAppApproverModel = await _context.AppleAppApprovers.FindAsync(id);
            if (appleAppApproverModel == null)
            {
                return NotFound();
            }

            appleAppApproverModel.IsActive = false;
            _context.AppleAppApprovers.Update(appleAppApproverModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AppleAppApproverModelExists(long id)
        {
            return _context.AppleAppApprovers.Any(e => e.Id == id);
        }
    }
}
