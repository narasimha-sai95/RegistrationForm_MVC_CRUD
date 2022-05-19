using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace final.Models
{
    public class emp
    {

        public int id { get; set; }
        
        public string Name { get; set; }
       
        public string MobileNumber { get; set; }

       
        public string Email { get; set; }

        public string Designation { get; set; }

        public string Department { get; set; }

        public string OfficeLocation { get; set; }
    }
}