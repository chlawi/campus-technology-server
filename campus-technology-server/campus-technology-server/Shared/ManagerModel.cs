using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ManagerModel: Entity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public ServiceType ServiceType{ get; set; }
    }

    public enum ServiceType
    {
        Developer,
        MonroeOneBoces,
        CampusTechnology
    }
}
