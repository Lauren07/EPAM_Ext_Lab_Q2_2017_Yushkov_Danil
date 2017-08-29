using System;

namespace DataAccessLayer.Entities
{
    public class ProductDetails
    {
        public const int Accuracy = 2;
        public int OrderID;

        public int ProductID;

        public string ProductName;

        public double UnitPrice;

        public int Quantity;

        public int Discount;

        public double ExtendedPrice
        {
            get { return Math.Round(Quantity * (1 - (Discount / 100.0)) * UnitPrice, Accuracy); }
        }
    }
}
