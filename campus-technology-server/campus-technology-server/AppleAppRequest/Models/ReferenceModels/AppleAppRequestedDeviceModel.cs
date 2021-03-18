using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppleAppRequest.Models
{
    public class AppleAppRequestedDeviceModel: Entity
    {
        public int Id { get; set; }
        public string AssetTag { get; set; }
        public int AppleAppRequestId { get; set; }
        public AppleAppRequestModel AppleAppRequest { get; set; }
    }
}
