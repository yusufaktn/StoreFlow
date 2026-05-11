namespace StoreFlow.Entity.Enum
{
    public enum  OrderStatus
    {
        Pending = 0,        // Sipariş oluşturuldu, henüz işleme alınmadı
        Confirmed = 1,      // Onaylandı (stok / ödeme OK)
        Processing = 2,     // Hazırlanıyor / işleniyor
        Shipped = 3,        // Kargoya verildi
        Delivered = 4,      // Müşteriye ulaştı
        Cancelled = 5       // İptal edildi
    }
}
