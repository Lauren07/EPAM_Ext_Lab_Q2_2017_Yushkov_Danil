using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Task01.Entities;
using Task01.Interfaces;

namespace Task01
{
    public class ProductRepository : IProductRepository
    {
        private string connectionString;

        public ProductRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Product> GetAllProductsFromOrder(int orderID)
        {
            var products = new List<Product>();
            using (var connection = new SqlConnection(this.connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText =
                    "SELECT products.ProductID, products.ProductName, orders.UnitPrice, orders.Quantity, orders.Discount" +
                    " FROM Northwind.[Order Details] orders" +
                    " JOIN Northwind.Products products" +
                    $" ON orders.OrderID={orderID} AND orders.ProductID=products.ProductID";
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    var i = 0;
                    while (reader.Read())
                    {
                        i++;
                        products.Add(new Product
                        {
                            ProductID = (int)reader["ProductID"],
                            ProductName = (string)reader["ProductName"],
                            Discount = (float)reader["Discount"],
                            UnitPrice = (double)((decimal)reader["UnitPrice"]),
                            Quantity = (short)reader["Quantity"],
                        });
                    }
                }
            }

            return products;
        }

        public List<CustomerProductInfo> GetCustomerProductsInfo(string customerID)
        {
            var productsInfo = new List<CustomerProductInfo>();
            using (var connection = new SqlConnection(this.connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "Northwind.CustOrderHist";
                command.CommandType = CommandType.StoredProcedure;
                var customerParam = new SqlParameter
                {
                    ParameterName = "@CustomerID",
                    Value = customerID
                };
                command.Parameters.Add(customerParam);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        productsInfo.Add(new CustomerProductInfo
                        {
                            ProductName = (string)reader["ProductName"],
                            TotalCountProduct = (int)reader["Total"]
                        });
                    }
                }
            }

            return productsInfo;
        }

        public List<ProductDetails> GetAllProductsOrder(int orderID)
        {
            var products = new List<ProductDetails>();
            using (var connection = new SqlConnection(this.connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "Northwind.CustOrdersDetail";
                command.CommandType = CommandType.StoredProcedure;
                var orderParam = new SqlParameter
                {
                    ParameterName = "@OrderID",
                    Value = orderID
                };
                command.Parameters.Add(orderParam);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(new ProductDetails()
                        {
                            ProductName = (string)reader["ProductName"],
                            Discount = (int)reader["Discount"],
                            UnitPrice = (double)((decimal)reader["UnitPrice"]),
                            Quantity = (short)reader["Quantity"],
                            ExtendedPrice = (double)((decimal)reader["ExtendedPrice"])
                        });
                    }
                }
            }

            return products;
        }
    }
}
