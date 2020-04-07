using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLibrary
{
    public class Order
    {
        public int Id { get; set; }
        public int OrderPrice { get; set; }
        public DateTime Created { get; set; }
        public DeliveryMetod DeliveryMethod { get; set; }
        public PaymentMthod PaymentMthod { get; set; }
        public StatusOrder StatusOrder { get; set; }
        public int? CustomerInformationId { get; set; }
        public CustomerInformation CustomerInformation { get; set; }
        public ICollection<Product> Product { get; set; }
        public Order()
        {
            Product = new List<Product>();
        }
    }
    public enum StatusOrder
    {
        Accepted,
        Canceled,
        Processed,
        Deliver,
        Completed
    }
    public enum PaymentMthod
    {
        UponReceipt,
        VisaMastercard,
        GooglePay,
    }
    public enum DeliveryMetod
    {
        Pickup,
        FromNewMail,
        Courier
    }
}
