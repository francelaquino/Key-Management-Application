using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KeyIssuingAPI.Models
{
    public class mdlRequest
    {
        public string id { get; set; }
        public string keyid { get; set; }
        public string keycode { get; set; }
        public string status { get; set; }
        public string employeeno { get; set; }
        public string employeename { get; set; }
        public string requestquantity { get; set; }
        public string section { get; set; }
        public string extension { get; set; }
        public string notes { get; set; }
        public string building { get; set; }
        public string level { get; set; }
        public string room { get; set; }
        public string keytype { get; set; }
        public string returndate { get; set; }
        public string quantity { get; set; }
        public string issuancetype { get; set; }
        public string daterequested { get; set; }
        public string dateissued { get; set; }
        public string daterejected { get; set; }
        public string buildingid { get; set; }
        public string username { get; set; }
        public string statusid { get; set; }
        public string actualreturneddate { get; set; }
        public string code { get; set; }
        
    }
}