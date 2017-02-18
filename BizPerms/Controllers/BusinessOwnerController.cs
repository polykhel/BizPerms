using System;
using System.Collections.Generic;
using System.Web.Mvc;
using G4.BizPermit.Entities;
using G4.BizPermit.Dal;
using BizPerms.Helpers;

namespace G4.BizPermit.Web.Controllers
{
    [AccessDeniedAuthorize(Roles = "Admin")]
    public class BusinessOwnerController : Controller
    {
        List<string> status = new List<string>() { "Single", "Married", "Separated", "Divorced", "Widow/er" };
        List<string> designation = new List<string>() { "Mr.", "Ms.", "Mrs." };
        List<string> gender = new List<string>() { "Male", "Female" };

        // GET: BusinessOwner
        public ActionResult Index()
        {
            List<BusinessOwner> model = BusinessOwnerData.ListAll();
            return View(model);
        }

        public ActionResult Add()
        {
            ViewBag.maritalstatus = status;
            ViewBag.designation = designation;
            ViewBag.gender = gender;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(BusinessOwner model)
        {
            bool result = BusinessOwnerData.Add(model);
            if (result)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Edit(string id)
        {
            ViewBag.maritalstatus = status;
            ViewBag.designation = designation;
            ViewBag.gender = gender;
            BusinessOwner model = BusinessOwnerData.GetById(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BusinessOwner model)
        {
            bool result = BusinessOwnerData.Edit(model);
            if (result)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Delete(string id)
        {
            BusinessOwner model = BusinessOwnerData.GetById(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(BusinessOwner model)
        {
            bool result = BusinessOwnerData.Delete(model.UniqueId.ToString());
            if (result)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}