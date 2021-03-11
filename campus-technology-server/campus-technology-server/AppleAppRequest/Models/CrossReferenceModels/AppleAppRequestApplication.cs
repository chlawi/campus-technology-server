namespace AppleAppRequest.Models
{
    public class AppleAppRequestApplication
    {
        public int RequestId { get; set; }
        public int ApplicationId { get; set; }
        public AppleAppRequestModel Request { get; set; }
        public AppleAppApplicationModel Application { get; set; }
    }
}
