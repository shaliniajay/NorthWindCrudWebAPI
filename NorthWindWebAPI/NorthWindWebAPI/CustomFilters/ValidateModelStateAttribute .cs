using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace NorthWindWebAPI.CustomFilters
{
    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
       //         actionContext.Response = actionContext.Request.CreateErrorResponse(
       //HttpStatusCode.BadRequest, actionContext.ModelState);
                //or

                var errorList = (from item in actionContext.ModelState.Values
                                 from error in item.Errors
                                 select error.ErrorMessage).ToList();

                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest, errorList);
            }
        }
    }
}