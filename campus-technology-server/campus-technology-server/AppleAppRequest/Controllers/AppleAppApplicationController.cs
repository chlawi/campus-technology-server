using AppleAppRequest.Models;
using campus_technology_server.AppleAppRequest;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_playground_project.Controllers
{
    [Route("v1/apple-app-applications")]
    [ApiController]
    public class AppleAppApplicationController : ControllerBase
    {
        private readonly AppleAppRequestContext _context;

        public AppleAppApplicationController(AppleAppRequestContext context)
        {
            _context = context;
        }

        // GET: api/AppleAppApplication
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppleAppApplicationModel>>> GetAppleAppApplications()
        {
            return await _context.AppleAppApplications.Where(application => application.IsActive == true).ToListAsync();
        }

        // GET: api/AppleAppApplication/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppleAppApplicationModel>> GetAppleAppApplicationModel(long id)
        {
            var appleAppApplicationModel = await _context.AppleAppApplications.FindAsync(id);

            if (appleAppApplicationModel == null || appleAppApplicationModel.IsActive == false)
            {
                return NotFound();
            }

            return appleAppApplicationModel;
        }

        // PUT: api/AppleAppApplication/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppleAppApplicationModel(long id, AppleAppApplicationModel appleAppApplicationModel)
        {
            if (id != appleAppApplicationModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(appleAppApplicationModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppleAppApplicationModelExists(id))
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

        // POST: api/AppleAppApplication
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AppleAppApplicationModel>> PostAppleAppApplicationModel(AppleAppApplicationModel appleAppApplicationModel)
        {
            _context.AppleAppApplications.Add(appleAppApplicationModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppleAppApplicationModel", new { id = appleAppApplicationModel.Id }, appleAppApplicationModel);
        }

        // DELETE: api/AppleAppApplication/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppleAppApplicationModel(long id)
        {
            var appleAppApplicationModel = await _context.AppleAppApplications.FindAsync(id);
            if (appleAppApplicationModel == null)
            {
                return NotFound();
            }

            appleAppApplicationModel.IsActive = false;
            _context.AppleAppApplications.Update(appleAppApplicationModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AppleAppApplicationModelExists(long id)
        {
            return _context.AppleAppApplications.Any(e => e.Id == id);
        }
    }
}
