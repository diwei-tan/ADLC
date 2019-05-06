using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class FullTimeLead:TourLeader
    {
        public int LeadId { get; set; }
        public string Ranking { get; set; }
        public override double CalculateLeaderCost(int numDays)
        {
            if (Ranking == "M1")
            {
                return  numDays*500.00;
            }
            else if (Ranking == "M2")
            {
                return numDays * 400.00;
            }
            else
            {
                return numDays * 300.00;
            }
        }
    }

}