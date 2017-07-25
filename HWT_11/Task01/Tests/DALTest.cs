using System;
using System.Linq;
using NUnit.Framework;
using Task01.Entities;

namespace Task01.Tests
{
    public class DALTest
    {
        private string connectionName = "NorthwindConection";
        private DAL DAL;

        public DALTest()
        {
            this.DAL = new DAL(this.connectionName);
        }

        [Test]
        public void TestGetAllOrders()
        {
            var expectedCount = 830;
            var orders = this.DAL.GetAllOrders();
            Assert.AreEqual(expectedCount, orders.Count);

            var expectedOrder = new Order { OrderID = 10990, CustomerID = "ERNSH", EmployeeID = 2 };
            var order = orders.FirstOrDefault(ord => ord.OrderID == expectedOrder.OrderID);
            Assert.AreEqual(expectedOrder.CustomerID, order.CustomerID);
            Assert.AreEqual(expectedOrder.EmployeeID, order.EmployeeID);
            Assert.AreEqual(OrderStatus.Shipped, order.OrderState);
        }

        [Test]
        public void TestGetOrder()
        {
            var orderID = 10248;
            var expectedCustomerID = "VINET";
            var expectedCountProducts = 3;
            var resultOrder = this.DAL.GetOrder(orderID);

            Assert.AreEqual(expectedCustomerID, resultOrder.Order.CustomerID);
            Assert.AreEqual(expectedCountProducts, resultOrder.Products.Count);
        }

        [Test]
        public void TestAddOrder()
        {
            var countOrders = this.DAL.GetAllOrders().Count;
            var expectedOrder = new Order {CustomerID = "VINET", EmployeeID = 4, OrderDate = DateTime.Now, RequiredDate = DateTime.Now, ShippedDate = DateTime.Now };
            this.DAL.CreateOrder(expectedOrder);
            Assert.AreEqual(countOrders + 1, this.DAL.GetAllOrders().Count);
        }

        [Test]
        public void TestMarkOrder()
        {
            var notShippedOrder = this.DAL.GetAllOrders().FirstOrDefault(order => order.ShippedDate == null);
            this.DAL.ChangeOrderState(notShippedOrder.OrderID, OrderStatus.Shipped, DateTime.Now);
            var changedOrder = this.DAL.GetOrder(notShippedOrder.OrderID);
            Assert.IsNotNull(changedOrder.Order.ShippedDate);
            Assert.AreEqual(OrderStatus.Shipped, changedOrder.Order.OrderState);
        }

        [Test]
        public void TestGetCustomerProducts()
        {
            var expectedCountProducts = 9;
            var customerID = "VINET";
            var customerProducts = this.DAL.GetCustomerProducts(customerID);

            Assert.AreEqual(expectedCountProducts, customerProducts.Count);
        }

        [Test]
        public void TestGetOrderProducts()
        {
            var expectedCountProducts = 3;
            var orderID = 10248;
            var orderProducts = this.DAL.GetOrderProducts(orderID);

            Assert.AreEqual(expectedCountProducts, orderProducts.Count);
        }
    }
}
