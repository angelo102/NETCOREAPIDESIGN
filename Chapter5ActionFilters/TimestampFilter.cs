using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter5ActionFilters
{
    public class TimestampFilter : IActionFilter, IAsyncActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            context.ActionDescriptor.RouteValues["timestamp"] = DateTime.Now.ToString();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var ts = DateTime.Parse(context.ActionDescriptor.RouteValues["timestamp"])
                .AddHours(1)
                .ToString();

            context.HttpContext.Response.Headers["X-EXPIRY-TIMESTAMP"] = ts;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            this.OnActionExecuting(context);
            var resultContext = await next();
            this.OnActionExecuted(resultContext);
        }
    }
}
