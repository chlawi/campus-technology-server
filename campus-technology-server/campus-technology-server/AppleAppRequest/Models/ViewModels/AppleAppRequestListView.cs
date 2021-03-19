using System;

namespace AppleAppRequest.Models
{
    public class AppleAppRequestListView
    {
        public int Id { get; set; }
        public string ReferenceId { get; set; }
        public string RequesterId { get; set; }
        public string ApproverId { get; set; }
        public StatusType Status { get; set; }
        public DateTime Date { get; set; } 
        public SubscriptionType SubscriptionType { get; set; }
    }
}
