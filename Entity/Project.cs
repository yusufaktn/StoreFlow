using StoreFlow.Entity.Enum;

namespace StoreFlow.Entity
{
    public class Project : BaseEntity
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string AssignedPerson { get; set; }
        public ProjectPriority Priority { get; set; }
    }
}
