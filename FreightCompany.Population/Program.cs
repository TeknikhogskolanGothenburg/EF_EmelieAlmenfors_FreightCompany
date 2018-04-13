using FreightCompany.Domain;
using FreightCompany.Population.ServiceMethods;
using FreightCompany.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FreightCompany.Population
{
    public class Program
    {

        public static void Main(string[] args)
        {
            ProductRepository productRepository = new ProductRepository();
            CustomerRepository customerRepository = new CustomerRepository();
            AdressRepository adressRepository = new AdressRepository();
            OrderRepository orderRepository = new OrderRepository();
            ShipperRepository shipperRepository = new ShipperRepository();
            OrderProductRepository orderProductRepository = new OrderProductRepository();


            #region address
            var listOfAddresses = new List<Adress>();

            var address2 = new Adress { Address = "Trogatan", ZipCode = "60780", City = "Borås", Country = "Sweden" };
            var address3 = new Adress { Address = "lillabrogatan", ZipCode = "50758", City = "Gothenburg", Country = "Sweden" };
            var address4 = new Adress { Address = "storgatan", ZipCode = "50758", City = "Gothenburg", Country = "Sweden" };
            var address5 = new Adress { Address = "Bilvägen", ZipCode = "50670", City = "Gothenburg", Country = "Sweden" };
            var address6 = new Adress { Address = "trallgatan", ZipCode = "50758", City = "Borås", Country = "Sweden" };
            var address7 = new Adress { Address = "nordsjövägen", ZipCode = "50890", City = "Gothenburg", Country = "Sweden" };
            var address8 = new Adress { Address = "Bilvägen", ZipCode = "50758", City = "Gothenburg", Country = "Sweden" };

            listOfAddresses.Add(address2);
            listOfAddresses.Add(address3);
            listOfAddresses.Add(address4);
            listOfAddresses.Add(address5);
            listOfAddresses.Add(address6);
            listOfAddresses.Add(address7);
            listOfAddresses.Add(address8);



            var address1 = new Adress
            {
                Address = "Trollvägen",
                ZipCode = "50560",
                City = "Gothenburg",
                Country = "Sweden",
            };

            adressRepository.CreateAdress(address1);
            adressRepository.CreateAdresses(listOfAddresses);
            adressRepository.DeleteAdressById(8);

            var adresses = adressRepository.GetAllAdresses();
            foreach (var adress in adresses)
            {
                Console.WriteLine(adress.Address + "\t" + adress.ZipCode + "\t" + adress.City + "\t" + adress.Country);
            }

            try
            {
                var addressesByZipCode = adressRepository.GetAdressesByZipCode("50758");
                foreach (var adress in addressesByZipCode)
                {
                    Console.WriteLine(adress.Address + "\t " + adress.ZipCode + "\t " + adress.City + " \t" + adress.Country);
                }
            }
            catch (ArgumentNullException argnull)
            {
                Console.WriteLine("Sorry zipcode dosent exist");
            }

            #endregion


            #region product 
            var listOfProducts = new List<Product>();

            var product1 = new Product { ProductName = "Hutten Candleholder", Description = "Skultuna CandleHolder", Price = 1200 };
            var product2 = new Product { ProductName = "Pillowcase Rox And Fix ", Description = "Designer Joseph Frank", Price = 900 };
            var product3 = new Product { ProductName = "Pillowcase Hawai", Description = "Designer Joseph Frank", Price = 900 };
            var product4 = new Product { ProductName = "Vase Dagg", Description = "Vase From Svensk Tenn", Price = 2800 };
            var product5 = new Product { ProductName = "Vase Kotte", Description = "Vase From Svensk Tenn", Price = 800 };

            listOfProducts.Add(product1);
            listOfProducts.Add(product2);
            listOfProducts.Add(product3);
            listOfProducts.Add(product4);
            listOfProducts.Add(product5);

            var product6 = new Product
            {
                ProductName = "Joseph Frank Pillowcase",
                Description = "Svensk Tenn",
                Price = 1500,
            };

            productRepository.CreateProduct(product6);
            productRepository.CreateProducts(listOfProducts);

            product6.ProductName = "Nisse";
            productRepository.UpdateProduct(product6);

            try
            {
                var product = productRepository.GetProductById(1);
                Console.WriteLine(product.ProductName);
            }
            catch (ArgumentNullException argNull)
            {
                Console.WriteLine("Sorry the product was not found!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Something very bad has happen, contact Emelie!");
            }

            var products = productRepository.GetAllProducts();
            foreach (var product in products)
            {
                Console.WriteLine(product.ProductName + " " + product.Price + "SEK");
            }

            try
            {
                var products1 = productRepository.ProductNameStartWith("ca");
                foreach (var product in products)
                {
                    Console.WriteLine(product.ProductName);
                }
            }
            catch (ArgumentNullException argnull)
            {
                Console.WriteLine("Sorry the product was not found");
            }
            #endregion



            #region customer
            var ListOfCustomers = new List<Customer>();

            var customer1 = new Customer { FirstName = "Celine", LastName = "Wanna", PhoneNumber = "0735778990", Email = "Celine1234@hotmail.com", AdressId = 1 };
            var customer2 = new Customer { FirstName = "Estelle", LastName = "Wanna", PhoneNumber = "0728202020", Email = "Estelle1@hotmail.com", AdressId = 2 };

            ListOfCustomers.Add(customer1);
            ListOfCustomers.Add(customer2);

            var customer3 = new Customer
            {
                FirstName = "Sean",
                LastName = "Banan",
                PhoneNumber = "072866790",
                Email = "sean@hotmail.com",
                AdressId = 1,
            };

            customerRepository.CreateCustomers(ListOfCustomers);
            customerRepository.CreateCustomer(customer3);

            var customer = customerRepository.GetCustomerById(1);
            Console.WriteLine(customer.Email);


            var customers = customerRepository.GetAllCustomers();

            foreach (var c in customers)
            {
                Console.WriteLine(c.FirstName + " " + c.LastName);
            }
            #endregion

            #region shipper 
            var listOfShippers = new List<Shipper>();

            var shipper1 = new Shipper { Name = "Svensk Tenn Ab", AdressId = 4 };
            var shipper2 = new Shipper { Name = "Design Online Ab", AdressId = 6 };
            var shipper3 = new Shipper { Name = "Ellos Ab", AdressId = 5 };

            listOfShippers.Add(shipper1);
            listOfShippers.Add(shipper2);
            listOfShippers.Add(shipper3);

            var shipper4 = new Shipper
            {
                Name = "Skultuna Ab",
                AdressId = 7,
            };

            shipperRepository.CreateShippers(listOfShippers);
            shipperRepository.CreateShipper(shipper4);
            var shippers = shipperRepository.GetAllShippers();

            foreach (var shipper in shippers)
            {
                Console.WriteLine(shipper.Name);
            }

            try
            {
                var shipperById = shipperRepository.GetShipperById(1);
                Console.WriteLine(shipperById.Name);
            }
            catch (ArgumentNullException argnull)
            {
                Console.WriteLine("Sorry the shipper was not found!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Something very bad has happen, contact Emelie!");
            }
            #endregion

            #region order
            var ListOfOrders = new List<Order>();

            var order1 = new Order { OrderDate = DateTime.Now, CustomerId = 1, ShipperId = 2, };
            var order2 = new Order { OrderDate = DateTime.Now, CustomerId = 2, ShipperId = 1 };

            ListOfOrders.Add(order1);
            ListOfOrders.Add(order2);

            var order3 = new Order
            {
                OrderDate = DateTime.Now,
                CustomerId = 3,
                ShipperId = 3,
            };
            orderRepository.CreateOrders(ListOfOrders);
            orderRepository.CreateOrder(order3);
            var orderAsync = orderRepository.GetOrderById(2).Result;
            #endregion


            #region OrderProduct
            var order = new Order()
            {
                CustomerId = 1,
                OrderDate = DateTime.Now,
                ShipperId = 1,

            };

            var product10 = new Product { ProductName = "Vase ", Description = "Vase From Svensk Tenn", Price = 2800 };
            var product11 = new Product { ProductName = "Vase design", Description = "Vase From Svensk Tenn", Price = 1000 };

            listOfProducts.Add(product10);
            listOfProducts.Add(product11);

            orderProductRepository.CreateOrderProduct(order, listOfProducts);
            orderProductRepository.ConnectProductsToOrder(1, new List<int> { 1, 2, 4 });
            #endregion


            #region businessLogic
            var businessLogic = new BusinessLogic();
            var city = "Borås";
            var productId = 12;

            var customersByProductIdAndCity = businessLogic.GetCustomersByProductIdAndCity(city, productId);
            foreach (var customerByProductIdAndCity in customersByProductIdAndCity)
            {
                Console.WriteLine("Product with id: " + productId + " has been orderd by customer: " + customerByProductIdAndCity.FirstName + " " + customerByProductIdAndCity.LastName + "That lives in " + city);
            }
            #endregion


            Console.WriteLine("Do you want to drop database tables? (Y/N)");
            var userInput = Console.ReadLine();

            if (userInput.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("Dropping table Orders.");
                var resultOrders = orderRepository.DropOrderTable().Result;
                Console.WriteLine("Order table was dropped:" + resultOrders + "rows where was removed");

                Console.WriteLine("Dropping table Adresses.");
                var resultAdresses = adressRepository.DropAdressTable();
                Console.WriteLine("Adresses table was dropped:" + resultAdresses + "rows where was removed");

                Console.WriteLine("Dropping table Customers.");
                var resultCustomers = customerRepository.DropCustomerTable();
                Console.WriteLine("Customers table was dropped:" + resultCustomers + "rows where was removed");

                Console.WriteLine("Dropping table Products.");
                var resultProducts = productRepository.DropProductTable();
                Console.WriteLine("Products table was dropped:" + resultProducts + "rows where was removed");

                Console.WriteLine("Dropping table Shippers.");
                var result = shipperRepository.DropShipperTable();
                Console.WriteLine("Shippers table was dropped:" + result + "rows where was removed");

                //Console.WriteLine("Dropping table OrderProduct.");
                //var resultOrderProducts = orderProductRepository.DropOrderProductTable();
                //Console.WriteLine("OrderProduct table was dropped:" + resultOrderProducts + "rows where was removed");
            }

        }
    }
}




