using System;
using System.Collections.Generic;

namespace AppleAppRequest.Models
{
    public class AppleAppRequestEditView
    {
        public int Id { get; set; }
        public string ReferenceId { get; set; }
        public string RequesterId { get; set; }
        public int ApproverId { get; set; }
        public StatusType Status { get; set; }
        public int? ProviderId { get; set; }
        public int? RejectReasonId { get; set; }
        public List<AppleAppRequestedApplicationEditView> RequestedApplications { get; set; }
        public List<AppleAppRequestedDeviceEditView> RequestedDevices { get; set; }
    }


   
    public enum StatusType
    {
        Requested,
        Approved,
        Rejected,
        Active,
        Completed
    }
}
