using FreightCompany.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreightCompany.Interface
{
    public interface IOrderRepository
    {

        void CreateOrder(Order order);
        void CreateOrders(List<Order> orders);
        void DeleteOrder(Order order);
        void DeleteOrderWithId(int orderId);
        void UpdateOrder(Order order);
        Task<Order> GetOrderById(int id);
        Task<List<Order>> GetAllOrders();
        Task<List<Order>> GetOrdersById(List<int> ordersId);
        Task<List<Order>> GetOrdersWhereProductExists(int productId);
        Task<int> DropOrderTable();
       

    }
}
