using FreightCompany.Data;
using FreightCompany.Domain;
using FreightCompany.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FreightCompany.Repository
{
    public class ProductRepository : IProductRepository
    {

        public void CreateProduct(Product product)
        {
            var context = new DataBaseContext();
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void CreateProducts(List<Product> products)
        {
            var context = new DataBaseContext();
            context.Products.AddRange(products);
            context.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            var context = new DataBaseContext();
            context.Products.RemoveRange(product);
            context.SaveChanges();
        }

        public void DeleteProductByProductName(string productName)
        {
            var context = new DataBaseContext();
            var products = context.Products.Where(p => p.ProductName == productName);
            context.RemoveRange(products);
            context.SaveChanges();
        }

        public List<Product> GetAllProducts()
        {
            var context = new DataBaseContext();
            return context.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            var context = new DataBaseContext();
            return context.Products.FirstOrDefault(p => p.Id == id); 
        }

        public Product GetProductByProductName(string ProductName)
        {
            var context = new DataBaseContext();
            return context.Products.FirstOrDefault(p => p.ProductName == ProductName);
           
        }

        public List<Product> ProductNameStartWith(string productName)
        {
            var context = new DataBaseContext();
            return context.Products.Where(p => p.ProductName.StartsWith(productName)).ToList();
        }

        public void UpdateProduct(Product product)
        {
            var context = new DataBaseContext();
            context.Products.Update(product);
            context.SaveChanges();
        }


        public int DropProductTable()
        {
            var context = new DataBaseContext();
            using (var connection = context.Database.GetDbConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM PRODUCTS DBCC CHECKIDENT (Products, RESEED, 0)";
                    var result = command.ExecuteNonQuery();
                }
            }
            return 0;
        }
    }
}
