namespace StoreFlow.Entity
{
    public class Category:BaseEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName{ get; set; }


        public List<Product> Products { get; set; }

    }
}
