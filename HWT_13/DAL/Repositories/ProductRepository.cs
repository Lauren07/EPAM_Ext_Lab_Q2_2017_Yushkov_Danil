using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer
{
    public class ProductRepository : IProductRepository
    {
        private string connectionString;

        public ProductRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Product> GetAllProducts()
        {
            var products = new List<Product>();
            using (var connection = new SqlConnection(this.connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText =
                    "SELECT prod.ProductID, prod.ProductName, prod.UnitPrice, prod.UnitsInStock" +
                    " FROM Northwind.Products prod";
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            ProductID = (int)reader["ProductID"],
                            ProductName = (string)reader["ProductName"],
                            UnitPrice = (double)((decimal)reader["UnitPrice"]),
                            UnitsInStock = (short)reader["UnitsInStock"],
                        });
                    }
                }
            }

            return products;
        }

        public void AddProductInOrder(ProductDetails product)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText =
                    "INSERT INTO Northwind.[Order Details](OrderID, ProductID, UnitPrice, Quantity, Discount)" +
                    " VALUES (@OrderID, @ProductID, @UnitPrice, @Quantity, @Discount)";
                command.Parameters.AddWithValue("@OrderID", product.OrderID);
                command.Parameters.AddWithValue("@ProductID", product.ProductID);
                command.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
                command.Parameters.AddWithValue("@Quantity", product.Quantity);
                command.Parameters.AddWithValue("@Discount", product.Discount);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public Product FindProduct(int productID)
        {
            Product requestedProduct = null;
            using (var connection = new SqlConnection(this.connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT prod.ProductID, prod.ProductName, prod.UnitPrice, prod.UnitsInStock FROM Northwind.Products prod" +
                                      $" WHERE ProductID={productID}";
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        requestedProduct = new Product
                        {
                            ProductID = (int)reader["ProductID"],
                            ProductName = (string)reader["ProductName"],
                            UnitPrice = (double)((decimal)reader["UnitPrice"]),
                            UnitsInStock = (short)reader["UnitsInStock"],
                        };
                    }
                }
            }

            return requestedProduct;
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
                            OrderID = orderID,
                            ProductID = (int)reader["ProductID"],
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
