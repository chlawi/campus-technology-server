using Shared;

namespace AppleAppRequest.Models
{
    public class AppleAppRequestModel : Request
    {
        public int Id { get; set; }
        public string ApplicationIds { get; set; }
        public string DeviceIds { get; set; }
        public int? ApproverId { get; set; }
        public int? RejectReasonId { get; set; }
    }
}
