using AppleAppRequest.Models;
using campus_technology_server.AppleAppRequest;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppleAppRequest.Controllers
{
    [Route("v1/apple-app-administrators")]
    [ApiController]
    public class AppleAppAdminstratorController : ControllerBase
    {
        private readonly AppleAppRequestContext context;

        public AppleAppAdminstratorController(AppleAppRequestContext context)
        {
            this.context = context;
        }

        // GET: api/AppleAppAdministratorApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppleAppAdministratorModel>>> GetAppleAppAdministrators()
        {
            return await context.AppleAppAdministrators.Where(administrator => administrator.IsActive == true).OrderByDescending(administrator => administrator.Id).ToListAsync();
        }

        // GET: api/AppleAppAdministratorApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppleAppAdministratorModel>> GetAppleAppAdministratorModel(int id)
        {
            var appleAppAdministratorModel = await context.AppleAppAdministrators.FindAsync(id);

            if (appleAppAdministratorModel == null || appleAppAdministratorModel.IsActive == false)
            {
                return NotFound();
            }

            return appleAppAdministratorModel;
        }

        // PUT: api/AppleAppAdministratorApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppleAppAdministratorModel(long id, AppleAppAdministratorModel appleAppAdministratorModel)
        {
            if (id != appleAppAdministratorModel.Id)
            {
                return BadRequest();
            }

            context.Entry(appleAppAdministratorModel).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppleAppAdministratorModelExists(id))
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

        // POST: api/AppleAppAdministratorApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AppleAppAdministratorModel>> PostAppleAppAdministratorModel(AppleAppAdministratorModel appleAppAdministratorModel)
        {
            context.AppleAppAdministrators.Add(appleAppAdministratorModel);

            await context.SaveChangesAsync();

            return CreatedAtAction("GetAppleAppAdministratorModel", new { id = appleAppAdministratorModel.Id }, appleAppAdministratorModel);
        }

        // DELETE: api/AppleAppAdministratorApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppleAppAdministratorModel(int id)
        {
            var appleAppAdministratorModel = await context.AppleAppAdministrators.FindAsync(id);
            if (appleAppAdministratorModel == null)
            {
                return NotFound();
            }

            context.AppleAppAdministrators.Remove(appleAppAdministratorModel);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool AppleAppAdministratorModelExists(long id)
        {
            return context.AppleAppAdministrators.Any(e => e.Id == id);
        }
    }
}
