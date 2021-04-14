
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TripsAPI.Exceptions;

namespace TripsAPI.ActionFilters
{

    public class ServiceExceptionInterceptor : ExceptionFilterAttribute, IExceptionFilter
    {
        public override void OnException(ExceptionContext context)
        {
            var error = new ErrorDetails();

            if (context.Exception is TripsQueryException)
            {
                error.StatusCode = 400;
                error.Message = "Invalid Query Parameters.";
            }
            else 
            {
                error.StatusCode = 500;
                error.Message = "Internal Server Error.";
            }

            context.Result = new JsonResult(error);
        }
    }
}