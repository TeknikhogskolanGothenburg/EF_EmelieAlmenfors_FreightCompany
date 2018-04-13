using FreightCompany.Domain;
using System.Collections.Generic;

namespace FreightCompany.Repository.Interface
{
    public interface IProductRepository
    {
        void CreateProduct(Product product);
        void CreateProducts(List<Product> products);
        void DeleteProduct(Product product);
        void DeleteProductByProductName(string productName);
        void UpdateProduct(Product product);
        int DropProductTable();
        Product GetProductById(int id);
        List<Product> GetAllProducts();
        List<Product> ProductNameStartWith(string product);
       

    }
}
