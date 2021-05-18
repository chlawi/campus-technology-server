using AppleAppRequest.Models;
using campus_technology_server.AppleAppRequest;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace campus_technology_server.Shared
{
    [Route("v1/managers")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly AppleAppRequestContext context;

        public ManagerController(AppleAppRequestContext context)
        {
            this.context = context;
        }

        // GET: api/ManagerApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ManagerModel>>> GetManagers()
        {
            return await context.Managers.Where(manager => manager.IsActive == true).OrderByDescending(manager => manager.Id).ToListAsync();
        }

        // GET: api/ManagerApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ManagerModel>> GetManager(int id)
        {
            var manager = await context.Managers.FindAsync(id);

            if (manager == null || manager.IsActive == false)
            {
                return NotFound();
            }

            return manager;
        }

        // PUT: api/ManagerApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManager(long id, ManagerModel manager)
        {
            if (id != manager.Id)
            {
                return BadRequest();
            }

            context.Entry(manager).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManagerExists(id))
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

        // POST: api/ManagerApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ManagerModel>> PostManager(ManagerModel manager)
        {
            context.Managers.Add(manager);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetManager", new { id = manager.Id }, manager);
        }

        // DELETE: api/ManagerApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManager(int id)
        {
            var manager = await context.Managers.FindAsync(id);
            if (manager == null)
            {
                return NotFound();
            }

            manager.IsActive = false;
            context.Managers.Update(manager);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool ManagerExists(long id)
        {
            return context.Managers.Any(e => e.Id == id);
        }
    }
}
