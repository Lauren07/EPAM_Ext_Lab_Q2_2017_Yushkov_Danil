using System;
using System.Collections.Generic;
using Task01.Entities;

namespace Task01.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> GetAllOrders();
        Order GetOrder(int orderID);
        void CreateOrder(Order order);
        void MarkOrderShipped(int orderID, DateTime deliveryDate);
        void SendOrder(int orderID, DateTime departureDate);
        void DeleteOrder(int orderID);
    }
}
