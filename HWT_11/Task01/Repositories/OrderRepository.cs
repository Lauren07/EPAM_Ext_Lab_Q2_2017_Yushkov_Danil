using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Task01.Entities;
using Task01.Interfaces;

namespace Task01
{
    public class OrderRepository : IOrderRepository
    {
        private string connectionString;

        public OrderRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Order> GetAllOrders()
        {
            var orders = new List<Order>();
            using (var connection = new SqlConnection(this.connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Northwind.Orders";
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        orders.Add(new Order
                        {
                            OrderID = (int)reader["OrderID"],
                            CustomerID = (string)reader["CustomerID"],
                            EmployeeID = (int)reader["EmployeeID"],
                            OrderDate = reader["OrderDate"] as DateTime?,
                            RequiredDate = reader["RequiredDate"] as DateTime?,
                            ShippedDate = reader["ShippedDate"] as DateTime?
                        });
                    }
                }
            }

            return orders;
        }

        public Order GetOrder(int orderID)
        {
            Order requestedOrder = null;
            using (var connection = new SqlConnection(this.connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Northwind.Orders" +
                                      $" WHERE OrderID={orderID}";
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        requestedOrder = new Order
                        {
                            OrderID = (int)reader["OrderID"],
                            CustomerID = (string)reader["CustomerID"],
                            EmployeeID = (int)reader["EmployeeID"],
                            OrderDate = reader["OrderDate"] != null ? (DateTime?)reader["OrderDate"] : null,
                            RequiredDate = reader["RequiredDate"] != null ? (DateTime?)reader["RequiredDate"] : null,
                            ShippedDate = reader["ShippedDate"] != null ? (DateTime?)reader["ShippedDate"] : null
                        };
                    }
                }
            }

            return requestedOrder;
        }

        public void CreateOrder(Order order)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Northwind.Orders(CustomerID, EmployeeID, OrderDate, RequiredDate, ShippedDate)" +
                                      " VALUES ( @CustomerID, @EmployeeID, @OrderDate, @RequiredDate, @ShippedDate)";
                command.Parameters.AddWithValue("@CustomerID", order.CustomerID);
                command.Parameters.AddWithValue("@EmployeeID", order.EmployeeID);
                command.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                command.Parameters.AddWithValue("@RequiredDate", order.RequiredDate);
                command.Parameters.AddWithValue("@ShippedDate", order.ShippedDate);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteOrder(int orderID)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "DELETE FROM Northwind.Orders" +
                                      $" WHERE OrderID={orderID}";
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void SendOrder(int orderID, DateTime departureDate)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "UPDATE Northwind.Orders" +
                                      " SET OrderDate=@departureDate" +
                                      $" WHERE OrderID={orderID}";
                command.Parameters.AddWithValue("@depatureDate", departureDate);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void MarkOrderShipped(int orderID, DateTime deliveryDate)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "UPDATE Northwind.Orders" +
                                      " SET ShippedDate=@deliveryDate" +
                                      $" WHERE OrderID={orderID}";
                command.Parameters.AddWithValue("@deliveryDate", deliveryDate);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
