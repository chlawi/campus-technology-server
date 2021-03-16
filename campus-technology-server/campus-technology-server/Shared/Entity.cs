namespace Shared
{
    abstract public class Entity
    {
        public string ReferenceId { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
