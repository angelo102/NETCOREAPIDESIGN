using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter4NumberCheckerMiddleware
{
    public class SkipAppMiddleware
    {
        private readonly RequestDelegate next;
        public SkipAppMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync($"Skip the line!");
        }
    }
}
