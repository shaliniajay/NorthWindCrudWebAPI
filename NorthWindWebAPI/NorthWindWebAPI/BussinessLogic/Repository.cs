using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthWindWebAPI.BussinessLogic
{
    public class Repository : IRepository
    {
        public string GetCustomers()
        {
            return "Test Passed";
        }
    }
}