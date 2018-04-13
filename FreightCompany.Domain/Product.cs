using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreightCompany.Domain
{
    public class Product
    {

        public Product()
        {
            OrderProducts = new List<OrderProduct>();
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public List<OrderProduct> OrderProducts { get; set; }
    }
}
