using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using G4.BizPermit.Entities;
using G4.BizPermit.Dal;
using BizPerms.Helpers;

namespace G4.BizPermit.Web.Controllers
{
    [AccessDeniedAuthorize(Roles = "Admin")]
    public class DistrictController : Controller
    {
        // GET: District
        public ActionResult Index()
        {
            ViewBag.Cities = CitiesData.ListAll();
            List<District> model = DistrictData.ListAll();
            return View(model);
        }

        public ActionResult Add()
        {
            ViewBag.Cities = CitiesData.ListAll();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(District model)
        {
            bool result = DistrictData.Add(model);
            if (result)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Edit(string id)
        {
            ViewBag.Cities = CitiesData.ListAll();
            District model = DistrictData.GetById(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(District model)
        {
            bool result = DistrictData.Edit(model);
            if (result)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Delete(string id)
        {
            ViewBag.Cities = CitiesData.ListAll();
            District model = DistrictData.GetById(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(District model)
        {
            bool result = DistrictData.Delete(model.UniqueId.ToString());
            if (result)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}