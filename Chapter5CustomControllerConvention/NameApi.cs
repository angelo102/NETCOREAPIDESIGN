using Chapter5CustomControllerConvention;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.People
{
    public class NameApi
    {
        private readonly IPeopleRepository people;

        public NameApi(IPeopleRepository people)
        {
            this.people = people;
        }

        public IActionResult Get()
        {
            return new OkObjectResult(people.All);
        }
    }
}
