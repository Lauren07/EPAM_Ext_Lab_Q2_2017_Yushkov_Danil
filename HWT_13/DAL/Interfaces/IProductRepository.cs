using System.Collections.Generic;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();

        Product FindProduct(int productID);

        List<ProductDetails> GetAllProductsOrder(int orderID);

        List<CustomerProductInfo> GetCustomerProductsInfo(string customerID);

        void AddProductInOrder(ProductDetails product);
    }
}
