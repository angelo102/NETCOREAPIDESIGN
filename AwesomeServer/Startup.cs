using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace AwesomeServer
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {

            app.MapWhen(c => c.Request.Path == "/foo/bar", config =>
            {
                config.Run(async (context) =>
                {
                    context.Response.StatusCode = 200;
                    await context.Response.WriteAsync("Hello World!");
                });
            })
            .Run(async (context) =>
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync("Not Found");
            });
        }
    }
}
