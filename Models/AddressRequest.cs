using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dadata_service.Models
{
    public class AddressRequest
    {
         public string source { get; set; }
         public string result { get; set; }
         public string postal_code { get; set; }
         public string country { get; set; }
         public string house { get; set; }
         public string region { get; set; }
         public string street { get; set; }
    }
}
