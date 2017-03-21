using NorthWindWebAPI.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthWindWebAPI.BussinessLogic
{
    public class CustomerRepository : ICustomerRepository, IDisposable
    {
        private Northwind _db = new Northwind();
        public IQueryable<Customer> GetAllCustomers()
        {
            try
            {
                return _db.Customers;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public Customer GetCustomer(string id)
        {
            Customer customer = _db.Customers.Find(id);
            return customer;
        }

        public string AddCustomer(string id, ViewModel.CustomerViewModel vmCust)
        {
            throw new NotImplementedException();
        }

        public string Deletecustomer(string id)
        {
            throw new NotImplementedException();
        }



        public void Dispose()
        {
            if (_db != null)
                _db.Dispose();
        }
    }
}