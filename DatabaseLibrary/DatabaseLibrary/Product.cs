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
        //public string Model { get; set; }
        public List<string> Characteristics { get; set; }
       // public int QuantityInStock { get; set; }
        public int Price { get; set; }
        public string ImageFileName{ get; set; }
       // public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }

        //public int? ProductCategoryId { get; set; }
        //public ProductCategory ProductCategory { get; set; }
       // public int? ProductManufacturerId { get; set; }
       // public ProductManufacturer ProductManufacturer { get; set; }
    }
}
