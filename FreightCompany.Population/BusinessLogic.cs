using FreightCompany.Domain;
using FreightCompany.Repository;
using System.Collections.Generic;
using System.Linq;

namespace FreightCompany.Population.ServiceMethods
{
    public class BusinessLogic
    {

        ProductRepository productRepository = new ProductRepository();
        CustomerRepository customerRepository = new CustomerRepository();
        AdressRepository adressRepository = new AdressRepository();
        OrderRepository orderRepository = new OrderRepository();
        OrderProductRepository orderProductRepository = new OrderProductRepository();

        public List<Customer> GetCustomersByProductIdAndCity(string city, int productId)
        {
            var orderProducts = orderProductRepository.GetAllOrdersWithProductId(productId);
            var orderIds = orderProducts.Select(o => o.OrderId).ToList();
            var orders = orderRepository.GetOrdersById(orderIds).Result;

            var customersIds = orders.Select(c => c.CustomerId).ToList();
            var customers = customerRepository.GetCustomersById(customersIds);

            var addressIds = customers.Select(a => a.AdressId).ToList();
            var addresses = adressRepository.GetAdressesById(addressIds);
            var filtredAddressesByCity = addresses.Where(a => a.City == city).Select(c => c.Id).ToList();

            return customers.Where(c => filtredAddressesByCity.Contains(c.AdressId)).ToList();

        }
    }
}
