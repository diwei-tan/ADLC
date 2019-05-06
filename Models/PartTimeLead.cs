using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class PartTimeLead:TourLeader
    {
        public int LeadId { get; set; }
        public double Salary { get; set; }
        public override double CalculateLeaderCost(int numDays)
        {
            return Salary * numDays;
        }
    }
}