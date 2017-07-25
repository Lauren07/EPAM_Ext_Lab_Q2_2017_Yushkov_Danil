using System.Collections.Generic;

namespace Task01.Entities
{
    public class OrderDetails
    {
        public Order Order;
        public List<Product> Products;

        public OrderDetails(Order order, List<Product> products)
        {
            this.Order = order;
            this.Products = products;
        }
    }
}
