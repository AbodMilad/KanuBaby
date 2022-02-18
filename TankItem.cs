using kanusaoft1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kanusaoft1.Models
{
    public class TankItem
    {
        public int TankItemId { get; set; }
        public supplement supplement { get; set; }
        public location location { get; set; }
        public int Amount { get; set; }
        public string TankId { get; set; }
        public string  SupplementName { get; set; }
        public string Location { get; set; }
    }
}
