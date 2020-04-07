namespace DatabaseLibrary
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class M3 : DbContext
    {
        public M3()
            : base("name=M3")
        {
        }

        public virtual DbSet<UsersLogin> UsersLogins { get; set; }
        public virtual DbSet<CustomerInformation> CustomersInformations { get; set; }
        public virtual DbSet<MenedjerInformation> MenedjersInformations { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Characteristic> Characteristics { get; set; }
    }
}