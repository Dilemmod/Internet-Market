using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLibrary
{
    public class CustomerInformation
    {
        public int Id { get; set; }
        public string DataOfBirth { get; set; }
        public string Address { get; set; }
        public string ContactFio { get; set; }
        public string Phone { get; set; }
        public int? UserLoginId { get; set; }
        public UsersLogin UserLogin { get; set; }
        public ICollection<Order> Order { get; set; }
        public CustomerInformation()
        {
            Order = new List<Order>();
        }
    }
    
}
