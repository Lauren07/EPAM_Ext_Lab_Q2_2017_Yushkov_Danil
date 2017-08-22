using DataAccessLayer.Entities;

namespace DataAccessLayer.Interfaces
{
    public interface ICustomerRepository
    {
        Customer GetCustomer(string customerId);

        void AddCustomer(Customer customer);

        void EditCustomer(Customer customer);
    }
}
