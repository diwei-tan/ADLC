using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.DAO;

namespace WebApplication1.Controllers
{
    public class AssignmentController : Controller
    {
        // GET: Assignment
        public ActionResult ViewTour()
        {
            ViewData["Tours"] = TourDAO.getTours();
            return View();
        }
        public ActionResult ViewTourLeader(string TourId, string DesCode)
        {
            if(TourId==null || DesCode == null)
            {
                return RedirectToAction("ViewTour");
            }
            ViewData["Leaders"] = LeaderDAO.getAvailableLeaders(DesCode);
            ViewData["TourId"] = TourId;
            return View();
        }
        public ActionResult AssignTourLeader(string TourId, string TourLeaderId)
        {
            if(TourId==null || TourLeaderId == null)
            {
                return RedirectToAction("ViewTour");
            }
            TourDAO.AssignTourLeader(TourId, TourLeaderId);
            return RedirectToAction("ViewTour");
        }
    }
}