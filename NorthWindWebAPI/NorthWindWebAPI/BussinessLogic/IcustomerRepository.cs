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
        IQueryable<Customer> GetAllCustomers();
        Customer GetCustomer(string id);
        string AddCustomer(string id, CustomerViewModel vmCust);
        string Deletecustomer(string id);
    }
}
