using System;
using System.Collections.Generic;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> GetAllOrders();

        Order FindOrder(int orderID);

        void CreateOrder(Order order);

        void MarkOrderShipped(int orderID, DateTime deliveryDate);

        void SendOrder(int orderID, DateTime departureDate);

        void EditOrder(Order order);

        void DeleteOrderDetails(int orderID);

        void DeleteOrder(int orderID);
    }
}
