using FreightCompany.Data;
using FreightCompany.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FreightCompany.Repository
{
    public class OrderProductRepository : IOrderProductRepository
    {
        public void ConnectProductsToOrder(int OrderId, List<int> ProductId)
        {
            var context = new DataBaseContext();
            var orderExists = context.Orders.Find(OrderId);

            if(orderExists != null)
            {
                foreach (var product in ProductId)
                {
                    context.Add(new OrderProduct { OrderId = OrderId, ProductId = product });
                }
                context.SaveChanges();
            }

        }

        public List<OrderProduct> GetAllOrdersWithProductId(int productId)
        {
            var context = new DataBaseContext();
            return context.OrderProduct.Where(p => p.ProductId == productId).ToList();
        }

        public void CreateOrderProduct(Order order, List<Product> products)
        {
            var context = new DataBaseContext();

            foreach (var product in products) 
            {
                context.OrderProduct.Add(new OrderProduct { Order = order, Product = product});
            }
            context.SaveChanges();
        }

        public void DeleteOrderProduct(OrderProduct orderProduct)
        {
            var context = new DataBaseContext();
            context.OrderProduct.RemoveRange(orderProduct);
            context.SaveChanges();
        }

        public void DeleteProductFromOrder(int orderId, int productId)
        {
            var context = new DataBaseContext();
            var product = context.OrderProduct.Where(p => p.ProductId == productId);
            var order = context.OrderProduct.Where(o => o.OrderId == orderId);
            context.RemoveRange(orderId, productId);
            context.SaveChanges();
        }


        //public int DropOrderProductTable()
        //{
        //    var context = new DataBaseContext();
        //    using (var connection = context.Database.GetDbConnection())
        //    {
        //        connection.Open();
        //        using (var command = connection.CreateCommand())
        //        {
        //            command.CommandText = "DELETE FROM ORDERPRODUCT DBCC CHECKIDENT (OrderProduct, RESEED, 0)";
        //            var result = command.ExecuteNonQuery();
        //        }
        //    }
        //    return 0;
        //}
    }
}


