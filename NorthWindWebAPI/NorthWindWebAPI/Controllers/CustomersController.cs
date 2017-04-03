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
using NorthWindWebAPI.CustomFilters;
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
                var allCustomers = _custRepository.GetAllCustomers();

                return Ok(allCustomers);
            }
            catch (Exception ex)
            {
                log.Error("Failed");
                return InternalServerError();

            }

        }

      
        [HttpPost]
        //[ValidationActionFilter]
         [ValidateModelState]
        public HttpResponseMessage PostCustomer([FromBody] CustomerViewModel custvm)
        {
            try
            {
                {
                    var newCust = Mapper.Map<Customer>(custvm);
                    //add to database
                    _custRepository.AddCustomer(newCust);
                    log.Info("Added Customer");
                    return Request.CreateResponse(HttpStatusCode.OK,"Successfully Added");
                }
            }
            catch (Exception ex)
            {
                log.Error("Cannot be Added " + ex.Message);
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        // GET: api/Customers/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult GetCustomer(string id)
        {
            var result = _custRepository.GetCustomer(id);

            return Ok(result);
        }


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

          // db.Entry(customer).State = EntityState.Modified;

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



        // DELETE: api/Customers/5
       [HttpPost]
        public IHttpActionResult DeleteCustomer(string id)
        {
            try
            {
                var result = _custRepository.Deletecustomer(id);
                log.Info("Deleted Customer with id =" + id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error("cannot delete" + ex);
                throw;
            }
           
        }

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