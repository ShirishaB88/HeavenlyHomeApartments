using HeavenlyHome_Models.FloorPlanModels;
using HeavenlyHome_Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HeavenlyHomeApartments_WebMVC.Controllers
{
    public class FloorPlanController : Controller
    {
        [Authorize]
        // GET: FloorPlan
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new FloorPlanService(userID);
            var model = service.GetFloorPlans();
            return View(model);
        }

        //GET: FloorPlan/Create
        public ActionResult Create()
        {
            return View();
        }

        //Post: FloorPlan/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FloorPlanCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var service = CreateFloorPlanService();
            if (service.CreateFloorPlan(model))
            {
                TempData["SaveResult"] = "Your Floor plan was created!"; // Temp Data removes information after it's accessed.
                return RedirectToAction("Index");
            }
            
            return RedirectToAction("Index");

        }

        //Get: FloorPlan/Details/{id}
        public ActionResult Details(int id)
        {
            var service = CreateFloorPlanService();
            var model = service.GetFloorPlanByID(id);
            return View(model);
        }

        private FloorPlanService CreateFloorPlanService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FloorPlanService(userId);
            return service;
        }



    }
}