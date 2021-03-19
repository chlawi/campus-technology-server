using AppleAppRequest.Models;
using AutoMapper;
using campus_technology_server.AppleAppRequest;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_playground_project.Controllers
{
    [Route("v1/apple-app-requests")]
    [ApiController]
    public class AppleAppRequestController : ControllerBase
    {
        private readonly AppleAppRequestContext _context;

        public IMapper Mapper { get; }

        public AppleAppRequestController(AppleAppRequestContext context, IMapper mapper)
        {
            _context = context;
            Mapper = mapper;
        }

        // GET: api/AppleAppRequest
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppleAppRequestListView>>> GetAppleAppRequests()
        {
            return Mapper.Map<AppleAppRequestListView[]>(await _context.AppleAppRequests.Where(request => request.IsActive == true).ToListAsync());
        }

        // GET: api/AppleAppRequest/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppleAppRequestModel>> GetAppleAppRequestModel(long id)
        {
            var appleAppRequestModel = await _context.AppleAppRequests.FindAsync(id);

            if (appleAppRequestModel == null || appleAppRequestModel.IsActive == false)
            {
                return NotFound();
            }

            return appleAppRequestModel;
        }

        // PUT: api/AppleAppRequest/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppleAppRequestModel(long id, AppleAppRequestModel appleAppRequestModel)
        {
            if (id != appleAppRequestModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(appleAppRequestModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppleAppRequestModelExists(id))
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

        // POST: api/AppleAppRequest
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AppleAppRequestModel>> PostAppleAppRequestModel(AppleAppRequestEditView appleAppRequestView)
        {
            var appleAppRequest = Mapper.Map<AppleAppRequestModel>(appleAppRequestView);

            appleAppRequestView.RequestedApplications.ForEach(requestedApplication =>
            {
                if (!_context.AppleAppApplications.Any(a => a.Name.ToUpper() == requestedApplication.Name.ToUpper()))
                {
                    var newAppleAppApplication = new AppleAppApplicationModel { Name = requestedApplication.Name, ReferenceId = Guid.NewGuid().ToString() };
                    _context.AppleAppApplications.Add(newAppleAppApplication);
                }
            });

            appleAppRequestView.RequestedDevices.ForEach(requestedDevice =>
            {
                if (!_context.AppleAppDevices.Any(d => d.AssetTag.ToUpper() == requestedDevice.AssetTag.ToUpper()))
                {
                    var newAppleAppDevice = new AppleAppDeviceModel { AssetTag = requestedDevice.AssetTag, ReferenceId = Guid.NewGuid().ToString() };
                    _context.AppleAppDevices.Add(newAppleAppDevice);
                }
            });

            _context.AppleAppRequests.Add(appleAppRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppleAppRequestModel", new { id = appleAppRequest.Id }, appleAppRequest);
        }

        // DELETE: api/AppleAppRequest/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppleAppRequestModel(long id)
        {
            var appleAppRequestModel = await _context.AppleAppRequests.FindAsync(id);
            if (appleAppRequestModel == null)
            {
                return NotFound();
            }

            appleAppRequestModel.IsActive = false;
            _context.AppleAppRequests.Update(appleAppRequestModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AppleAppRequestModelExists(long id)
        {
            return _context.AppleAppRequests.Any(e => e.Id == id);
        }
    }
}
