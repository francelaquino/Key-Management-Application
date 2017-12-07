using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KeyIssuingAPI.Models
{
    public class mdlLevel
    {
        public string id { get; set; }
        public string building { get; set; }
        public string buildingcode { get; set; }
        public string buildingname { get; set; }
        public string level { get; set; }
        public string active { get; set; }
    }
}