using NorthWindWebAPI.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace NorthWindWebAPI.BussinessLogic
{
    public class CustomerRepository : ICustomerRepository, IDisposable
    {
        private static readonly log4net.ILog log =
          log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private Northwind _db = new Northwind();
        public IEnumerable<Customer> GetAllCustomers()
        {
                return _db.Customers;
        }

        public Customer GetCustomer(string id)
        {
            Customer customer = _db.Customers.Find(id);
            return customer;
        }

        public void AddCustomer(Customer cust)
        {
                _db.Customers.Add(cust);
                _db.SaveChanges();
        }

        //public string UpdateCustomer(string id, ViewModel.CustomerViewModel vmCust)
        //{
        //    if (_db.Customers.Count(e => e.CustomerID == id) > 0)
        //    {
                
        //    }
        //}

        public string Deletecustomer(string id)
        {
            Customer customer = _db.Customers.Find(id);
            if (customer == null)
            {
                return "Not found";
            }

            _db.Customers.Remove(customer);
            _db.SaveChanges();

            return "Successfully Deleted";
        }

        public void Dispose()
        {
            if (_db != null)
                _db.Dispose();
        }
    }
}