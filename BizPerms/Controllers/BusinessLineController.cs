using System;
using System.Collections.Generic;
using System.Web.Mvc;
using G4.BizPermit.Dal;
using G4.BizPermit.Entities;
using BizPerms.Helpers;
using System.Linq;

namespace G4.BizPermit.Web.Controllers
{
    public class BusinessLineController : Controller
    {
        [AccessDeniedAuthorize(Roles = "Admin")]
        // GET: BusinessLine
        public ActionResult Index()
        {
            ViewBag.businessnature = BusinessNatureData.ListAll();
            List<BusinessLine> model = new List<BusinessLine>();
            model = BusinessLineData.ListAll();
            return View(model);
        }

        public ActionResult Add()
        {
            ViewBag.businessnature = BusinessNatureData.ListAll();
            return View();
        }

        [HttpPost]
        public ActionResult Add(BusinessLine model)
        {
            bool result = BusinessLineData.Add(model);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        //EDIT RECORD

        public ActionResult Edit(string id)
        {
            ViewBag.businessnature = BusinessNatureData.ListAll();
            BusinessLine model = BusinessLineData.GetById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(BusinessLine model)
        {
            bool result = BusinessLineData.Edit(model);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        //DELETE RECORD

        public ActionResult Delete(string id)
        {
            ViewBag.businessnature = BusinessNatureData.ListAll();
            BusinessLine model = BusinessLineData.GetById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(BusinessLine model)
        {
            bool result = BusinessLineData.Delete(model.UniqueId.ToString());
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}