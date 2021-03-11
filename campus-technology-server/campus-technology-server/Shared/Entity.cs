namespace Shared
{
    abstract public class Entity
    {
        public int Id { get; set; }
        public string ReferenceId { get; set; }
        public bool IsActive { get; set; }
    }
}
