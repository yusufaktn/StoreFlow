namespace StoreFlow.Entity
{
    public class TodoItem : BaseEntity
    {
        public int TodoItemId { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; } = false;
    }
}
