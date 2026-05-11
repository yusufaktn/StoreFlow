namespace StoreFlow.Entity
{
    public class Supplier : BaseEntity
    {
        public int SupplierId { get; set; }
        public string CompanyName { get; set; }
        public string ContactPerson { get; set; } // İletişim kişisi
        public string Email { get; set; }
        public string Phone { get; set; }
        public string? Address { get; set; }

        public List<Product> Products { get; set; }
    }
}
