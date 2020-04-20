using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.Helpers
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Client> Client { get; set; }
        public DbSet<ClientMachine> ClientMachine { get; set; }
        public DbSet<Machine> Machine { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<OperationProductEntry> OperationProductEntry { get; set; }
        public DbSet<OperationProductOutput> OperationProductOutput { get; set; }
        public DbSet<Page> Page { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<Provider> Provider { get; set; }
        public DbSet<PurchaseDetail> PurchaseDetail { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrder { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<RolePage> RolePage { get; set; }
        public DbSet<StatusMachine> StatusMachine { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
    }
}