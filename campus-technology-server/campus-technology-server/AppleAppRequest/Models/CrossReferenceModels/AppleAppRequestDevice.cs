namespace AppleAppRequest.Models
{
    public class AppleAppRequestDevice
    {
        public int RequestId { get; set; }
        public int DeviceId { get; set; }
        public AppleAppRequestModel Request { get; set; } = new AppleAppRequestModel();
        public AppleAppDeviceModel Device { get; set; } = new AppleAppDeviceModel();
    }
}
