using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace kanusaoft1.Model
{
    public class location
    {
        [Key]
        public string address { get; set; }
        
        public string name { get; set; }
        public List<supplement> supplement { get; set; }
    }
}