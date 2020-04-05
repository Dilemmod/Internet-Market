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
        public int Price { get; set; }
        public string ImageData { get; set; }
        public string ProductCategory { get; set; }
        public ICollection<Characteristic> Characteristics { get; set; }
        public Product()
        {
            Characteristics = new List<Characteristic>();
        }
    }
}
