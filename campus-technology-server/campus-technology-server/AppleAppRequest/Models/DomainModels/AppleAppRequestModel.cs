using Shared;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppleAppRequest.Models
{
    public class AppleAppRequestModel : Request
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public AppleAppApproverModel AppleAppApprover { get; set; }
        public List<AppleAppApplicationModel> AppleAppApplications { get; set; } = new List<AppleAppApplicationModel>();
        public List<AppleAppDeviceModel> AppleAppDevices { get; set; } = new List<AppleAppDeviceModel>();
    }
}
