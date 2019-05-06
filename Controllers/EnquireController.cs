using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using WebApplication1.Models;
using WebApplication1.DAO;

namespace WebApplication1.Controllers
{
    public class EnquireController : Controller
    {
        // GET: test
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult getLeaderCost(string Name, string NumDays)
        {
            if (Name == null)
            {
                return View();
            }

            if (!LeaderDAO.getLeader(Name, out TourLeader tourLeader))
            {
                return RedirectToAction("getLeaderCost");
            }
            else
            {
                ViewData["Name"] = Name;
                ViewData["Leader"] = tourLeader;
                ViewData["Days"] = NumDays; 
                ViewData["Cost"] = tourLeader.CalculateLeaderCost(int.Parse(NumDays));
                return View();
            }
        }
    }
}