using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using SolucionesARWebsite2.DataAccess.Interfaces;
using SolucionesARWebsite2.Models;

namespace SolucionesARWebsite2.DataAccess.Repositories
{
    public class CustomersRepository: ICustomersRepository
    {

        #region Constants
        #endregion

        #region Properties
        #endregion

        #region Private Members

        private readonly DbModel _databaseModel;

        #endregion

        #region Contructors

        public CustomersRepository()
        {
            _databaseModel = new DbModel();
        }

        #endregion

        #region Public Methods
        public List<Customer> GetAllCustomers()
        {
            return _databaseModel.Customers.ToList();
        }

        public Customer GetCustomer(int customerId)
        {
            return _databaseModel.Customers.First(x => x.CustomerId.Equals(customerId));
        }

        public void AddCustomer(Customer customer)
        {
            _databaseModel.Customers.Add(customer);
            _databaseModel.SaveChanges();
        }

        public void EditCustomer(Customer customer)
        {
            _databaseModel.Entry(customer).State = EntityState.Modified;
            _databaseModel.SaveChanges();
        }
        #endregion

        #region Private Methods

        #endregion
    }
}