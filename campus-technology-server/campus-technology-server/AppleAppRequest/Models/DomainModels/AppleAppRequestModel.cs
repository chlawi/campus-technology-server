using Shared;
using System;
using System.Collections.Generic;

namespace AppleAppRequest.Models
{
    public class AppleAppRequestModel : Request
    {
        public int Id { get; set; }
        public SubscriptionType SubscriptionType { get; set; }
        public DateTime? CompletionDate { get; set; }
        public int? RejectReasonId { get; set; }
        public ICollection<AppleAppRequestedApplicationModel> RequestedApplications { get; set; }
        public ICollection<AppleAppRequestedDeviceModel> RequestedDevices { get; set; }
    }

    public enum SubscriptionType
    {
        Free,
        Paid
    }
}
