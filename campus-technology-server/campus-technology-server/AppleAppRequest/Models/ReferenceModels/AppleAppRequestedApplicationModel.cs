using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppleAppRequest.Models
{
    public class AppleAppRequestedApplicationModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Vendor { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? Quantity { get; set; }
        public int AppleAppRequestId { get; set; }
        public AppleAppRequestModel AppleAppRequest { get; set; }
    }
}
