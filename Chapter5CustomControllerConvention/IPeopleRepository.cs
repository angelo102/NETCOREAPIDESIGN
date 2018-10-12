using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter5CustomControllerConvention
{
    public interface IPeopleRepository
    {
        IEnumerable<string> All { get; }
    }
}
