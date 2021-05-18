using Shared;

namespace AppleAppRequest.Models
{
    public class AppleAppAdministratorModel : Entity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public AppleAppAdministratorType AdministratorType { get; set; }
    }

    public enum AppleAppAdministratorType
    {
        Managerial,
        Technical,
        Functional,
        Clerical
    }
}
