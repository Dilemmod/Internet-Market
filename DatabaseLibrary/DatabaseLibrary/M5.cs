namespace DatabaseLibrary
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class M5 : DbContext
    {
        public M5()
            : base("name=M5")
        {
        }
        public virtual DbSet<UsersLogin> UsersLogins { get; set; }
        public virtual DbSet<CustomerInformation> CustomersInformations { get; set; }
        public virtual DbSet<MenedjerInformation> MenedjersInformations { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Characteristic> Characteristics { get; set; }
        public virtual DbSet<ProductOrder> ProductOrders { get; set; }
    }
}