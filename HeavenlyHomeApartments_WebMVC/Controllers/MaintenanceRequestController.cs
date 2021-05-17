using HeavenlyHome_Data;
using HeavenlyHome_Models.MaintenanceRequestModels;
using HeavenlyHome_Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HeavenlyHomeApartments_WebMVC.Controllers
{
    [Authorize]
    public class MaintenanceRequestController : Controller
    {

        // GET: MaintenanceRequest
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new MaintenanceRequestService(userID);
            var model = service.GetAllMaintenanceRequests();
            return View(model);
        }

        //GET: MaintenanceRequestCreate
        public ActionResult Create()
        {
            return View();
        }
        //CREATE: MaintenanceRequestCreate

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MaintenanceRequestCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateMaintenanceRequestService();
            if (service.CreateMaintenanceRequest(model))
            {
                TempData["SaveResult"] = " Your new Maintenance Request been added we will get back to you soon!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Maintenance Request can not be added");
            return View(model);
        }

        //GET: MaintenanceRequest/Details/{id}
        public ActionResult Details(int id)
        {
            var service = CreateMaintenanceRequestService();
            var model = service.GetByRequestID(id);
            return View(model);
        }
        //GET MaintenanceRequest/Edit/{id}

        public ActionResult Edit(int id)
        {
            var service = CreateMaintenanceRequestService();
            var details = service.GetByRequestID(id);
            MaintenanceRequestEdit model =
                new MaintenanceRequestEdit
                {
                    RequestID = details.RequestID,
                    ResidentID = details.ResidentID,
                    Category = details.Category,
                    SubCategory = details.SubCategory,
                    Location = details.Location,
                    Description = details.Description,
                    Status = details.Status,
                    AccessPermission = details.AccessPermission,
                };
            return View(model);
        }
        //CREATE MaintenanceRequest/Edit/{id}{edit model}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MaintenanceRequestEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if(model.RequestID != id)
            {
                ModelState.AddModelError("", "MaintenanceRequest can not be updated");
                return View(model);
            }
            var service = CreateMaintenanceRequestService();
            if (service.UpdateMaintenanceRequest(model))
            {
                TempData["SaveResult"] = " Maintenance Request was updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "MaintenanceRequest can not be updated");
            return View(model);
        }

        //GET: MaintenanceRequest/Delete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateMaintenanceRequestService();
            var model = service.GetByRequestID(id);
            return View(model);
        }

        //POST: MaintenanceRequest/Delete/{id}
        [ActionName("Delete")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRequest(int id)
        {
            var service = CreateMaintenanceRequestService();
            service.DeleteMaintenanceRequest(id);
            TempData["SaveResult"] = "Maintenance Request was deleted";
            return RedirectToAction("Index");
        }
        private MaintenanceRequestService CreateMaintenanceRequestService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new MaintenanceRequestService(userID);
            return service;
        }
    }
}