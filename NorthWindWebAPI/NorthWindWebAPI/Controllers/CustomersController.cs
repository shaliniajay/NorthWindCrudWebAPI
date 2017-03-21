using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.Ajax.Utilities;
using NorthWindWebAPI.BussinessLogic;
using NorthWindWebAPI.DataModel;
using NorthWindWebAPI.ViewModel;

namespace NorthWindWebAPI.Controllers
{
    public class CustomersController : ApiController
    {
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private Northwind db = new Northwind();

        public IRepository _repository;

        
         public CustomersController(IRepository repository)
       {
           _repository = repository;
       }

        [System.Web.Http.HttpGet]
         public string TestIoc()
        {

            log.Info("Ioc test passed");
             return _repository.GetCustomers();

             //return db.Customers;
        }

        [System.Web.Http.HttpGet]
        public IQueryable<Customer> GetCustomers()
        {

            log.Info("Get customer is working");
           
          
            return db.Customers;
        }

        // GET: api/Customers/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult GetCustomer(string id)
        {
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // PUT: api/Customers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomer(string id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customer.CustomerID)
            {
                return BadRequest();
            }

            db.Entry(customer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [System.Web.Http.HttpPost]
        public string PostCustomer([FromBody] CustomerViewModel custvm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newCust = Mapper.Map<Customer>(custvm);
                    //add to database
                    
                    log.Info("Added to database");
                    return "Added";

                }
            }
            catch (Exception ex)
            {
                
                log.Error("Cannot be Added " + ex );
            }
            
            return "Failed";
        }

        // DELETE: api/Customers/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult DeleteCustomer(string id)
        {
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }

            db.Customers.Remove(customer);
            db.SaveChanges();

            return Ok(customer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerExists(string id)
        {
            return db.Customers.Count(e => e.CustomerID == id) > 0;
        }
    }
}