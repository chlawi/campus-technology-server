using AppleAppRequest.Models;
using campus_technology_server.AppleAppRequest;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppleAppRequest.Controllers
{
    [Route("v1/apple-app-devices")]
    [ApiController]
    public class AppleAppDeviceController : ControllerBase
    {
        private readonly AppleAppRequestContext _context;

        public AppleAppDeviceController(AppleAppRequestContext context)
        {
            _context = context;
        }

        // GET: api/AppleAppDevice
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppleAppDeviceModel>>> GetAppleAppDevices()
        {
            return await _context.AppleAppDevices.Where(device => device.IsActive == true).ToListAsync();
        }

        // GET: api/AppleAppDevice/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppleAppDeviceModel>> GetAppleAppDeviceModel(long id)
        {
            var appleAppDeviceModel = await _context.AppleAppDevices.FindAsync(id);

            if (appleAppDeviceModel == null || appleAppDeviceModel.IsActive == false)
            {
                return NotFound();
            }

            return appleAppDeviceModel;
        }

        // PUT: api/AppleAppDevice/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppleAppDeviceModel(long id, AppleAppDeviceModel appleAppDeviceModel)
        {
            if (id != appleAppDeviceModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(appleAppDeviceModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppleAppDeviceModelExists(id))
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

        // POST: api/AppleAppDevice
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AppleAppDeviceModel>> PostAppleAppDeviceModel(AppleAppDeviceModel appleAppDeviceModel)
        {
            _context.AppleAppDevices.Add(appleAppDeviceModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppleAppDeviceModel", new { id = appleAppDeviceModel.Id }, appleAppDeviceModel);
        }

        // DELETE: api/AppleAppDevice/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppleAppDeviceModel(long id)
        {
            var appleAppDeviceModel = await _context.AppleAppDevices.FindAsync(id);
            if (appleAppDeviceModel == null)
            {
                return NotFound();
            }
    
            appleAppDeviceModel.IsActive = false;
            _context.AppleAppDevices.Update(appleAppDeviceModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AppleAppDeviceModelExists(long id)
        {
            return _context.AppleAppDevices.Any(e => e.Id == id);
        }
    }
}
