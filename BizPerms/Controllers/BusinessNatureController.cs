using System;
using System.Collections.Generic;
using System.Web.Mvc;
using G4.BizPermit.Dal;
using G4.BizPermit.Entities;
using BizPerms.Helpers;

namespace G4.BizPermit.Web.Controllers
{
    public class BusinessNatureController : Controller
    {
        [AccessDeniedAuthorize(Roles = "Admin")]
        // GET: BusinessNature
        public ActionResult Index()
        {
            List<BusinessNature> model = new List<BusinessNature>();
            model = BusinessNatureData.ListAll();
            return View(model);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(BusinessNature model)
        {
            bool result = BusinessNatureData.Add(model);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        //EDIT RECORD
      
        public ActionResult Edit(string id)
        {
            BusinessNature model = BusinessNatureData.GetById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(BusinessNature model)
        {
            bool result = BusinessNatureData.Edit(model);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        //DELETE RECORD

        public ActionResult Delete(string id)
        {
            BusinessNature model = BusinessNatureData.GetById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(BusinessNature model)
        {
            bool result = BusinessNatureData.Delete(model.UniqueId.ToString());
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}