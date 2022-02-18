using kanusaoft1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kanusaoft1.Models
{
    public class MocksupplementRepository : IsupplementRepository
    {
        private readonly IlocationRepository _locationRepository = new MockLocationrepository();
        public IEnumerable<supplement> Allsuplements =>
            new List<supplement>
            {
                new supplement {name="Water",amount=20},
                new supplement {name="Gazolen", amount=40},
                new supplement {name="Diesel", amount=50}
            };

        public supplement GetSupplementByname(string name)
        {
            return Allsuplements.FirstOrDefault(s => s.name == name);
        }
    }
}
