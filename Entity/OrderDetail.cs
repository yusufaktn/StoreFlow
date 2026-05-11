namespace StoreFlow.Entity
{
    public class OrderDetail:BaseEntity
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public decimal Unit_Price { get; set; }      // Ürünün birim fiyatı (decimal)
        public int Unit_Product_Count { get; set; }  // Birim üründen kaç adet olduğu
    }
}
