using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kanusaoft1.Model
{
    public interface IlocationRepository
    {
        IEnumerable<location> AllLocations { get; }
    }
}
