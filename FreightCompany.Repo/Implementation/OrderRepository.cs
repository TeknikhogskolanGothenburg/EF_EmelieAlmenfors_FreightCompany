using FreightCompany.Data;
using FreightCompany.Domain;
using FreightCompany.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FreightCompany.Repository
{
    public class OrderRepository : IOrderRepository
    {
        // Eftersom mina metoder inte är så komplexa och processor intensiva har jag valt att jobba asynkront.
        // Och för att jag har använt mig utav LINQ som har async som ett inbyggt stöd.

        public async void CreateOrder(Order order)
        {
            var context = new DataBaseContext();
            context.Orders.Add(order);
            await context.SaveChangesAsync();
        }

        public async void CreateOrders(List<Order> orders)
        {
            var context = new DataBaseContext();
            context.Orders.AddRange(orders);
            await context.SaveChangesAsync();
        }

        public async void DeleteOrder(Order order)
        {
            var context = new DataBaseContext();
            context.Orders.RemoveRange(order);
            await context.SaveChangesAsync();
        }

        public async void UpdateOrder(Order order)
        {
            var context = new DataBaseContext();
            context.Orders.Update(order);
            await context.SaveChangesAsync();
        }

        public async Task<List<Order>> GetAllOrders()
        {
            var context = new DataBaseContext();
            return await context.Orders.ToListAsync();   
        }
        
        public async Task<Order> GetOrderById(int id)
        {
            var context = new DataBaseContext();
            return await context.Orders.FindAsync(id);
           
        }

        public async Task<List<Order>> GetOrdersById(List<int> ordersId)
        {
            var context = new DataBaseContext();
            return await context.Orders.Where(x => ordersId.Contains(x.Id)).ToListAsync();
        }

        public async Task<List<Order>> GetOrdersWhereProductExists(int productId)
        {
           var context = new DataBaseContext();
           return await context.Orders.Where(o => o.OrderProducts.All(p => p.ProductId == productId)).ToListAsync();
        }

        public async void DeleteOrderWithId(int orderId)
        {
            var context = new DataBaseContext();

            var order = context.Orders.Where(o => o.Id == orderId);
            context.Remove(order);
            await context.SaveChangesAsync();
        }

        public async Task<int> DropOrderTable()
        {
            var context = new DataBaseContext();
            using (var connection = context.Database.GetDbConnection())
            {
                await connection.OpenAsync();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM ORDERS DBCC CHECKIDENT (Orders, RESEED, 0)";
                    var result = await command.ExecuteNonQueryAsync();
                }
            }
            return 0;
        }
    }
}
