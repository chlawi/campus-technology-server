using campus_technology_server.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace campus_technology_server.Controllers
{
    public class AppleAppRequestController : Controller
    {
        private readonly IAppleAppRequestService appleAppRequestService;

        public AppleAppRequestController(IAppleAppRequestService appleAppRequestService)
        {
            this.appleAppRequestService = appleAppRequestService;
        }
    }
}
