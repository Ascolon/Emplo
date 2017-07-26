using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employee.Models
{
    public class Division
    {
        public int DivisionId { get; set; }

        public string DivisionName { get; set; }

        public string DivisionParent { get; set; }

        public string DivisionType { get; set; }
    }
}