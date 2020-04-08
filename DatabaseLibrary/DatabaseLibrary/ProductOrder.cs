using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLibrary
{
    public class ProductOrder
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? NumericProduct { get; set; }
        public int? OrderId { get; set; }
    }
}
