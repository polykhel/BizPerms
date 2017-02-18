using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using G4.BizPermit.Dal;
using G4.BizPermit.Entities;
using BizPerms.Helpers;

namespace G4.BizPermit.Web.Controllers
{
    [AccessDeniedAuthorize(Roles = "Admin")]
    public class StreetController : Controller
    {
        // GET: Street
        public ActionResult Index()
        {
            ViewBag.barangays = BarangayData.ListAll();
            List<Street> model = new List<Street>();
            model = StreetData.ListAll();
            return View(model);
        }

        // GET: Add Street
        public ActionResult Add()
        {
            ViewBag.barangays = BarangayData.ListAll();
            return View();
        }

        // POST: Add Street
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Street model)
        {
            bool result = StreetData.Add(model);
            if (result)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Delete Street
        public ActionResult Delete(string id)
        {
            ViewBag.barangays = BarangayData.ListAll();
            Street model = StreetData.GetById(id);
            return View(model);
        }

        // POST: Delete Street
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Street model)
        {
            bool result = StreetData.Delete(model.UniqueId.ToString());
            if (result)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Edit Street
        public ActionResult Edit(string id)
        {
            ViewBag.barangays = BarangayData.ListAll();
            Street model = StreetData.GetById(id);
            return View(model);
        }

        // POST: Edit Street
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Street model)
        {
            bool result = StreetData.Edit(model);
            if (result)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}