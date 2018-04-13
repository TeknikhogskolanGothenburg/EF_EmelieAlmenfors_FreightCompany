using FreightCompany.Data;
using FreightCompany.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;



namespace FreightCompany.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        
        public void CreateCustomer(Customer customer)
        {
            var context = new DataBaseContext();
            context.Customers.Add(customer);
            context.SaveChanges();
        }

        public void CreateCustomers(List<Customer> customers)
        {
            var context = new DataBaseContext();
            context.Customers.AddRange(customers);
            context.SaveChanges();
        }

        public void DeleteCustomer(Customer customer)
        {
            var context = new DataBaseContext();
            context.Customers.RemoveRange(customer);
            context.SaveChanges();
        }

        public void DeleteCustomerByFullName(string firstName, string lastName)
        {
            var context = new DataBaseContext();
            var customer = context.Customers.Where(c => c.FirstName == firstName && c.LastName == lastName);
            context.Remove(customer);
        }

        public void DeleteCustomerById(int customerId)
        {
            var context = new DataBaseContext();
            var customer = context.Customers.Where(c => c.Id == customerId);
            context.Remove(customer);
            context.SaveChanges();
        }

        public List<Customer> GetAllCustomers()
        {
            var context = new DataBaseContext();
            return context.Customers.ToList();
        }

        public Customer GetCustomerByEmail(string email)
        {
            var context = new DataBaseContext();
            return context.Customers.FirstOrDefault(c => c.Email == email);

        }

        public Customer GetCustomerById(int id)
        {
            var context = new DataBaseContext();
            return context.Customers.FirstOrDefault(c => c.Id == id);
            
        }

        public List<Customer> GetCustomersById(List<int> customersids)
        {
            var context = new DataBaseContext();
            return context.Customers.Where(x => customersids.Contains(x.Id)).ToList();
        }

        public void UpdateCustomer(Customer customer)
        {
            var context = new DataBaseContext();
            context.Customers.Update(customer);
            context.SaveChanges();

        }

        public int DropCustomerTable()
        {
            var context = new DataBaseContext();
            using (var connection = context.Database.GetDbConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM CUSTOMERS DBCC CHECKIDENT (Customers, RESEED, 0)";
                    var result = command.ExecuteNonQuery();
                }
            }
            return 0;
        }
    }
}

