using System;

namespace Shared
{
    abstract public class Request : Entity
    {
        public string RequesterId { get; set; }
        public int ApproverId { get; set; }
        public StatusType Status { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string ProviderId { get; set; }
    }

    public enum StatusType
    {
        Requested,
        Approved,
        Assigned,
        Completed
    }
}
