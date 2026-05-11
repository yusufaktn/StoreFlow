namespace StoreFlow.Entity
{
    public class Product:BaseEntity
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int? SupplierId { get; set; }       // Tedarikçi
        public Supplier? Supplier { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductStock { get; set; }
        public int MinStockLevel { get; set; } = 5; // Minimum stok uyarı eşiği
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
        public List<StockMovement> StockMovements { get; set; }
    }
}
