using AppleAppRequest.Models;
using AppleAppRequest.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AppleAppRequest.Controllers
{
    [Route("v1/apple-app-requests")]
    [ApiController]
    public class AppleAppRequestController : ControllerBase
    {
        private readonly IAppleAppRequestService appleAppRequestService;

        public AppleAppRequestController(IAppleAppRequestService appleAppRequestService)
        {
            this.appleAppRequestService = appleAppRequestService;
        }

        public IActionResult Get()
        {
            var response = new List<AppleAppRequestListView>();
            return Ok(response);
        }

        public IActionResult Get(int Id)
        {
            var response = new AppleAppRequestDetailView();
            return Ok(response);
        }

        public IActionResult Post([FromBody] AppleAppRequestEditView request)
        {
            var response = new AppleAppRequestEditView();
            return Ok(response);
        }

        public IActionResult Put(int Id, [FromBody] AppleAppRequestEditView request)
        {
            return Ok();
        }

        public IActionResult Patch(int Id, [FromBody] JsonPatchDocument<AppleAppRequestEditView> request)
        {
            return Ok();
        }

        public IActionResult Delete(int Id)
        {
            return Ok();
        }
    }
}
