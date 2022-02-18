using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace kanusaoft1.Model
{
    public class supplement
    {
        [Key]
        public string name { get; set; }
        public int amount { get; set; }
        public location location { get; set; }

    }
}
