using StoreFlow.Entity.Enum;

namespace StoreFlow.Entity
{
    public class Expense : BaseEntity
    {
        public int ExpenseId { get; set; }
        public string Title { get; set; }            // Gider açıklaması
        public decimal Amount { get; set; }          // Tutar
        public DateTime ExpenseDate { get; set; }
        public ExpenseCategory ExpenseCategory { get; set; }
    }
}
