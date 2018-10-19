using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Chapter5ActionFilters.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
   
        public string Get(string timestamp)
        {
            return $"Request received at {timestamp}";
        }

       
    }
}
