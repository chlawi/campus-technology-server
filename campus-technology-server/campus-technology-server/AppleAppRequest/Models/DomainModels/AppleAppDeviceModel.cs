using Shared;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppleAppRequest.Models
{
    public class AppleAppDeviceModel : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string AssetTag { get; set; }
        public List<AppleAppRequestModel> AppleAppRequests { get; set; } = new List<AppleAppRequestModel>();
    }
}
