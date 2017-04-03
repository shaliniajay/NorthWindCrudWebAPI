using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthWindWebAPI.DataModel;
using NorthWindWebAPI.ViewModel;

namespace NorthWindWebAPI.BussinessLogic
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomer(string id);
        void AddCustomer(Customer cust);
      //  string UpdateCustomer(string id, CustomerViewModel vmCust);
        string Deletecustomer(string id);
    }
}
