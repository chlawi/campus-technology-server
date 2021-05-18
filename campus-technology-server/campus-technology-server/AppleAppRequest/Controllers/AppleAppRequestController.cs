using AppleAppRequest.Models;
using AutoMapper;
using campus_technology_server.AppleAppRequest;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppleAppRequest.Controllers
{
    [Route("v1/apple-app-requests")]
    [ApiController]
    public class AppleAppRequestController : ControllerBase
    {
        private readonly AppleAppRequestContext context;

        private readonly IMapper Mapper;

        public AppleAppRequestController(AppleAppRequestContext context, IMapper mapper)
        {
            this.context = context;
            Mapper = mapper;
        }

        // GET: api/AppleAppRequest
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppleAppRequestListView>>> GetAppleAppRequests()
        {
            return Mapper.Map<AppleAppRequestListView[]>(await this.context.AppleAppRequests.AsNoTracking().Where(request => request.IsActive == true).OrderByDescending(request => request.Id).ToListAsync());
        }

        // GET: api/AppleAppRequest/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppleAppRequestModel>> GetAppleAppRequestModel(int id, string referenceId = null)
        {
            AppleAppRequestModel appleAppRequestModel = null;
            //var appleAppRequestModel = await this.context.AppleAppRequests.FindAsync(id);
            //this.context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            if (referenceId != null)
            {
                appleAppRequestModel = await this.context.AppleAppRequests.AsNoTracking().Include(request => request.RequestedApplications).Include(request => request.RequestedDevices).FirstOrDefaultAsync(request => request.ReferenceId == referenceId && request.IsActive == true);
            }
            else
            {
                appleAppRequestModel = await this.context.AppleAppRequests.AsNoTracking().Include(request => request.RequestedApplications).Include(request => request.RequestedDevices).FirstOrDefaultAsync(request => request.Id == id && request.IsActive == true);
            }

            if (appleAppRequestModel == null)
            {
                return NotFound();
            }

            //await this.context.Entry(appleAppRequestModel).Collection(request => request.RequestedDevices).EntityEntry.Collection(request => request.RequestedApplications).LoadAsync();
            //await this.context.Entry(appleAppRequestModel).Collection(request => request.RequestedDevices).LoadAsync();
            return appleAppRequestModel;
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchAppleAppRequestModel(int id, [FromBody] JsonPatchDocument<AppleAppRequestModel> patchDocument)
        {
            var appleAppRequest = await this.context.AppleAppRequests.Include(request => request.RequestedApplications).Include(request => request.RequestedDevices).FirstOrDefaultAsync(request => request.Id == id);
            patchDocument.ApplyTo(appleAppRequest, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //this.context.Entry(appleAppRequest).State = EntityState.Modified;

            try
            {

                await this.context.SaveChangesAsync();
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
            catch (Exception ex)
            {
                Console.Write("Error");
            }

            return NoContent();
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

            this.context.Entry(appleAppRequestModel).State = EntityState.Modified;

            try
            {
                await this.context.SaveChangesAsync();
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
                if (!this.context.AppleAppApplications.Any(a => a.Name.ToUpper() == requestedApplication.Name.ToUpper()))
                {
                    var newAppleAppApplication = new AppleAppApplicationModel { Name = requestedApplication.Name, ReferenceId = Guid.NewGuid().ToString() };
                    this.context.AppleAppApplications.Add(newAppleAppApplication);
                }

                if (!this.context.AppleAppVendors.Any(v => v.Name.ToUpper() == requestedApplication.Vendor.ToUpper()))
                {
                    var newAppleAppVendor = new AppleAppVendorModel { Name = requestedApplication.Vendor, ReferenceId = Guid.NewGuid().ToString() };
                    this.context.AppleAppVendors.Add(newAppleAppVendor);
                }
            });

            appleAppRequestView.RequestedDevices.ForEach(requestedDevice =>
            {
                if (!this.context.AppleAppDevices.Any(d => d.AssetTag.ToUpper() == requestedDevice.AssetTag.ToUpper()))
                {
                    var newAppleAppDevice = new AppleAppDeviceModel { AssetTag = requestedDevice.AssetTag, ReferenceId = Guid.NewGuid().ToString() };
                    this.context.AppleAppDevices.Add(newAppleAppDevice);
                }
            });

            this.context.AppleAppRequests.Add(appleAppRequest);
            await this.context.SaveChangesAsync();

            return CreatedAtAction("GetAppleAppRequestModel", new { id = appleAppRequest.Id }, appleAppRequest);
        }

        // DELETE: api/AppleAppRequest/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppleAppRequestModel(long id)
        {
            var appleAppRequestModel = await this.context.AppleAppRequests.FindAsync(id);
            if (appleAppRequestModel == null)
            {
                return NotFound();
            }

            appleAppRequestModel.IsActive = false;
            this.context.AppleAppRequests.Update(appleAppRequestModel);
            await this.context.SaveChangesAsync();

            return NoContent();
        }

        private bool AppleAppRequestModelExists(long id)
        {
            return this.context.AppleAppRequests.Any(e => e.Id == id);
        }
    }
}
