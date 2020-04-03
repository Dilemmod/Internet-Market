namespace DatabaseLibrary
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DBInternetMarket : DbContext
    {
        public DBInternetMarket()
            : base("name=DBInternetMarket")
        {
        }

        public virtual DbSet<UsersLogin> UsersLogins { get; set; }
        public virtual DbSet<CustomerInformation> CustomersInformations { get; set; }
        public virtual DbSet<MenedjerInformation> MenedjersInformations { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductsCategory { get; set; }
        public virtual DbSet<ProductManufacturer> ProductsManufacturer { get; set; }


    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}