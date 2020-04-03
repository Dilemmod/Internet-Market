using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLibrary
{
    public class MenedjerInformation
    {
        public int Id { get; set; }
        public int DataOfBirth { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public string FullName { get; set; }
        public int? UserLoginId { get; set; }
        public UsersLogin UserLogin { get; set; }
    }
}
