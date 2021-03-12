using Shared;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppleAppRequest.Models
{
    public class AppleAppApplicationModel : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Vendor { get; set; }
        public int? Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public List<AppleAppRequestModel> AppleAppRequest { get; set; } = new List<AppleAppRequestModel>();
    }
}
