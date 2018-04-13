using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreightCompany.Domain
{
    public class Order
    {
        public Order()
        {
            OrderProducts = new List<OrderProduct>();
        }

        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public int ShipperId { get; set; }
        public List<OrderProduct> OrderProducts { get; set; }
    }
}
