using HeavenlyHome_Data;
using HeavenlyHome_Models.AddressModels;
using HeavenlyHome_Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HeavenlyHomeApartments_WebMVC.Controllers
{
    public class AddressController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Address
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new AddressService(userID);
            var model = service.GetAllAddress();
            return View(model);
        }

        //GET: AddressCreate

        public ActionResult Create()
        {
            ViewBag.FloorPlanID = new SelectList(_db.FloorPlans, "FloorPlanID", "FloorPlanName");
            return View();
        }

        //Create: AddressCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddressCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateAddressService();

            if (service.CreateAddress(model))
            {
                TempData["SaveResult"] = "New Address was created";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Address can not be found");
            return View(model);

        }

        //GET: Address/Details/{id}
        public ActionResult Details(int id)
        {
            var service = CreateAddressService();
            AddressDetail model = service.GetByAddressID(id);
            return View(model);
        }

        //GET: Adress/Edit/{id}
        public ActionResult Edit(int id)
        {
            var service = CreateAddressService();
            var details = service.GetByAddressID(id);
            AddressEdit model = new AddressEdit
            {
                AddressID = details.AddressID,
                FloorPlanID = details.FloorPlanID,
                FullAddress = details.FullAddress,
                IsAvailable = details.IsAvailable

            };
            return View(model);
        }
        //Create: Address/Edit/{id},{Model}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AddressEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.AddressID != id)
            {
                ModelState.AddModelError("", "ID mismatch");
                return View(model);
            }
            var service = CreateAddressService();
            if (service.UpdateAddress(model))
            {
                TempData["SaveResult"] = " Address was updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Address could not be updated");
            return View(model);
        }

        //GET: Address/Delete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateAddressService();
            var model = service.GetByAddressID(id);
            return View(model);
        }

        //POST: Address/Delete/{id}
        [ActionName("Delete")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAddress(int id)
        {
            var service = CreateAddressService();
            service.DeleteAddress(id);
            TempData["SaveResult"] = " Address was deleted";
            return RedirectToAction("Index");
        }
        private AddressService CreateAddressService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new AddressService(userID);
            return service;
        }
    }
}