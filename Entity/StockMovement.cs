using StoreFlow.Entity.Enum;

namespace StoreFlow.Entity
{
    public class StockMovement : BaseEntity
    {
        public int StockMovementId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }              // Miktar
        public MovementType MovementType { get; set; } // Giriş mi Çıkış mı
        public string? Description { get; set; }       // Açıklama
        public DateTime MovementDate { get; set; }
    }
}
