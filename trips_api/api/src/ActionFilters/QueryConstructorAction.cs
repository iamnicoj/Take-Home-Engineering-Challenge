
using System;
using Microsoft.AspNetCore.Mvc.Filters;
using TripsAPI.Controllers;
using TripsAPI.Models;
using TripsAPI.Exceptions;


namespace TripsAPI.ActionFilters
{
    public class BuildQueryActionFilter : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext  filterContext)
        {
            var Controller = filterContext.Controller as TripsInfoController;

            Controller._query = new Models.DTOs.TripsQuery();

            try{
                if(!string.IsNullOrEmpty(filterContext.HttpContext.Request.Query["startdate"]))
                    Controller._query.StartDateTimeFilter = System.Convert.ToDateTime(filterContext.HttpContext.Request.Query["startdate"]);
                if(!string.IsNullOrEmpty(filterContext.HttpContext.Request.Query["EndDate"]))
                    Controller._query.EndDateTimeFilter = System.Convert.ToDateTime(filterContext.HttpContext.Request.Query["EndDate"]);
                if(!string.IsNullOrEmpty(filterContext.HttpContext.Request.Query["puborough"]))
                    Controller._query.PickUpBoroughFilter = filterContext.HttpContext.Request.Query["puborough"];
                if(!string.IsNullOrEmpty(filterContext.HttpContext.Request.Query["doborough"]))
                    Controller._query.DropOffBoroughFilter = filterContext.HttpContext.Request.Query["doborough"];
                if(!string.IsNullOrEmpty(filterContext.HttpContext.Request.Query["puzone"]))
                    Controller._query.PickUpZoneFilter = filterContext.HttpContext.Request.Query["puzone"];
                if(!string.IsNullOrEmpty(filterContext.HttpContext.Request.Query["dozone"]))
                    Controller._query.DropOffZoneFilter = filterContext.HttpContext.Request.Query["dozone"];
                if(!string.IsNullOrEmpty(filterContext.HttpContext.Request.Query["provider"])){
                    ServiceType param;
                    Enum.TryParse(filterContext.HttpContext.Request.Query["provider"], true, out param);
                    if (param == ServiceType.None)
                        throw new ArgumentException("No Valid Service Type");
                    Controller._query.ServiceTypeFilter = param;
                }
            }
            catch(Exception ex){
                throw new TripsQueryException("BadRequestException", ex);
            }

            string requestid = filterContext.HttpContext.Request.Headers["X-request-ID"];
            if(string.IsNullOrEmpty(requestid)){
                requestid = Guid.NewGuid().ToString();
                filterContext.HttpContext.Request.Headers["X-request-ID"] = requestid;
            }

            Controller._telemetry.TraceCustomEvent(requestid, filterContext.HttpContext.Request.Path, Controller._query);

        }

        public override void OnActionExecuted (ActionExecutedContext filterContext)
        {
            // TODO this must be its own filter. I shoudn't be here.
            filterContext.HttpContext.Response.Headers.Add("X-request-ID", filterContext.HttpContext.Request.Headers["X-request-ID"]);
        }
    }
}