using AppleAppRequest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace campus_technology_server.AppleAppRequest
{
    public class AppleAppRequestContext : DbContext
    {
        public AppleAppRequestContext(DbContextOptions<AppleAppRequestContext> options)
             : base(options)
        {

        }
        public DbSet<AppleAppRequestModel> AppleAppRequests { get; set; }
        public DbSet<AppleAppApplicationModel> AppleAppApplications { get; set; }
        public DbSet<AppleAppVendorModel> AppleAppVendors{ get; set; }
        public DbSet<AppleAppDeviceModel> AppleAppDevices { get; set; }
        public DbSet<AppleAppApproverModel> AppleAppApprovers { get; set; }
        public DbSet<AppleAppRejectReasonModel> AppleAppRejectReasons { get; set; }
        public DbSet<AppleAppRequestedApplicationModel> AppleAppRequestedApplications{ get; set; }
        public DbSet<AppleAppRequestedDeviceModel> AppleAppRequestedDevices { get; set; }
    }
}
