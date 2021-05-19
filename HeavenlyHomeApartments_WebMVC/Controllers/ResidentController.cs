using HeavenlyHome_Data;
using HeavenlyHome_Models.ResidentModels;
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
    public class ResidentController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Resident
        public ActionResult Index(string searchBy, string search)
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new ResidentService(userID);
            var model = service.GetAllResidents();

            //return View(model);

            if(searchBy == "Name")
            {
                return View(model.Where(e => e.FullName.StartsWith(search)));
            }
            else if (searchBy == "ID")
            {
                return View(model.Where(e => e.ResidentID == int.Parse(search)));
            }
            else
            {
                return View(model);
            }

        }

        //GET: ResidentCreate
        public ActionResult Create()
        {
            ViewBag.AddressID = new SelectList(_db.Addresses, "AddressID", "FullAddress");
            return View();
        }

        //Create: ResidentCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ResidentCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateResidentService();
            if (service.CreateResident(model))
            {
                TempData["SaveResult"] = " New Resident was Added!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Resident can not be Added");
            return View(model);

        }

        //GET: Resident/Details/{id}
        public ActionResult Details(int id)
        {
            var service = CreateResidentService();
            var model = service.GetResidentByID(id);
            return View(model);
        }

        //Get: Resident/Edit/{id}
        public ActionResult Edit(int id)
        {
            var service = CreateResidentService();
            var details = service.GetResidentByID(id);
            var model =
                new ResidentEdit 
                {
                    ResidentID = details.ResidentID,
                    AddressID = details.AddressID,
                    FullName = details.FullName,
                    PhoneNumber = details.PhoneNumber,
                    EmailAddress = details.EmailAddress

                };
            return View(model);
        }
        //Create: Resident/Edit/{id},{model}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ResidentEdit model) 
        {
            if (!ModelState.IsValid) return View(model);
            if (model.ResidentID != id)
            {
                ModelState.AddModelError("", "ID mismatch");
                return View(model);
            }
            var service = CreateResidentService();
            if (service.UpdateResident(model))
            {
                TempData["SaveResult"] = " Resident was updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Resident could not be updated");
            return View(model);
        }

        //GET: Resident/Delete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateResidentService();
            var model = service.GetResidentByID(id);
            return View(model);
        }

        //POST: Resident/Delete/{id}
        [ActionName("Delete")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteResident(int id)
        {
            var service = CreateResidentService();
             service.DeleteResident(id);
            TempData["SaveResult"] = " Resident was deleted";
            return RedirectToAction("Index");
        }


        private ResidentService CreateResidentService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new ResidentService(userID);
            return service;
        }
    }
}