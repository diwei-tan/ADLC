using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Tour
    {
        public int Id { get; set; }
        public string Destination { get; set; }
        public string DesCode { get; set; }
        public int NumDays { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int AssignedLeadId { get; set; }
    }

}