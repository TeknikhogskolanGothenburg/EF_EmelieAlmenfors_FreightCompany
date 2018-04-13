using FreightCompany.Domain;
using System.Collections.Generic;

namespace FreightCompany.Repository
{
    public interface IOrderProductRepository
    {
        void ConnectProductsToOrder(int OrderId, List<int> ProductId);
        void CreateOrderProduct(Order order, List<Product> products);
        void DeleteOrderProduct(OrderProduct orderProduct);
        List<OrderProduct> GetAllOrdersWithProductId(int productId);
        void DeleteProductFromOrder(int orderId, int productId);
        //int DropOrderProductTable();
    }
}

