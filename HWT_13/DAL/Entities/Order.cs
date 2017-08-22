using System;

namespace DataAccessLayer.Entities
{
    public enum OrderStatus
    {
        Unknown,
        NotSent,
        Sent,
        Shipped
    }

    public class Order
    {
        public int OrderID;

        public string CustomerID;

        public int? EmployeeID;

        private DateTime? orderDate;

        public DateTime? OrderDate
        {
            get
            {
                return this.orderDate;
            }

            set
            {
                if (value == null)
                {
                    this.OrderState = OrderStatus.NotSent;
                }

                this.orderDate = value;
            }
        }

        public DateTime? RequiredDate;

        private DateTime? shippedDate;

        public DateTime? ShippedDate
        {
            get
            {
                return this.shippedDate;
            }

            set
            {
                if (this.OrderState != OrderStatus.NotSent)
                {
                    this.OrderState = value == null ? OrderStatus.Sent : OrderStatus.Shipped;
                }

                this.shippedDate = value;
            }
        }

        public OrderStatus OrderState;

        public string ShipAddress;

        public string ShipCity;

        public string ShipCountry;

        //public int ShipVia;

        //public int Freight;

        //public string ShipName;

        //public string ShipRegion;

        //public string ShipPostalCode;
    }
}
