using System.Collections.Generic;
using Task01.Entities;

namespace Task01.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetAllProductsFromOrder(int orderID);
        List<ProductDetails> GetAllProductsOrder(int orderID);
        List<CustomerProductInfo> GetCustomerProductsInfo(string customerID);
    }
}
