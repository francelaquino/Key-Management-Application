using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KeyIssuingAPI.Models
{
    public class mdlKey
    {
        public string id { get; set; }
        public string buildingid { get; set; }
        public string buildingcode { get; set; }
        public string buildingname { get; set; }
        public string room { get; set; }
        public string createdby { get; set; }
        public string level { get; set; }
        public string quantity { get; set; }
        public string keytype { get; set; }
        public string issuedqty { get; set; }
        public string remainingqty { get; set; }
    }
}