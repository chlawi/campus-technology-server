using Shared;
using System.ComponentModel.DataAnnotations;

namespace AppleAppRequest.Models
{
    public class AppleAppApproverModel: Entity
    {
        public int Id { get; set; }
        [EmailAddress]
        public string EmailAddress { get; set; }
    }
}
