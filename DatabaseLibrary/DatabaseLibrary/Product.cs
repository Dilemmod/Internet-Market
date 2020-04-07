using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLibrary
{
    public class Product
    {
        public int Id { get;set; }
        public string Title { get; set; }
        public int QuantitySold { get; set; }
        public string Price { get; set; }
        public string ImageData { get; set; }
        public string ProductCategory { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Characteristic> Characteristics { get; set; }
        public Product()
        {
            Orders = new List<Order>();
            Characteristics = new List<Characteristic>();
        }
    }
}
