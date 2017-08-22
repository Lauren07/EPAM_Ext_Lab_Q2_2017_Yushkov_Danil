using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;

namespace DataAccessLayer
{
    public class DAL
    {
        private string connectionString;
        private IOrderRepository orderRepository;
        private IProductRepository productRepository;
        private ICustomerRepository customerRepository;

        public DAL()
        {
            var connectionName = "NorthwindConection";
            this.connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            this.orderRepository = new OrderRepository(this.connectionString);
            this.productRepository = new ProductRepository(this.connectionString);
            this.customerRepository = new CustomerRepository(this.connectionString);
        }

        public void EditCustomer(Customer customer)
        {
            if (this.GetCustomer(customer.CustomerID) != null)
            {
                this.customerRepository.EditCustomer(customer);
            }
        }

        public void EditOrder(Order order)
        {
            if (this.GetOrder(order.OrderID) != null)
            {
                this.orderRepository.EditOrder(order);
            }
        }

        public List<Order> GetAllOrders()
        {
            return this.orderRepository.GetAllOrders();
        }

        public OrderDetails GetOrderDetails(int orderID)
        {
            var order = this.orderRepository.FindOrder(orderID);
            var productsOrder = this.productRepository.GetAllProductsOrder(orderID);

            return new OrderDetails(order, productsOrder);
        }

        public Order GetOrder(int orderID)
        {
            return this.orderRepository.FindOrder(orderID);
        }

        public Customer GetCustomer(string customerId)
        {
            return this.customerRepository.GetCustomer(customerId);
        }

        public void CreateOrder(Order order)
        {
            this.orderRepository.CreateOrder(order);
        }

        public void DeleteOrder(int orderID)
        {
            this.orderRepository.DeleteOrderDetails(orderID);
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

        public bool AddProductInOrder(ProductDetails product)
        {
            var order = this.GetOrderDetails(product.OrderID);
            if (this.productRepository.FindProduct(product.ProductID) == null || order == null)
            {
                return false;
            }

            if (order.Products.Select(prod => prod.ProductID).Contains(product.ProductID))
            {
                return false;
            }

            this.productRepository.AddProductInOrder(product);
            return true;
        }

        public string AddCustomer(Customer customer)
        {
            do
            {
                customer.CustomerID = customer.GenerateID();
            } while (this.GetCustomer(customer.CustomerID) != null);
            this.customerRepository.AddCustomer(customer);
            return customer.CustomerID;
        }

        public List<Product> GetAllProducts()
        {
            return this.productRepository.GetAllProducts();
        }
    }
}
