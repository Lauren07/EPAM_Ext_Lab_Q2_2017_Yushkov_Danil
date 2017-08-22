using System;
using System.Collections.Generic;

namespace WebApplication.Models
{
    public class OrderInfoViewModel
    {
        public int OrderID;

        public DateTime? OrderDate;

        public string CompanyName;

        public string Phone;

        public string FullShipAddress;

        public double TotalPrice;

        public IEnumerable<ProductViewModel> Products;
    }
}