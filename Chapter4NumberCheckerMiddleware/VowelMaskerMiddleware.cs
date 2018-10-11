using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Chapter4NumberCheckerMiddleware
{
    public class VowelMaskerMiddleware
    {
        private readonly RequestDelegate next;

        public VowelMaskerMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var value = context.Items["value"].ToString();
            context.Items["value"] = Regex.Replace(value, "(?<!^)[AEUI](?!$)", "*");
            await next(context);
        }
    }
}
