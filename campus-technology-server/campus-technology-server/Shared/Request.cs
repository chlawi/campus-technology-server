using System;

namespace Shared
{
    abstract public class Request : Entity
    {        public DateTime Date { get; set; }
        public string Requester { get; set; }
        public string Approver { get; set; }
        public StatusType Status { get; set; }
        public string? Provider { get; set; }
    }

    public enum StatusType
    {
        Requested,
        Approved,
        Assigned,
        Completed
    }
}
