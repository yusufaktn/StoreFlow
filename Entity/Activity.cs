namespace StoreFlow.Entity
{
    public class Activity:BaseEntity
    {
        public int ActivityId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TimeOnly ActivityTime{ get; set; }
    }
}
