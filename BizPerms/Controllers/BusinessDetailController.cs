using System;
using System.Collections.Generic;
using System.Web.Mvc;
using G4.BizPermit.Entities;
using G4.BizPermit.Dal;
using BizPerms.Helpers;

namespace G4.BizPermit.Web.Controllers
{
    public class BusinessDetailController : Controller
    {
        [AccessDeniedAuthorize(Roles = "Admin")]
        // GET: BusinessDetail
        public ActionResult Index()
        {
            ViewBag.businesslines = BusinessLineData.ListAll();
            List<BusinessDetail> model = new List<BusinessDetail>();
            model = BusinessDetailData.ListAll();
            return View(model);
        }

        public ActionResult Add()
        {
            ViewBag.businesslines = BusinessLineData.ListAll();
            return View();
        }

        [HttpPost]
        public ActionResult Add(BusinessDetail model)
        {
            bool result = BusinessDetailData.Add(model);
            if (result)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
        public ActionResult Edit(string id)
        {
            ViewBag.businesslines = BusinessLineData.ListAll();
            BusinessDetail model = BusinessDetailData.GetById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(BusinessDetail model)
        {
            bool result = BusinessDetailData.Edit(model);
            if (result)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Delete(string id)
        {
            ViewBag.businesslines = BusinessLineData.ListAll();
            BusinessDetail model = BusinessDetailData.GetById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(BusinessDetail model)
        {
            bool result = BusinessDetailData.Delete(model.UniqueId.ToString());
            if (result)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}



