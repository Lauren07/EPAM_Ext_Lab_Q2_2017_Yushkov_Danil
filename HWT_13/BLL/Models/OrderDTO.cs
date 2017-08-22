using System;

namespace BLL.Models
{
    public class OrderDTO
    {
        public CustomerDTO Customer;

        public string CustomerID;

        public int OrderID;

        public DateTime? OrderDate;

        public int EmployeeID;

        public string ShipAddress;

        public string ShipCity;

        public string ShipCountry;
    }
}
