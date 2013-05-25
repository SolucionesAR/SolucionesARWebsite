using System.Collections.Generic;
using SolucionesARWebsite2.Models;

namespace SolucionesARWebsite2.DataAccess.Interfaces
{
    public interface ICustomersRepository
    {
        List<Customer> GetAllCustomers();

        Customer GetCustomer(int customerId);

        void AddCustomer(Customer customer);

        void EditCustomer(Customer customer);
    }
}
