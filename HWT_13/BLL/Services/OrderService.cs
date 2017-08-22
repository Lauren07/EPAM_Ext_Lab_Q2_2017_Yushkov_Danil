using System;
using System.Collections.Generic;
using AutoMapper;
using BLL.Models;
using DataAccessLayer;
using DataAccessLayer.Entities;

namespace BLL.Services
{
    public class OrderService
    {
        private DAL database;

        public OrderService()
        {
            this.database = new DAL();
        }

        public IEnumerable<OrderDTO> GetAllOrders()
        {
            var orders = Mapper.Map<IEnumerable<Order>, IEnumerable<OrderDTO>>(this.database.GetAllOrders());
            foreach (var order in orders)
            {
                order.Customer = Mapper.Map<Customer, CustomerDTO>(this.database.GetCustomer(order.CustomerID));
            }

            return orders;
        }

        public OrderDetailsDTO GetOrderDetails(int orderID)
        {
            var orderDetails = Mapper.Map<OrderDetails, OrderDetailsDTO>(this.database.GetOrderDetails(orderID));
            orderDetails.Order.Customer = Mapper.Map<Customer, CustomerDTO>(this.database.GetCustomer(orderDetails.Order.CustomerID));
            orderDetails.CountPrice();
            return orderDetails;
        }

        public OrderDTO GetOrder(int orderID)
        {
            var order = Mapper.Map<Order, OrderDTO>(this.database.GetOrder(orderID));
            order.Customer = Mapper.Map<Customer, CustomerDTO>(this.database.GetCustomer(order.CustomerID));
            return order;
        }

        public void DeleteOrder(int orderID)
        {
            this.database.DeleteOrder(orderID);
        }

        public bool AddOrder(OrderDTO order)
        {
            order.OrderDate = DateTime.Now;
            var preparedCustomer = Mapper.Map<CustomerDTO, Customer>(order.Customer);
            var preparedOrder = Mapper.Map<OrderDTO, Order>(order);
            preparedOrder.CustomerID = this.database.AddCustomer(preparedCustomer);
            this.database.CreateOrder(preparedOrder);
            return true;
        }

        public void EditOrder(OrderDTO order)
        {
            var preparedOrder = Mapper.Map<OrderDTO, Order>(order);
            var preparedCustomer = Mapper.Map<CustomerDTO, Customer>(order.Customer);
            this.database.EditOrder(preparedOrder);
            this.database.EditCustomer(preparedCustomer);
        }
    }
}
