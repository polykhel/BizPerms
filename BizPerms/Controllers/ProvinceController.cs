using BizPerms.Helpers;
using G4.BizPermit.Dal;
using G4.BizPermit.Entities;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace G4.BizPermit.Web.Controllers
{
    [AccessDeniedAuthorize(Roles = "Admin")]
    public class ProvinceController : Controller
    {
        // GET: Provinces
        public ActionResult Index()
        {
            List<Province> model = new List<Province>();
            model = ProvincesData.ListAll();
            return View(model);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Province prov)
        {
            bool result = ProvincesData.Add(prov);
            if (result)
            {
                return RedirectToAction("Index");
            }else
            {
                return View();
            }
        }

        public ActionResult Edit(string id)
        {
            Province prov = ProvincesData.GetById(id);
            return View(prov);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Province prov)
        {
            bool result = ProvincesData.Edit(prov);
            if (result)
            {
                return RedirectToAction("Index");
            }else
            {
                return View();
            }
        }

        public ActionResult Delete(string id)
        {
            Province prov = ProvincesData.GetById(id);
            return View(prov);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Province prov)
        {
            bool result = ProvincesData.Delete(prov.UniqueId.ToString());
            if (result)
            {
                return RedirectToAction("Index");
            }else
            {
                return View();
            }
        }
    }
}