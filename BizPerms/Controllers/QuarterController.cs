using System;
using System.Collections.Generic;
using System.Web.Mvc;
using G4.BizPermit.Dal;
using G4.BizPermit.Entities;
using BizPerms.Helpers;

namespace G4.BizPermit.Web.Controllers
{
    [AccessDeniedAuthorize(Roles = "Admin")]
    public class QuarterController : Controller
    {
        // GET: Quarter
        public ActionResult Index()
        {
            List<Quarter> model = new List<Quarter>();
            model = QuarterData.ListAll();
            return View(model);
        }

        // GET: Add Quarter
        public ActionResult Add()
        {
            return View();
        }

        // POST: Add Quarter
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Quarter model)
        {
            bool result = QuarterData.Add(model);
            if (result)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Delete Quarter
        public ActionResult Delete(int id)
        {
            Quarter model = QuarterData.GetById(id);
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // POST: Delete Quarter
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Quarter model)
        {
            bool result = QuarterData.Delete(model.Id);
            if (result)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Edit Quarter
        public ActionResult Edit(int id)
        {
            Quarter model = QuarterData.GetById(id);
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // POST: Edit Quarter
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Quarter model)
        {
            bool result = QuarterData.Edit(model);
            if (result)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}