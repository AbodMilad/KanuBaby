using kanusaoft1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kanusaoft1.ViewModel
{
    public class HomeViewModel
    {
        public IEnumerable<supplement> Supplements { get; set; }
        public IEnumerable<location> locations { get; set; }
    }
}
