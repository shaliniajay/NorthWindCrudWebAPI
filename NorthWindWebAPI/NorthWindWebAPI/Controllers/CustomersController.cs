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

        private ICustomerRepository _custRepository;


        public CustomersController(ICustomerRepository custRepository)
        {
            _custRepository = custRepository;
        }


        [HttpGet]
        public IHttpActionResult AllCustomers()
        {
            try
            {
                log.Info("Get allcustomer is working");
                return Ok(_custRepository.GetAllCustomers());
            }
            catch (Exception ex)
            {
                log.Error("Failed");
                return InternalServerError();

            }

        }

      
        [HttpPost]
        //[ValidationActionFilter]
        public HttpResponseMessage PostCustomer([FromBody] CustomerViewModel custvm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newCust = Mapper.Map<Customer>(custvm);
                    //add to database

                    log.Info("Added to database");

                }


            }
            catch (Exception ex)
            {

                log.Error(Request.CreateResponse("Cannot be Added " + ex));
            }

            var errorList = (from item in ModelState.Values
                             from error in item.Errors
                             select error.ErrorMessage).ToList();

            return Request.CreateResponse(HttpStatusCode.NotAcceptable, errorList);

        }

        //// GET: api/Customers/5
        //[ResponseType(typeof(Customer))]
        //public IHttpActionResult GetCustomer(string id)
        //{
        //    Customer customer = db.Customers.Find(id);
        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(customer);
        //}


        //// PUT: api/Customers/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutCustomer(string id, Customer customer)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != customer.CustomerID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(customer).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CustomerExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

      

        //// DELETE: api/Customers/5
        //[ResponseType(typeof(Customer))]
        //public IHttpActionResult DeleteCustomer(string id)
        //{
        //    Customer customer = db.Customers.Find(id);
        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Customers.Remove(customer);
        //    db.SaveChanges();

        //    return Ok(customer);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool CustomerExists(string id)
        //{
        //    return db.Customers.Count(e => e.CustomerID == id) > 0;
        //}
    }
}