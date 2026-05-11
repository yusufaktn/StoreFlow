using Microsoft.EntityFrameworkCore;
using StoreFlow.Entity;

namespace StoreFlow.Context
{
    public class MyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server =DESKTOP-1623\\SA;initial catalog =StoreFlowDb;integrated Security=true; trust server certificate=true;");
        }



        // Bu kısımda classlarımızın Sql üzerndeki karşılıklarını belirtiyoruz.
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<StockMovement> StockMovements { get; set; }
    }
}
