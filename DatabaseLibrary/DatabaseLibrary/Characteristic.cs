using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLibrary
{
    public class Characteristic
    {
        public int Id { get; set; }
        public string CharacteristicString { get; set; }
        public int? ProductId { get; set; }
        public Product Product { get; set; }
    }
}
