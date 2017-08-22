using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer
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
                command.CommandText = "SELECT OrderID, CustomerID, EmployeeID, OrderDate, RequiredDate, ShippedDate, ShipAddress, ShipCity, ShipCountry" +
                                      " FROM Northwind.Orders";
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        orders.Add(new Order
                        {
                            OrderID = (int)reader["OrderID"],
                            CustomerID = (string)reader["CustomerID"],
                            EmployeeID = reader["EmployeeID"] as int?,
                            OrderDate = reader["OrderDate"] as DateTime?,
                            RequiredDate = reader["RequiredDate"] as DateTime?,
                            ShippedDate = reader["ShippedDate"] as DateTime?,
                            ShipAddress = reader["ShipAddress"] as string,
                            ShipCity = reader["ShipCity"] as string,
                            ShipCountry = reader["ShipCountry"] as string
                        });
                    }
                }
            }

            return orders;
        }

        public void EditOrder(Order order)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "UPDATE Northwind.Orders" +
                                      " SET ShipAddress=@ShipAddress, ShipCity=@ShipCity, ShipCountry=ShipCountry" +
                                      " WHERE OrderID=@OrderID";
                command.Parameters.AddWithValue("@OrderID", order.OrderID);
                command.Parameters.AddWithValue("@ShipAddress", order.ShipAddress);
                command.Parameters.AddWithValue("@ShipCity", order.ShipCity);
                command.Parameters.AddWithValue("@ShipCountry", order.ShipCountry);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public Order FindOrder(int orderID)
        {
            Order requestedOrder = null;
            using (var connection = new SqlConnection(this.connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT OrderID, CustomerID, EmployeeID, OrderDate, RequiredDate, ShippedDate, ShipAddress, ShipCity, ShipCountry" +
                                      " FROM Northwind.Orders" +
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
                            EmployeeID = reader["EmployeeID"] as int?,
                            OrderDate = reader["OrderDate"] as DateTime?,
                            RequiredDate = reader["RequiredDate"] as DateTime?,
                            ShippedDate = reader["ShippedDate"] as DateTime?,
                            ShipAddress = reader["ShipAddress"] as string,
                            ShipCity = reader["ShipCity"] as string,
                            ShipCountry = reader["ShipCountry"] as string
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
                command.CommandText = "INSERT INTO Northwind.Orders(CustomerID, OrderDate, ShipAddress, ShipCity, ShipCountry)" +
                                      " VALUES ( @CustomerID, @OrderDate, @ShipAddress, @ShipCity, @ShipCountry )";
                command.Parameters.AddWithValue("@CustomerID", order.CustomerID);
                command.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                command.Parameters.AddWithValue("@ShipAddress", order.ShipAddress);
                command.Parameters.AddWithValue("@ShipCity", order.ShipCity);
                command.Parameters.AddWithValue("@ShipCountry", order.ShipCountry);
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

        public void DeleteOrderDetails(int orderID)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "DELETE FROM Northwind.[Order Details]" +
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
