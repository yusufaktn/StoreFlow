namespace StoreFlow.Entity
{
    public class Customer:BaseEntity
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string? District { get; set; }
        public decimal Balance { get; set; }
        public string? Image_URL { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? CompanyName { get; set; }  // Kurumsal müşteri adı
        public string? TaxNumber { get; set; }    // Vergi numarası
        public string? Address { get; set; }      // Tam adres

        public List<Order> Orders { get; set; }
    }
}

