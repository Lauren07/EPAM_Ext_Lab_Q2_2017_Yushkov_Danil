using System;

namespace DataAccessLayer.Entities
{
    public class Customer
    {
        public string CustomerID;

        public string CompanyName;

        public string Address;

        public string City;

        public string Country;

        public string Phone;

        public string GenerateID()
        {
            var length = 5;//todo pn вынес бы в константу
            var resultID = string.Empty;
            for (var i = 0; i < length; i++)
            {
                resultID += Convert.ToChar(Randomizer.Random.Next(65, 90));
            }

            return resultID;
        }
    }
}
