using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace campus_technology_server.Shared
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
