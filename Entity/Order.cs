using StoreFlow.Entity.Enum;

namespace StoreFlow.Entity
{
    public class Order:BaseEntity
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public decimal TotalPrice { get; set; }       // Siparişin toplam fiyatı
        public int Total_Product_Count { get; set; }  // Toplam ürün sayısı
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;
        public PaymentMethod PaymentMethod { get; set; } = PaymentMethod.Cash;
        public string? ShippingAddress { get; set; }  // Teslimat adresi
        public string? Notes { get; set; }            // Sipariş notu

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
