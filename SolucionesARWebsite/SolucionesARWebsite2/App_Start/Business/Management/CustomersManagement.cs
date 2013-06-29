using System;
using System.Collections.Generic;
using SolucionesARWebsite2.DataAccess.Interfaces;
using SolucionesARWebsite2.Models;
using SolucionesARWebsite2.ViewModels.Customers;

namespace SolucionesARWebsite2.Business.Management
{
    public class CustomersManagement
    {
        #region Constants
        #endregion

        #region Properties
        #endregion

        #region Private Members

        private readonly ICustomersRepository _customersRepository;

        #endregion

        #region Public Methods
        public CustomersManagement(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        public List<Customer> GetCustomers()
        {
            return _customersRepository.GetAllCustomers();
        }

        public Customer GetCustomers(int customerId)
        {
            return _customersRepository.GetCustomer(customerId);
        }

        public void Save(EditViewModel editViewModel)
        {
            var customer = Map(editViewModel);
            
            if (editViewModel.CustomerId.Equals(0))
            {
                AddCustomer(customer);
            }
            else
            {
                EditCustomer(customer);
            }
        }

        

        #endregion

        #region Private Methods
        private static Customer Map(EditViewModel editViewModel)
        {
            var customer = new Customer
                               {
                                   CustomerId = editViewModel.CustomerId,
                                   Boss = editViewModel.Boss,
                                   CedNumber = editViewModel.CedNumber,
                                   FName = editViewModel.FName,
                                   LName = editViewModel.LName,
                                   PhoneNumber = editViewModel.PhoneNumber,
                                   Possition = editViewModel.Possition,
                                   Salary = editViewModel.Salary,
                                   CreatedAt = editViewModel.CreatedAt
                               };

            return customer;
        }

        private void AddCustomer(Customer customer)
        {
            customer.CreatedAt = DateTime.Now;
            customer.UpdatedAt = DateTime.Now;
            _customersRepository.AddCustomer(customer);
        }

        private void EditCustomer(Customer customer)
        {
            customer.UpdatedAt = DateTime.Now;
            _customersRepository.EditCustomer(customer);
        }
        #endregion

        public Customer GetCustomer(int id)
        {
            return _customersRepository.GetCustomer(id);
        }
    }
}