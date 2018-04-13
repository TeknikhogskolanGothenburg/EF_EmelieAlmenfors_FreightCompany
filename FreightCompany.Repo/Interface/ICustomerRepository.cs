using FreightCompany.Domain;
using System.Collections.Generic;

namespace FreightCompany.Repository
{
    public interface ICustomerRepository
    {
        void CreateCustomer(Customer customer);
        void CreateCustomers(List<Customer> customers);
        void DeleteCustomer(Customer customer);
        void DeleteCustomerById(int customerId);
        void DeleteCustomerByFullName(string firstName, string lastName);
        void UpdateCustomer(Customer customer);
        int DropCustomerTable();
        Customer GetCustomerById(int id);
        List<Customer> GetCustomersById(List<int> customersids);
        Customer GetCustomerByEmail(string email);
        List<Customer> GetAllCustomers();

    }
}
