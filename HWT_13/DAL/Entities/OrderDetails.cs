using System.Collections.Generic;

namespace DataAccessLayer.Entities
{
    public class OrderDetails
    {
        public Order Order;
        public List<ProductDetails> Products;

        public OrderDetails(Order order, List<ProductDetails> products)
        {
            this.Order = order;
            this.Products = products;
        }
    }
}
