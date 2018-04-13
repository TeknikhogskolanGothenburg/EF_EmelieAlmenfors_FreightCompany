using FreightCompany.Domain;
using FreightCompany.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrightCompany.Populator
{
    class Program
    {
        static void Main(string[] args)
        {
            var product = new Product();
            product.Description = "Description";


            var productRepo = new ProductRepository();
            productRepo.CreateProduct(product);

            Console.WriteLine("Product added");
        }
    }
}
