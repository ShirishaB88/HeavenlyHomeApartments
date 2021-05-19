using HeavenlyHome_Models.ApplicantModels;
using HeavenlyHome_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HeavenlyHomeApartments_WebMVC.Controllers
{
    public class ApplicantController : Controller
    {
        // GET: Applicant
        public ActionResult Index()
        {
            return View();
        }

        //GET: Applicant/Create

        public ActionResult Create()
        {
            return View();
        }

        //POST: Applicant/Create
        [HttpPost]
        public ActionResult Create(ApplicantCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var service = new ApplicantService();
            if (service.CreateApplicant(model))
            {
                TempData["SaveResult"] = "Hello! " +  model.FirstName + " Your Application has been posted! We will get back to you As Soon As Possible, Thank you!";

                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Application not been posted!");
            return View(model);
        }
    }
}