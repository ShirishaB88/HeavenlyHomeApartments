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
        public ActionResult Index(string searchBy, string search)
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new FloorPlanService(userID);
            var model = service.GetFloorPlans();

            if (searchBy == "Baths")
            {
                return View(model.Where(e => e.NoOfBaths == int.Parse(search) && e.IsAvailable == true));
            }
            else if (searchBy == "Beds")
            {
                return View(model.Where(e => e.NoOfBeds == int.Parse(search) && e.IsAvailable == true));
            }
            else if(searchBy == "Garage")
            {
                return View(model.Where(e => e.NoOfGarageSpaces == int.Parse(search) && e.IsAvailable == true));
            }
            else
            {
                return View(model);
            }
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
                TempData["SaveResult"] = "New Floor plan was created!"; // Temp Data removes information after it's accessed.
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "FloorPlan can not be created");
            
            return View(model);

        }

        //Get: FloorPlan/Details/{id}
        public ActionResult Details(int id)
        {
            var service = CreateFloorPlanService();
            var model = service.GetFloorPlanByID(id);
            return View(model);
        }

        //Get: FloorPlan/Edit/{id}
        public ActionResult Edit(int id)
        {
            var service = CreateFloorPlanService();
            var detail = service.GetFloorPlanByID(id);
            var model =
                new FloorPlanEdit
                {
                    FloorPlanID = detail.FloorPlanID,
                    NoOfBeds = detail.NoOfBeds,
                    NoOfBaths = detail.NoOfBaths,
                    AreaInSqFt = detail.AreaInSqFt,
                    Price = detail.Price,
                    NoOfGarageSpaces = detail.NoOfGarageSpaces,
                    Image = detail.Image,
                    IsAvailable = detail.IsAvailable
                   
                };
            return View(model);
        }

        //Post: FloorPlan/Edit/{id},{FloorPlanEditModel}
       [HttpPost]
       [ValidateAntiForgeryToken]
       public ActionResult Edit(int id, FloorPlanEdit model)
       {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (model.FloorPlanID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }
            var service = CreateFloorPlanService();
            if (service.UpdateFloorPlan(model))
            {
                TempData["SaveResult"] = " FloorPlan was updated";
                return RedirectToAction("Index"); 
            }
            ModelState.AddModelError("", " Floorplan could not be updated");
            return View(model);
        
       }


        //Get: FloorPlan/Delete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateFloorPlanService();
            var model = service.GetFloorPlanByID(id);
            return View(model);
        }

        //Post: FloorPlan/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteFloorPlan(int id)
        {
            var service = CreateFloorPlanService();
            service.DeleteFloorPlan(id);

            TempData["SaveResult"] = " Floor Plan was deleted";
            return RedirectToAction ("Index");

        }

        private FloorPlanService CreateFloorPlanService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FloorPlanService(userId);
            return service;
        }



    }
}