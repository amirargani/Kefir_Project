using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace KefirWebsite.Filter
{
    public class DBValidateFilter : ExceptionFilterAttribute, System.Web.Mvc.IResultFilter
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if(actionExecutedContext.Exception is DbEntityValidationException)
            {
                string messages = "" ;
                DbEntityValidationException ex = (DbEntityValidationException)actionExecutedContext.Exception;
                messages = string.Join("، ", ex.EntityValidationErrors
                                      .SelectMany(x => x.ValidationErrors)
                                      .Select(x => x.ErrorMessage));
                try
                {
                    foreach (var s in actionExecutedContext.ActionContext.ModelState["MyError"].Errors)
                    {
                        if (messages != "") messages += " ،";
                        messages += s.ErrorMessage;
                    }
                }
                catch { }
                actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(System.Net.HttpStatusCode.BadRequest,new { Message= messages });
                
            }
        }

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            
        }
    }
}