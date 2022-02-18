using kanusaoft1.Model;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace kanusaoft1.Models
{
    public class Request
    {
        [BindNever]
        public int RequestId { get; set; }
        public List<RequestDetail> RequestDetails { get; set; }

        [Required(ErrorMessage = "Please Chose Your Supplement")]
       
        public string SupplementName { get; set; }

        [Required(ErrorMessage = "Please Chose Your Location")]
       
        public string Location { get; set; }

        [Required(ErrorMessage = "Please Chose Your SupplementAmount")]
       
        public int SupplementAmount { get; set; }
        public DateTime RequestPlaced { get; set; }
    }
}
