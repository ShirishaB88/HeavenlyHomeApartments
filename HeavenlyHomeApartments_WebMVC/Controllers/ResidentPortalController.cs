using HeavenlyHome_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HeavenlyHomeApartments_WebMVC.Controllers
{
    public class ResidentPortalController : Controller
    {
        private ApplicationDbContext ctx = new ApplicationDbContext();
        // GET: ResidentPortal
        public ActionResult Index()
        {
                          
            return View();
        }
    }
}