using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace campus_technology_server.Shared
{
    abstract public class Entity
    {
        public int Id { get; set; }
        public string ReferenceId { get; set; }
        public bool IsActive { get; set; }
    }
}
