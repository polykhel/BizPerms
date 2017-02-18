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
    public class BusinessTypeController : Controller
    {
        // GET: BusinessType
        public ActionResult Index()
        {
            List<BusinessType> model = BusinessTypeData.ListAll();
            return View(model);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(BusinessType model)
        {
            bool result = BusinessTypeData.Add(model);
            if (result)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Edit(string id)
        {
            BusinessType model = BusinessTypeData.GetById(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BusinessType model)
        {
            bool result = BusinessTypeData.Edit(model);
            if (result)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Delete(string id)
        {
            BusinessType model = BusinessTypeData.GetById(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(BusinessType model)
        {
            bool result = BusinessTypeData.Delete(model.UniqueId.ToString());
            if (result)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}