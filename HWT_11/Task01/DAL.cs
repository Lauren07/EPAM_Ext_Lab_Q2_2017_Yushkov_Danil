using System;
using System.Collections.Generic;
using System.Configuration;
using Task01.Entities;
using Task01.Interfaces;

namespace Task01
{
    public class DAL
    {
        private string connectionString;
        private IOrderRepository orderRepository;
        private IProductRepository productRepository;

        public DAL(string connectionName)
        {
            this.connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            this.orderRepository = new OrderRepository(this.connectionString);
            this.productRepository = new ProductRepository(this.connectionString);
        }

        public List<Order> GetAllOrders()
        {
            return this.orderRepository.GetAllOrders();
        }

        public OrderDetails GetOrder(int orderID)
        {
            var order = this.orderRepository.GetOrder(orderID);
            var productsOrder = this.productRepository.GetAllProductsFromOrder(orderID);

            return new OrderDetails(order, productsOrder);
        }

        public void CreateOrder(Order order)
        {
            this.orderRepository.CreateOrder(order);
        }

        public void DeleteOrder(int orderID)
        {
            this.orderRepository.DeleteOrder(orderID);
        }

        public void ChangeOrderState(int orderID, OrderStatus newOrderState, DateTime date)
        {
            if (newOrderState == OrderStatus.Sent)
            {
                this.orderRepository.SendOrder(orderID, date);
            }
            else if (newOrderState == OrderStatus.Shipped)
            {
                this.orderRepository.MarkOrderShipped(orderID, date);
            }
        }

        public List<CustomerProductInfo> GetCustomerProducts(string customerID)
        {
            return this.productRepository.GetCustomerProductsInfo(customerID);
        }

        public List<ProductDetails> GetOrderProducts(int orderID)
        {
            return this.productRepository.GetAllProductsOrder(orderID);
        }
    }
}
