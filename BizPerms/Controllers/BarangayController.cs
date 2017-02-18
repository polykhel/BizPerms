using System;
using System.Collections.Generic;
using System.Web.Mvc;
using G4.BizPermit.Entities;
using G4.BizPermit.Dal;
using BizPerms.Helpers;

namespace G4.BizPermit.Web.Controllers
{
    public class BarangayController : Controller
    {
        [AccessDeniedAuthorize(Roles = "Admin")]
        // GET: Barangay
        public ActionResult Index()
        {
            ViewBag.Districts = DistrictData.ListAll();
            List<Barangay> model = new List<Barangay>();
            model = BarangayData.ListAll();
            return View(model);
        }

        // GET: Add Barangay
        public ActionResult Add()
        {
            ViewBag.Districts = DistrictData.ListAll();
            return View();
        }

        // POST: Add Barangay
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Barangay model)
        {
            bool result = BarangayData.Add(model);
            if (result)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Delete Barangay
        public ActionResult Delete(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index");
            }

            ViewBag.Districts = DistrictData.ListAll();
            Barangay model = BarangayData.GetById(id);
            return View(model);
        }

        // POST: Delete Barangay
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Barangay model)
        {
            bool result = BarangayData.Delete(model.UniqueId.ToString());
            if (result)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Edit Barangay
        public ActionResult Edit(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index");
            }

            ViewBag.Districts = DistrictData.ListAll();
            Barangay model = BarangayData.GetById(id);
            return View(model);
        }

        // POST: Edit Barangay
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Barangay model)
        {
            bool result = BarangayData.Edit(model);
            if (result)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}