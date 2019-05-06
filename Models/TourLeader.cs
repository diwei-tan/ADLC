using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public abstract class TourLeader
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please enter a name.")]
        public string Name { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Role { get; set; }

        public abstract double CalculateLeaderCost(int numDays);

    }

}