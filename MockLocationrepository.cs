using kanusaoft1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kanusaoft1.Models
{
    public class MockLocationrepository : IlocationRepository
    {
        public IEnumerable<location> AllLocations =>
            new List<location>
            {
                new location {name="Khaled", address="Wsta"},
                new location {name="jacop", address="Al-Armn"},
                new location {name="samer", address="Arboye"}
            };
           
            
           
    }
}
