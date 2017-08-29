using System;

namespace DataAccessLayer.Entities
{
    public class Customer
    {
        private const int LengthID = 5;

        public string CustomerID;

        public string CompanyName;

        public string Address;

        public string City;

        public string Country;

        public string Phone;

        public string GenerateID()
        {
            var resultID = string.Empty;
            for (var i = 0; i < LengthID; i++)
            {
                resultID += Convert.ToChar(Randomizer.Random.Next(65, 90));
            }

            return resultID;
        }
    }
}
