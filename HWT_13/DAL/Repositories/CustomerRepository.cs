using System.Data.SqlClient;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private string connectionString;

        public CustomerRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Customer GetCustomer(string customerId)
        {
            Customer requestedCustomer = null;
            using (var connection = new SqlConnection(this.connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT CustomerID, CompanyName, Address, City, Country, Phone" +
                                      " FROM Northwind.Customers" +
                                      " WHERE CustomerID=@customerId";
                command.Parameters.AddWithValue("@customerId", customerId);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        requestedCustomer = new Customer
                        {
                            CustomerID = (string)reader["CustomerID"],
                            CompanyName = (string)reader["CompanyName"],
                            Address = reader["Address"] as string,
                            City = reader["City"] as string,
                            Country = reader["Country"] as string,
                            Phone = (string)reader["Phone"]
                        };
                    }
                }
            }

            return requestedCustomer;
        }

        public void AddCustomer(Customer customer)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText =
                    "INSERT INTO Northwind.Customers(CustomerID, CompanyName, Phone)" +
                    " VALUES (@CustomerID, @CompanyName, @Phone)";
                command.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
                command.Parameters.AddWithValue("@CompanyName", customer.CompanyName);
                command.Parameters.AddWithValue("@Phone", customer.Phone);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void EditCustomer(Customer customer)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "UPDATE Northwind.Customers" +
                                      " SET CompanyName=@CompanyName, Phone=@Phone" +
                                      " WHERE CustomerID=@CustomerID";
                command.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
                command.Parameters.AddWithValue("@CompanyName", customer.CompanyName);
                command.Parameters.AddWithValue("@Phone", customer.Phone);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
